using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameController GController;
    public GameObject enemyObject;
    public int damage=20;

    public virtual void Update()
    { 
        if (GetComponent<Renderer>().isVisible)
        {
            Vector3 direction = getShortestPath();
            direction =direction/ ( 7 * Mathf.Sqrt(direction.x*direction.x+direction.y*direction.y));
            GetComponent<Rigidbody2D>().AddForce(direction);
        }
    }

    public Vector3 getShortestPath()
    {
        Vector3 vector = new Vector3();
        double distW = Vector3.Distance(GController.WController.transform.position, GetComponent<Transform>().position);
        double distB = Vector3.Distance(GController.BController.transform.position, GetComponent<Transform>().position);

        if (distB>distW)
        vector = (GController.WController.transform.position - GetComponent<Transform>().position);
        else
            vector = (GController.BController.transform.position - GetComponent<Transform>().position);

        return vector;
    }

   public void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.layer == 9&& GController.WController.GetComponent<WhiteController>().hittable)
        {
            var health = GController.WController.GetComponent<Health>();
            if (health != null)
            {
                health.DealDamage(damage);
            }
            Vector2 diff = new Vector2(GController.WController.transform.position.x - GetComponent<Transform>().position.x, GController.WController.transform.position.y - GetComponent<Transform>().position.y);
            diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
            GController.WController.GetComponent<Rigidbody2D>().AddForce(GController.WController.transform.up * diff.y * 160);
            GController.WController.GetComponent<WhiteController>().movespeed += diff.x * 0.07f;
        }
        if (collidingObject.gameObject.layer == 10)
            {
                var health = GController.BController.GetComponent<Health>();
                if (health != null)
                {
                    health.DealDamage(damage);
                }
            Vector2 diff = new Vector2(GController.BController.transform.position.x - GetComponent<Transform>().position.x, GController.BController.transform.position.y - GetComponent<Transform>().position.y);
            diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
            GController.BController.GetComponent<Rigidbody2D>().AddForce(GController.BController.transform.up * diff.y * 160);
            GController.BController.GetComponent<BlackController>().movespeed += diff.x * 0.07f;
        }
           



      

    }

}
