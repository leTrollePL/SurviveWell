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
    public Vector3 predict;
    public int directionChangeTimer = 0;
    public int directionChangeReset = 5000;
    public bool speedBump = false;
    public float bodySize = 0.25f;
    public int bodyLength = 11;
    public GameObject GGhostPrefab;
    public GameObject Gcontroler;

    // Start is called before the first frame update
    public void Start()
    {
       // coordinates.Add(directionChoice);
        for (int i=0;i<bodyLength;i++)
        {
            body.Add(bodyPrefab);
            body[i]=Instantiate(body[i], GetComponent<Transform>().transform.position, Quaternion.identity);
        }
        body.Add ( Instantiate(Tail, GetComponent<Transform>().transform.position, Quaternion.identity));
        directionChoice = new Vector3(-speed, 0, 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
        body[body.Count-1].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
        predictDirection(gameObject.transform.position+1000*directionChoice);
        this.GetComponent<Health>().maxHealth = this.GetComponent<Health>().AktualneHP();
        for (int i = 0; i < 4; i++)
        {
            body[i].SetActive(false);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (directionChangeTimer < directionChangeReset)
        {
            gameObject.transform.position += directionChoice;
          
            if (  directionChangeTimer % (directionChangeReset / 16 )==0)
            {
                coordinates.Insert(0, directionChoice);
                while (coordinates.Count > body.Count)
                {
                    coordinates.RemoveAt(body.Count);
                }
            }

          
            Vector3 targ = gameObject.transform.position;
            targ.z = 0f;

            Vector3 objectPos = body[0].transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            body[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            targ = gameObject.transform.position+ ((directionChangeReset- directionChangeTimer)*directionChoice+ 50* predict);
            targ.z = 0f;
            objectPos = gameObject.transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle ) ) ;

            for (int i=0;i<coordinates.Count;i++)
            {
                body[i].transform.position += coordinates[i];
            }
            for (int i = 1; i < coordinates.Count; i++)
            {
                targ = body[i - 1].transform.position;
                targ.z = 0f;

                objectPos = body[i].transform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;

               

                angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                body[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }


            directionChangeTimer++;
        }
        else
        {
          //  coordinates.Insert(0,directionChoice);
            directionChoice = predict;
            predictDirection(gameObject.transform.position+1000* directionChoice);
            directionChangeTimer = 0;
            while (coordinates.Count > body.Count)
            {
                coordinates.RemoveAt(body.Count);
            }

            GameObject ghostie = Instantiate(GGhostPrefab, GetComponent<Transform>().transform.position, Quaternion.identity);

            ghostie.GetComponent<FlyingFixedEnemy>().GController = GController;
        }

        if (gameObject.GetComponent<Health>().AktualneHP() <= 0)
        {
            for (int i = 0; i < body.Count; i++)
                Destroy(body[i]);
            Destroy(gameObject);
        }
        
            


    }

    public int getRotation(Vector3 vec)
    {
        int rotationMultiplier;
        if (vec.x < 0)
        {
            rotationMultiplier = 0;
        }
        else if (vec.y < 0)
            rotationMultiplier = 1;
        else if (vec.x > 0)
            rotationMultiplier = 2;
        else
            rotationMultiplier = 3;
        return rotationMultiplier;
    }
    
 
    public void predictDirection(Vector3 position)
    {
        List<Vector3> possiblePaths = new List<Vector3>();
        if (position.x > 235.0 && directionChoice != new Vector3(speed, 0, 0))
            possiblePaths.Add(new Vector3(-speed, 0, 0));
        else
             if (position.x < 325.0 && directionChoice != new Vector3(-speed, 0, 0))
            possiblePaths.Add(new Vector3(speed, 0, 0));
        if (position.y > 165.0 && directionChoice != new Vector3(0, speed, 0))
            possiblePaths.Add(new Vector3(0, -speed, 0));
        else
            if (position.y < 215.0 && directionChoice != new Vector3(0, -speed, 0))
            possiblePaths.Add(new Vector3(0, speed, 0));
        System.Random rand = new System.Random();
        predict = possiblePaths[rand.Next(possiblePaths.Count)];

    }


}
