using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEater : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collidingObject)
    {
       // Debug.Log(collidingObject.gameObject.layer);
        if (collidingObject.gameObject.layer == 11)
        {
            Debug.Log("Bullet got eaten");
           Destroy(collidingObject.gameObject);


        }

       


    }
}
