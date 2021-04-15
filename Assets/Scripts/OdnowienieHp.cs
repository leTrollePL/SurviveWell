using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdnowienieHp : MonoBehaviour
{
    // Start is called before the first frame update
    Health health;
    WhiteController white;


    public float Hpbonus = 50f;

    void Awake()
    {
        health = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (health.currentHealth < health.maxHealth)
        //{

        //}

        Destroy(gameObject);
        health.currentHealth = +Hpbonus;
    }
}
