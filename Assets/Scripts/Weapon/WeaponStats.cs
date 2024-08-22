using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponStats
{
	public float damage_shrapnel;
	public float damage_energy;
	public float damage_heavy;

	public float projectile_Size;
	public float projectile_Velocity;
	public int projectile_Piercing;
	public float projectile_Range;

	public float fireRate_PPS;
	public int fireRate_burst;
	public float fireRate_burstPPS;
	public bool fireRate_FullAuto;

	public float spread;
	public float reloadTime;


	public static WeaponStats operator+ (WeaponStats a, WeaponStats b){
		var c = new WeaponStats();
		c.damage_shrapnel = a.damage_shrapnel + b.damage_shrapnel;
		c.damage_energy = a.damage_energy + b.damage_energy;
		c.damage_heavy = a.damage_heavy + b.damage_heavy;

		c.projectile_Size = a.projectile_Size + b.projectile_Size;
		c.projectile_Velocity = a.projectile_Velocity + b.projectile_Velocity;
		c.projectile_Piercing = a.projectile_Piercing + b.projectile_Piercing;
		c.projectile_Range = a.projectile_Range + b.projectile_Range;


		c.fireRate_PPS = a.fireRate_PPS + b.fireRate_PPS;
		c.fireRate_burst = a.fireRate_burst + b.fireRate_burst;
		c.fireRate_burstPPS = a.fireRate_burstPPS + b.fireRate_burstPPS;
		c.fireRate_FullAuto	  =	a.fireRate_FullAuto	|| b.fireRate_FullAuto;


		c.spread = a.spread + b.spread;
		c.reloadTime = a.reloadTime + b.reloadTime;

		return c;
	}
	public static WeaponStats operator -(WeaponStats a, WeaponStats b) { 
		var c = new WeaponStats();
		c.damage_shrapnel = a.damage_shrapnel - b.damage_shrapnel;
		c.damage_energy = a.damage_energy - b.damage_energy;
		c.damage_heavy = a.damage_heavy - b.damage_heavy;

		c.projectile_Size = a.projectile_Size - b.projectile_Size;
		c.projectile_Velocity = a.projectile_Velocity - b.projectile_Velocity;
		c.projectile_Piercing = a.projectile_Piercing - b.projectile_Piercing;
		c.projectile_Range = a.projectile_Range - b.projectile_Range;


		c.fireRate_PPS = a.fireRate_PPS - b.fireRate_PPS;
		c.fireRate_burst = a.fireRate_burst - b.fireRate_burst;
		c.fireRate_burstPPS = a.fireRate_burstPPS - b.fireRate_burstPPS;

		c.fireRate_FullAuto = a.fireRate_FullAuto && b.fireRate_FullAuto;


		c.spread = a.spread - b.spread;
		c.reloadTime = a.reloadTime - b.reloadTime;

		return c;
	}
	public static WeaponStats operator *(WeaponStats a, float b)
	{
		var c = a;

		c.damage_shrapnel *= b;
		c.damage_energy *= b;
		c.damage_heavy *= b;

		c.projectile_Size *= b;
		c.projectile_Velocity *= b;
		c.projectile_Piercing = Mathf.RoundToInt(b *(float)c.projectile_Piercing);
		c.projectile_Range *= b;

		c.fireRate_PPS *= b;
		c.fireRate_burst = Mathf.RoundToInt(b * (float)c.fireRate_burst);
		c.fireRate_burstPPS = Mathf.RoundToInt(b * (float)c.fireRate_burstPPS);

		c.spread *= b;
		c.reloadTime *= b;

		return c;
	}
	public static WeaponStats operator /(WeaponStats a, float b)
	{
		var c = a;
		var div = 1f / b;

		c = c * div;
		return c;
	}
}
