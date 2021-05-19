using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy1 : Enemy
{
    public List<GameObject> body = new List<GameObject>();
    public GameObject bodyPrefab;
    public GameObject Tail;
    public List<Vector3> coordinates;

    public Vector3 directionChoice;
    public int directionChangeTimer = 0;
    public int directionChangeReset = 5000;
    // Start is called before the first frame update
    public void Start()
    {
       // coordinates.Add(directionChoice);
        for (int i=0;i<5;i++)
        {
            body.Add(bodyPrefab);
            body[i]=Instantiate(body[i], GetComponent<Transform>().transform.position, Quaternion.identity);
        }
        body.Add ( Instantiate(Tail, GetComponent<Transform>().transform.position, Quaternion.identity));
        directionChoice = new Vector3(-speed, 0, 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
        body[body.Count-1].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (directionChangeTimer < directionChangeReset)
        {
            gameObject.transform.position += directionChoice;
          
            if (directionChangeReset / 2 == directionChangeTimer)
            {
                coordinates.Insert(0, directionChoice);
                if (coordinates.Count > 6)
                {
                    coordinates.RemoveAt(6);
                }
            }
            for (int i=0;i<coordinates.Count;i++)
            {
                body[i].transform.position += coordinates[i];
            }
           
            directionChangeTimer++;
        }
        else
        {
            coordinates.Insert(0,directionChoice);
            changeDirection();
            directionChangeTimer = 0;
            if (coordinates.Count > 6)
            {
                coordinates.RemoveAt(6);
            }
            
        }
    }
    
    public override void changeDirection()
    {
        List<Vector3> possiblePaths = new List<Vector3>();
        if (gameObject.transform.position.x>235.0 && directionChoice!= new Vector3(speed, 0, 0))
            possiblePaths.Add(new Vector3(-speed, 0, 0));
        else
             if (gameObject.transform.position.x < 325.0 && directionChoice != new Vector3(-speed, 0, 0))
            possiblePaths.Add(new Vector3(speed, 0, 0));
        if (gameObject.transform.position.y > 165.0 && directionChoice != new Vector3(0, speed, 0))
            possiblePaths.Add(new Vector3(0, -speed, 0));
        else
            if (gameObject.transform.position.y < 215.0 && directionChoice != new Vector3(0, -speed, 0))
            possiblePaths.Add(new Vector3(0, speed, 0));
        System.Random rand = new System.Random();
        directionChoice = possiblePaths[rand.Next(possiblePaths.Count)];
        
    }
   

}
