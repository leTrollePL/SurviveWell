using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LepszySkok : MonoBehaviour
{
    WhiteController white;
    BlackController black;

    public float jumpbonus = 50f;

    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            white.betterjump = true;

            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Black")
        {
            black.betterjump = true;

            Destroy(gameObject);
        }

    }

    public void betterjumpWhite()
    {
        if(white.GetComponent<PlayerMoney>().currentMoney() >= 100 && white.betterjump == false)
        {
            white.GetComponent<PlayerMoney>().SubbMoney(100);
            white.betterjump = true;
        }
        else
        {
            Debug.Log("brak hajsu");
        }

    }

    public void betterjumpBlack()
    {
        if (black.GetComponent<PlayerMoney>().currentMoney() >= 100 && black.betterjump == false)
        {
            black.GetComponent<PlayerMoney>().SubbMoney(100);
            black.betterjump = true;
        }
        else
        {
            Debug.Log("brak hajsu");
        }
    }
}
