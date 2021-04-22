using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastControler : MonoBehaviour
{
    public GameObject Black;
    [SerializeField] float damage = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.layer != 10)
        {
            if (collidingObject.gameObject.layer == 9)
            {
                var health = Black.GetComponent<Health>();
                Black.GetComponent<PlayerMoney>().SubbMoney(5);
                if (health != null)
                {
                    health.DealDamage(damage);
                }
            }
            else
            {
                var health = collidingObject.GetComponent<Health>();
                if (health != null)
                {
                    health.DealDamage(damage);
                }
            }


        }
    }
}
