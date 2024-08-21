using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	[System.Serializable]
	private class PoolableItem
	{
		public string name = "null";
		public Pool referenceItem;
		[HideInInspector]
		public Transform folder;
		[HideInInspector]
		public Queue<Pool> spawned = new();
	}
	[SerializeField]
	private PoolableItem[] pool;



	public static PoolManager Singleton()
	{
		if (!singleton)
		{
			singleton = FindObjectOfType<PoolManager>();
			if (!singleton)
			{
				var reference = Resources.Load<PoolManager>("Pool Manager");
				singleton = Instantiate(reference);
			}
		}
		return singleton;
	}
	private static PoolManager singleton;
	private void Awake()
	{
		if(Singleton() != this)
			Destroy(gameObject);

		foreach (var item in pool)
		{
			item.folder = new GameObject(item.name).transform;
			item.folder.parent = transform;
		}
	}
	static private PoolableItem Retrieve(string name, out int index)
	{
		for (index = 0; index < Singleton().pool.Length; index++)
		{
			PoolableItem item = Singleton().pool[index];
			if (item.name.Equals(name))
				return item;
		}
		return null;
	}


	public static Pool Item_Call(string name)
	{
		var item = Retrieve(name, out var index);

		Pool poolItem = null;
		if (item.spawned.Count == 0)
		{
			poolItem = Instantiate(item.referenceItem);
			poolItem.transform.parent = item.folder;
			poolItem.index = index;
		}
		else
			poolItem = item.spawned.Dequeue();

		poolItem.gameObject.SetActive(true);
		poolItem.OnCall.Invoke();


		return poolItem;
	}
	public static void Item_Dismiss(Pool item)
	{
		Singleton().pool[item.index].spawned.Enqueue(item);
		item.OnDismiss.Invoke();
		item.gameObject.SetActive(false);
	}
}