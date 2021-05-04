using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;


    public float maxHealth;
    public float currentHealth;

    public Transform dropPoint;
    public bool drops;
    public GameObject theDrops;

    public void DealDamage(float damage)
    {
       
        health -= damage;
        currentHealth = health;
        if (health <= 0)
        {
            Debug.Log("Health loss");
            if (gameObject.layer == 9 || gameObject.layer == 10)
            {
                Debug.Log("Health loss");
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
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
