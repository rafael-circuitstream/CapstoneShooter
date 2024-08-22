using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Pool
{
    public WeaponStats bulletStats;
    [SerializeField]
    private Rigidbody rigidbody;
    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.Damage(bulletStats);

            if (bulletStats.projectile_Piercing < 0)
                Pool_Dismiss();
        }
        Destroy(gameObject, 2f);
    }

	private void Update()
	{
        rigidbody.velocity = transform.forward * bulletStats.projectile_Velocity;
        bulletStats.projectile_Range -= bulletStats.projectile_Velocity * Time.deltaTime;
	}

    public void Set(Vector3 position, Quaternion rotation, Vector3 size, WeaponStats bulletStats)
	{
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = size;
        this.bulletStats = bulletStats;
	}

}
