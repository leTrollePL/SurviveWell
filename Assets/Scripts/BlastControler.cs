using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastControler : MonoBehaviour
{
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
            var health = collidingObject.GetComponent<Health>();
            if (health != null)
            {
                health.DealDamage(damage);
            }
        }
    }
}
