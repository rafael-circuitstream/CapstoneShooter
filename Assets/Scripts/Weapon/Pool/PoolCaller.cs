[System.Serializable]
public class PoolCaller
{
	public string nameOfPool;
	private PoolManager.PoolableItem itemPool;

	public Pool CallItem()
	{
		if (itemPool == null)
			itemPool = PoolManager.Retrieve(nameOfPool, out var i);
		return PoolManager.Item_Call(itemPool);
	}
}