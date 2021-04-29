using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameController GController;
    public GameObject enemyObject;
    public int damage = 20;
    public int moneyWorth = 5;
    public float speed = 0.0f;
    public float distance = 2f;
    public Transform GroundDetection;
    public bool movingRight;
    public int jumpTimer = 1500, jumpCD = 1500;
    public int pounceReset = 750, pounceTimer = 0;


    public virtual void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            Vector3 direction = getShortestPath();


            if (direction.magnitude < 10)
            {
                if (direction.x > 0)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else
                    transform.eulerAngles = new Vector3(0, 0, 0);
                RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance / 100);
                if (groundInfo.collider == true && groundInfo.collider.gameObject.layer == 8)
                {
                    pounceTimer++;

                    if (pounceTimer >= pounceReset)
                    {
                        pounceTimer = 0;
                        this.GetComponent<Rigidbody2D>().AddForce(new Vector3(direction.x, direction.y + 0.5f, 0) / 5, ForceMode2D.Impulse);
                    }
                    else if (pounceTimer > pounceReset - 30)
                    {
                        this.GetComponent<Transform>().Rotate(0, 0, pounceTimer - pounceReset);
                    }
                    else if (pounceTimer > pounceReset - 60)
                    {
                        this.GetComponent<Transform>().Rotate(0, 0, pounceReset - 60 - pounceTimer);
                    }
                }
            }
            else
            {
                RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance);
                if (groundInfo.collider == false)
                {
                    changeDirection();
                }
                else
                {

                    RaycastHit2D jumpInfo = Physics2D.Raycast(GroundDetection.position, Vector2.left, distance);
                    if (jumpInfo.collider == true)
                        if (groundInfo.collider == true && jumpInfo.collider.gameObject.layer == 8 && jumpTimer == jumpCD)
                        {
                            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up / 2f, ForceMode2D.Impulse);
                            jumpTimer = 0;
                        }

                    RaycastHit2D wallinfo = Physics2D.Raycast(GroundDetection.position, Vector2.left, distance / 1000);
                    if (wallinfo.collider == true && wallinfo.collider.gameObject.layer == 8)
                    {
                        changeDirection();
                    }

                }
                if (movingRight == false)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    this.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x - speed, this.GetComponent<Transform>().position.y, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    this.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x + speed, this.GetComponent<Transform>().position.y, 0);
                }

                //if (groundInfo.collider == true)
                //{
                //    Debug.Log("Ground under feet");
                //}
            }
            if (jumpTimer < jumpCD)
                jumpTimer++;
        }
    }
    public void changeDirection()
    {
        if (movingRight == true)
            movingRight = false;
        else
            movingRight = true;
    }

    public virtual Vector3 getShortestPath()
    {
        Vector3 vector = new Vector3();
        double distW = Vector3.Distance(GController.WController.transform.position, GetComponent<Transform>().position);
        double distB = Vector3.Distance(GController.BController.transform.position, GetComponent<Transform>().position);

        if (distB > distW)
            vector = (GController.WController.transform.position - GetComponent<Transform>().position);
        else
            vector = (GController.BController.transform.position - GetComponent<Transform>().position);

        return vector;
    }

    public void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.layer == 9 && GController.WController.GetComponent<WhiteController>().hittable)
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
