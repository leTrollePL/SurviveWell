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

    // Update is called once per frame
    public override void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            
            Vector3 direction = getShortestPath();
            if (direction.x > 0)
                this.GetComponent<SpriteRenderer>().flipX = false;
            else
                this.GetComponent<SpriteRenderer>().flipX = true;
            if (shotTimer == shotReset)
            {


                Vector2 diff = new Vector2(direction.x, direction.y);
               // diff = diff / Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
              
              
                eBullet.xDiff = direction.x/10;
                eBullet.yDiff = direction.y/10;
                GameObject BulletClone = Instantiate(Bullet, GetComponent<Transform>().transform.position, Quaternion.identity);
                BulletClone.SetActive(true);
                Debug.Log("shoot");
                shotTimer = 0;
            }
            if (direction.magnitude > 5)
            {
                direction /= 45 * direction.magnitude;
            }
            else
            {
                direction /= -45 * direction.magnitude;
            }
            GetComponent<Transform>().position += direction;
            shotTimer++;
           
        }
    }
}
