using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdnowienieHp : MonoBehaviour
{
    // Start is called before the first frame update
    Health health;
    WhiteController white;
    public GameController Gcontroller;
    [SerializeField] float damage = 25f;

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
            if (collision.gameObject.layer == 10)
            {
                var health = Gcontroller.BController.GetComponent<Health>();
                health.DealDamage(-damage);
                Destroy(gameObject);

            }
            if (collision.gameObject.layer == 9)
            {
                var health = Gcontroller.BController.GetComponent<Health>();
                health.DealDamage(-damage);
                Destroy(gameObject);

            }
        
    }
}
