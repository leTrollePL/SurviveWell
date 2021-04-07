using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameController GController;
    public GameObject enemyObject;
    
    void Update()
    { 
        if (GetComponent<Renderer>().isVisible)
        {
            Vector3 direction = getShortestPath();
            direction /= 5 *direction.magnitude;
            GetComponent<Rigidbody2D>().AddForce(direction);
        }
    }

    Vector3 getShortestPath()
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

}
