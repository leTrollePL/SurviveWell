using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float xDiff=0.1f, yDiff=0.1f;
    public GameObject Bullet;
    public GameObject Black;
    [SerializeField] float damage = 25f;
    public float damageMultiplier = 1f;

    //  public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            Bullet.transform.position =new Vector3 (Bullet.transform.position.x + xDiff/20, Bullet.transform.position.y+yDiff/20 , Bullet.transform.position.z);
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if(collidingObject.gameObject.layer != 10)
        {
            if(collidingObject.gameObject.layer == 9)
            {
                var health = Black.GetComponent<Health>();
                Black.GetComponent<PlayerMoney>().SubbMoney(5);
                if (health != null)
                {
                    health.DealDamage(damage*damageMultiplier);
                }
            }
            else
            {
                var health = collidingObject.GetComponent<Health>();
                if (health != null)
                {
                    health.DealDamage(damage*damageMultiplier);
                }
            }
            
            
        }

        //if (collidingObject.gameObject.layer == 13)
        //{
        //    Debug.Log("Bullet got deflected");
        //    Destroy(gameObject);
        //}

    }


}
