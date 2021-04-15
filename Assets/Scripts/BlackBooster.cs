using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBooster : MonoBehaviour
{

    BlackController black;
    BulletController bullet;


    void Awake()
    {
        black = FindObjectOfType<BlackController>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Black")
        {
            black.cannonCD = 100;
            black.bettercannon = true;
            //bullet.damageMultiplier = 2f;
            Destroy(gameObject);
        }

    }
}
