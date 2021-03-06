using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdnowienieHp : MonoBehaviour
{
    // Start is called before the first frame update
    Health health;
    public GameController Gcontroller;
    [SerializeField] float damage = 25f;

    public float Hpbonus = 50f;

    WhiteController white;
    BlackController black;

    public float zycie;
    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (health.currentHealth < health.maxHealth)
        //{

        //}
        //black
            if (collision.gameObject.layer == 10)
            {
                Destroy(gameObject);
                zycie = black.GetComponent<Health>().AktualneHP();
                black.GetComponent<Health>().odnowienieHP(20);

        }
            //white
            if (collision.gameObject.layer == 9)
            {

                Destroy(gameObject);
                zycie = white.GetComponent<Health>().AktualneHP();
                white.GetComponent<Health>().odnowienieHP(20);
        }
        
    }

    public void odnowienieWhite()
    {
        if (white.GetComponent<PlayerMoney>().currentMoney() >= 50 && white.GetComponent<Health>().AktualneHP() < 100.0)
        {
            white.GetComponent<PlayerMoney>().SubbMoney(50);
            white.GetComponent<Health>().odnowienieHP(100);
        }
        else
        {
            Debug.Log("brak hajsu");
        }
    }

    public void odnowienieBlack()
    {
        if (black.GetComponent<PlayerMoney>().currentMoney() >= 50 && black.GetComponent<Health>().AktualneHP() < 100.0)
        {
            black.GetComponent<PlayerMoney>().SubbMoney(50);
            black.GetComponent<Health>().odnowienieHP(100);
        }
        else
        {
            Debug.Log("brak hajsu");
        }
        
    }
}
