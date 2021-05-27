using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaControler : MonoBehaviour
{
    WhiteController white;
    BlackController black;
    [SerializeField] float demage = 25f;

    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            var health = white.GetComponent<Health>();
            health.DealDamage(demage);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Black")
        {
            var health = black.GetComponent<Health>();
            health.DealDamage(demage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "kolce")
        {
            Destroy(gameObject);
        }

    }
}
