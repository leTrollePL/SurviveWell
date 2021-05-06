using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;


    public float maxHealth = 100f;

    public float currentHealth;

    public Transform dropPoint;
    public bool drops;
    public GameObject theDrops;

    public PasekHP pasekHP;

    public float AktualneHP()
    {
        return health;
    }

    public void DealDamage(float damage)
    {
       
        health -= damage;
        currentHealth = health;
        //pasekHP.SetHealth(health);
        if (health <= 0)
        {
            Debug.Log("Health loss");
            if (gameObject.layer == 9)
            {
                Debug.Log("Health loss1");
                pasekHP.SetHealth(health);
               // healthbarUI.SetHealth(health);
            }
            else if (gameObject.layer == 10)
            {
                Debug.Log("Health loss2");
                //healthbarUI.SetHealth(health);
            }
            else
            {
                //if (drops)
                //{
                //    Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
                //}
                Destroy(gameObject);
                Debug.Log("Health loss");
            }

        }
    }
    void Start()
    {
        currentHealth = maxHealth;
        //pasekHP.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       // pasekHP.SetMaxHealth(health);
    }
}
