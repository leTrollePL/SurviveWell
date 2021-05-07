using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    // Start is called before the first frame update

    public int speedConstraint = 60;
    public Transform UpPoint, DownPoint, LeftPoint, RightPoint;
    // Update is called once per frame
    public override void Update()
    {
        Renderer r = GetComponent<Renderer>();
        if (r.isVisible)
        {
            if(r.material.color.a>0)
            {
                Color color = r.material.color;
                r.material.color = new Color(color.r,color.g,color.b,color.a-0.001f);
            }
            Vector3 direction = getShortestPath();
            if (direction.x > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                RaycastHit2D rightInfo = Physics2D.Raycast(RightPoint.position, Vector2.right, distance / 100);
                if (rightInfo.collider == true && rightInfo.collider.gameObject.layer == 8)
                {
                    direction.x = 0;
                }
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
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
        }
    }
}
