using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponStats
{
	public Projectile CallProjectile()
	{
		Debug.Log("Pool" + projectile);
		return null;
	}

	public Projectile projectile;
	public float projectile_Damage;
	public float projectile_Velocity;
	public float projectile_Duration;
	public int projectile_Piercing;


	public float fireRate_PPS;
	public int fireRate_burst;
	public float fireRate_burstPPS;
	public bool fireRate_FullAuto;


	public float reloadTime;

}
