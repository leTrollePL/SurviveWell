using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBoostWhite : MonoBehaviour
{

    WhiteController white;
    

    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            white.betterslash = true;
            Destroy(gameObject);
        }

    }
}
