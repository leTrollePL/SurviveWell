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
    public GameObject koniec;
    public GameObject koniecGry;
    public PasekHP pasekHP;

    public float AktualneHP()
    {
        return health;
    }

    public void setHp(float x)
    {
         health = x;
    }


    public void odnowienieHP(float hp)
    {
        health += hp;
    }

    public void fullrestore()
    {
        health = 100f;
    }


    public void DealDamage(float damage)
    {
        AudiomanagerScript.PlaySound("playerhit");

        health -= damage;
        if(health > 100)
        {
            if (gameObject.layer == 9)
            {
                health = 100;
            }
            else if (gameObject.layer == 10)
            {
                health = 100;
            }
        }

        currentHealth = health;
        //pasekHP.SetHealth(health);
        if (health <= 0)
        {
            Debug.Log("Health loss");
            if (gameObject.layer == 9)
            {
                AudiomanagerScript.PlaySound("deatchSound");

                Debug.Log("Health loss1");
                koniec.SetActive(true);
                //pasekHP.SetHealth(health);
               // healthbarUI.SetHealth(health);
            }
            else if (gameObject.layer == 10)
            {
                Debug.Log("Health loss2");
                koniec.SetActive(true);
                //healthbarUI.SetHealth(health);
            }
            else if (gameObject.tag == "Boss")
            {
                Destroy(gameObject);
                koniecGry.SetActive(true);
            }
            else
            {
                if (drops)
                {
                    GameObject droppped =Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
                    droppped.SetActive(true);
                }
                Destroy(gameObject);
                Debug.Log("Health loss");
            }

        }
    }
    void Start()
    {
        //currentHealth = maxHealth;
        //pasekHP.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       // pasekHP.SetMaxHealth(health);
    }

   
}
