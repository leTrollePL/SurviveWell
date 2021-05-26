using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingKolceControler : MonoBehaviour
{
    public float borderLeft = 0;
    public float borderRight = 0;
    public float moveSpeed = 0;
    public GameObject blackPlayer;
    public GameObject whitePlayer;
    bool direction = true;


    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > borderRight)
        {
            direction = false;
        }
        if (transform.position.x < borderLeft)
        {
            direction = true;
        }

        if (direction)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
