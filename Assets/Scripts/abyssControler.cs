using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abyssControler : MonoBehaviour
{
    [SerializeField] float x = 6f;
    [SerializeField] float y = 16f;
    public GameController Gcontroller;
    [SerializeField] float damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = new Vector2(x, y);

            var health = Gcontroller.WController.GetComponent<Health>();
            health.DealDamage(damage);

        }
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.transform.position = new Vector2(x, y);
            var health = Gcontroller.BController.GetComponent<Health>();
            health.DealDamage(damage);
        }

    }
}
