using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	[System.Serializable]
	public class PoolableItem
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
	static public PoolableItem Retrieve(string name, out int index)
	{
		for (index = 0; index < Singleton().pool.Length; index++)
		{
			PoolableItem item = Singleton().pool[index];
			if (item.name.Equals(name))
				return item;
		}
		return null;
	}


	public static Pool Item_Call(PoolableItem item)
	{

		Pool poolItem = null;
		if (item.spawned.Count == 0)
		{
			poolItem = Instantiate(item.referenceItem);
			poolItem.transform.parent = item.folder;
			for (int i = 0; i < Singleton().pool.Length; i++)
				if(item == Singleton().pool[i])
				{
					poolItem.index = i;
					break;
				}
		}
		else
			poolItem = item.spawned.Dequeue();

		poolItem.gameObject.SetActive(true);
		poolItem.OnCall.Invoke();


		return poolItem;
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
		if (item.index < 0)
		{
			for (var i = 0; i < Singleton().pool.Length; i++)
				if (item.transform.parent == Singleton().pool[i].folder)
				{
					item.index = i;
					break;
				}

			Destroy(item.gameObject);
			return;
		}

		Singleton().pool[item.index].spawned.Enqueue(item);

		item.OnDismiss.Invoke();
		item.gameObject.SetActive(false);
	}
}