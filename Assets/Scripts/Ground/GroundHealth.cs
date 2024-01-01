using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public float CurrentHealth => currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Attack(float health)
    {
        currentHealth -= health;
    }
}
