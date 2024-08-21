using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Projectile : Pool
{

	public float p_Damage;
	public float p_Velocity;
	public float p_Duration;
	public int p_Piercing;

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<HealthSystem>(out var health))
		{
			health.Damage(p_Damage);
			p_Piercing--;
			if (p_Piercing <= 0)
				Pool_Dismiss();
		}
	}
}
