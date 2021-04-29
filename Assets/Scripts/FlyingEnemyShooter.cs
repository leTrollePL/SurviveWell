using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyShooter : Enemy
{
    // Start is called before the first frame update
    public int shotTimer = 0;
    public int shotReset = 450;
    public GameObject Bullet;
    public EnemyBullet eBullet;
    public int playerDistance = 5;
    public int speedConstraint = 60;
    public Transform UpPoint, DownPoint, LeftPoint, RightPoint;

    // Update is called once per frame
    public override void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {

            Vector3 direction = getShortestPathPlace();
            Vector3 shotDirection = getShortestPath();
            //if (direction.x > 0)
            //    this.GetComponent<SpriteRenderer>().flipX = false;
            //else
            //    this.GetComponent<SpriteRenderer>().flipX = true;
            if (shotTimer == shotReset)
            {


                Vector2 diff = new Vector2(shotDirection.x, shotDirection.y);
                // diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);


                eBullet.xDiff = shotDirection.x / 10;
                eBullet.yDiff = shotDirection.y / 10;
                GameObject BulletClone = Instantiate(Bullet, GetComponent<Transform>().transform.position, Quaternion.identity);
                BulletClone.SetActive(true);
                shotTimer = 0;
            }
            if (direction.x > 0)
            {
                // this.GetComponent<SpriteRenderer>().flipX = true;
                RaycastHit2D rightInfo = Physics2D.Raycast(RightPoint.position, Vector2.right, distance / 100);
                if (rightInfo.collider == true && rightInfo.collider.gameObject.layer == 8)
                {
                    direction.x = 0;
                }
            }
            else
            {
                //  this.GetComponent<SpriteRenderer>().flipX = false;
                RaycastHit2D leftInfo = Physics2D.Raycast(LeftPoint.position, Vector2.right, distance / 100);
                if (leftInfo.collider == true && leftInfo.collider.gameObject.layer == 8)
                {
                    direction.x = 0;
                }
            }
            if (direction.y > 0)
            {
                RaycastHit2D upInfo = Physics2D.Raycast(UpPoint.position, Vector2.right, distance / 100);
                if (upInfo.collider == true && upInfo.collider.gameObject.layer == 8)
                {
                    direction.y = 0;
                }
            }
            else
            {
                RaycastHit2D downInfo = Physics2D.Raycast(DownPoint.position, Vector2.right, distance / 100);
                if (downInfo.collider == true && downInfo.collider.gameObject.layer == 8)
                {
                    direction.y = 0;
                }
            }

            direction /= speedConstraint * direction.magnitude;

            GetComponent<Transform>().position += direction;
            shotTimer++;

        }
    }
    public Vector3 getShortestPathPlace()
    {
        Vector3 vector = new Vector3();
        double distW = Vector3.Distance(GController.WController.transform.position, GetComponent<Transform>().position);
        double distB = Vector3.Distance(GController.BController.transform.position, GetComponent<Transform>().position);

        if (distB > distW)
        {
            double distW1 = Vector3.Distance(new Vector3(GController.WController.transform.position.x + playerDistance, GController.WController.transform.position.y + playerDistance, 0), GetComponent<Transform>().position);
            double distW2 = Vector3.Distance(new Vector3(GController.WController.transform.position.x - playerDistance, GController.WController.transform.position.y + playerDistance, 0), GetComponent<Transform>().position);
            if (distW1 < distW2)
                vector = new Vector3(GController.WController.transform.position.x + playerDistance, GController.WController.transform.position.y + playerDistance, 0) - GetComponent<Transform>().position;
            else
                vector = new Vector3(GController.WController.transform.position.x - playerDistance, GController.WController.transform.position.y + playerDistance, 0) - GetComponent<Transform>().position;
        }
        else
        {
            double distB1 = Vector3.Distance(new Vector3(GController.BController.transform.position.x + playerDistance, GController.BController.transform.position.y + playerDistance, 0), GetComponent<Transform>().position);
            double distB2 = Vector3.Distance(new Vector3(GController.BController.transform.position.x - playerDistance, GController.BController.transform.position.y + playerDistance, 0), GetComponent<Transform>().position);
            if (distB1 < distB2)
                vector = new Vector3(GController.BController.transform.position.x + playerDistance, GController.BController.transform.position.y + playerDistance, 0) - GetComponent<Transform>().position;
            else
                vector = new Vector3(GController.BController.transform.position.x - playerDistance, GController.BController.transform.position.y + playerDistance, 0) - GetComponent<Transform>().position;
        }

        return vector;
    }
}
