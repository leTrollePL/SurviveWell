using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    public override void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            Vector3 direction = getShortestPath();
            if (direction.x > 0)
                this.GetComponent<SpriteRenderer>().flipX = true;
            else
                this.GetComponent<SpriteRenderer>().flipX = false;
            direction /= 50 * direction.magnitude;
            GetComponent<Transform>().position+=direction;
        }
    }
}
