using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public int maxHealthPoints;
    public int healthPoints;
    public bool isDead;

    public UnityEvent<int> OnHealthChanged;

    void Start()
    {
        healthPoints = maxHealthPoints;

    }

    public void Damage(int damageCaused)
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
        
    }
}
