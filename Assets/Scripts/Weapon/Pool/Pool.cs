using UnityEngine;

public class Pool : MonoBehaviour
{
	[HideInInspector]
	public int index;

	public UnityEngine.Events.UnityEvent OnCall;
	public UnityEngine.Events.UnityEvent OnDismiss;

	public void Pool_Dismiss()
	{
		PoolManager.Item_Dismiss(this);
	}
}
