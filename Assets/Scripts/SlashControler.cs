using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashControler : MonoBehaviour
{
    public GameObject White;
    [SerializeField] float damage = 40f;
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

        if (collidingObject.gameObject.layer != 9)
        {
            if (collidingObject.gameObject.layer == 10)
            {
                var health = White.GetComponent<Health>();
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
