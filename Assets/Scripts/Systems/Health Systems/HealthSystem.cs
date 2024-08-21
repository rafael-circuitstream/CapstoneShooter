using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public float maxHealthPoints;
    public float healthPoints;
    public bool isDead;

    public UnityEvent<float> OnHealthChanged;

    void Start()
    {
        healthPoints = maxHealthPoints;

    }

    public void Damage(float damageCaused)
    {
        healthPoints -= damageCaused;
        OnHealthChanged.Invoke(healthPoints);
        if (healthPoints <= 0 && !isDead)
        {

            Die();

        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
