using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
