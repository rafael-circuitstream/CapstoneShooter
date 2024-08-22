using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [System.Serializable]
    private class Health
	{
        public enum Resistence
		{
            flesh,
            energyShield,
            Armor
		}

        [SerializeField]
        private Resistence resistence;

        [SerializeField]
        private float regenDelay_Max;
        private float regenDelay;

        [SerializeField]
        private float regenHealthPS;

        public float MaxHealth;
        float health;

        public void H_SetFullHealth()
		{
            health = MaxHealth;
		}
        public void H_Damage(float damage, Resistence resistenceSend)
		{
            if (resistence != resistenceSend)
                return;
            regenDelay = 0f;
            health -= damage;
            if (health <= 0)
                health = 0;
		}

        public bool H_Regenerate(float deltaTime)
		{
            if (health == MaxHealth)
                return false;

            if (regenDelay < regenDelay_Max)
                regenDelay += deltaTime;
			else
                health = Mathf.Clamp(health + deltaTime * regenHealthPS, 0, MaxHealth);
            return true;
		}
        public bool H_IsDepleted()
		{
            return health == 0;
		}
	}


    int health_RegenIndex;
    [SerializeField]
    private Health[] health = new Health[1];
    Health health_base => health[0];

    public bool isDead;

    [SerializeField]
    public UnityEvent OnDamage;
    [SerializeField]
    public UnityEvent OnRegeneration;
    [SerializeField]
    public UnityEvent OnDeath;

    void Start()
    {
        foreach (var item in health)
            item.H_SetFullHealth();

    }
	private void Update()
	{
        health_RegenIndex++;
        if (health_RegenIndex >= health.Length)
            health_RegenIndex = 0;
        if (health[health_RegenIndex].H_Regenerate(Time.deltaTime * (float)health.Length))
            OnRegeneration.Invoke();
	}
	public void Damage(WeaponStats stats)
    {
        var shrapnel = stats.damage_shrapnel;
        var energy = stats.damage_energy;
        var heavy = stats.damage_heavy;
        if (shrapnel <= 0 && energy <= 0 && heavy <= 0)
            return;

		foreach (var h in health)
		{
            if (h.H_IsDepleted())
                continue;
            h.H_Damage(shrapnel, Health.Resistence.flesh);
            h.H_Damage(energy, Health.Resistence.energyShield);
            h.H_Damage(heavy, Health.Resistence.Armor);

            break;
		}
        OnDamage.Invoke();
        if (health_base.H_IsDepleted())
            OnDeath.Invoke();
    }
}
