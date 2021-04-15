using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgBoostWhite : MonoBehaviour
{

    WhiteController white;
    SlashControler slash;


    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        //slash = FindObjectOfType<SlashControler>();
        //bullet = FindObjectOfType<BulletController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            white.betterslash = true;
            //slash.damageMultiplier = 2f;
            Destroy(gameObject);
        }

    }
}
