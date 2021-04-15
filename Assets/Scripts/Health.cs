using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health =100f;

    public float maxHealth;
    public float currentHealth;

    public void DealDamage(float damage)
    {
        health -= damage;
        currentHealth = health;
        if (health <= 0)
        {
            if(gameObject.layer==9 || gameObject.layer == 10)
            {
              
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
