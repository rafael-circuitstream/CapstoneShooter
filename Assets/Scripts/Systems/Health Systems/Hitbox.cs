using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float normal_damagePercentage = 1f;
    [SerializeField] private HealthSystem healthSystem;
    [HideInInspector] public Vector3 damagerPosition;

    public void Damage(WeaponStats weapon, Vector3 damagerPosition)
	{
        healthSystem.Damage(weapon);
        this.damagerPosition = damagerPosition;
	}

	private void OnValidate()
	{
        if (healthSystem)
            return;

        healthSystem = gameObject.GetComponentInChildren<HealthSystem>(true);
        if (!healthSystem)
            healthSystem = gameObject.GetComponentInParent<HealthSystem>(true);
	}
}