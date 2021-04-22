using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    WhiteController white;
    BlackController black;

    public int dropValue = 10;
    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            white.GetComponent<PlayerMoney>().addMoney(dropValue);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Black")
        {
            black.GetComponent<PlayerMoney>().addMoney(dropValue);
            Destroy(gameObject);
        }

    }
}
