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
            direction /= 50 * direction.magnitude;
            GetComponent<Transform>().position+=direction;
        }
    }
}
