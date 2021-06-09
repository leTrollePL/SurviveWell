using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosaControler : MonoBehaviour
{

    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityTreshold;
    public GameController Gcontroller;
    [SerializeField] float damage = 10f;



    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityTreshold;
        
    }

    

    void Update()
    {

        Push();
    }

    public void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && (body2d.angularVelocity > 0) && body2d.angularVelocity < velocityTreshold)
        {
            body2d.angularVelocity = velocityTreshold;
        }
        else if(transform.rotation.z < 0 && transform.rotation.z < rightPushRange && (body2d.angularVelocity < 0) && body2d.angularVelocity > velocityTreshold * -1) 
        {
            body2d.angularVelocity = velocityTreshold * -1;
        }
    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {

        if (collidingObject.gameObject.layer == 10)
        {
            var health = Gcontroller.BController.GetComponent<Health>();
            if (health != null)
            {
                health.DealDamage(damage);
            }
        }
        else if (collidingObject.gameObject.layer == 9 && Gcontroller.WController.hittable)
        {
            var health = Gcontroller.WController.GetComponent<Health>();
            if (health != null)
            {
                health.DealDamage(damage);
            }
        }
    }


    }
