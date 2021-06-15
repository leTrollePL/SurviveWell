using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFixedEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int speedConstraint = 60;
    public GameController GController;
    // Update is called once per frame
    public void Update()
    {
        Renderer r = GetComponent<Renderer>();
        if (r.isVisible)
        {
          
            Vector3 direction = getShortestPath();
           
            direction /= speedConstraint * direction.magnitude;
            GetComponent<Transform>().position += direction;
        }
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
}
