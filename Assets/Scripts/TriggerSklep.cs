using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSklep : MonoBehaviour
{
    // Start is called before the first frame update
    WhiteController white;
    BlackController black;

    [SerializeField] private SklepoweUI sklepoweUI;

    [SerializeField] private SklepoweUI2 sklepoweUI2;

    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            Debug.Log("Biały_W_skepie");
            gameObject.SetActive(true);
            sklepoweUI.Show();
        }

        if (collision.gameObject.name == "Black")
        {
            Debug.Log("Czarny_W_skepie");
            gameObject.SetActive(true);
            sklepoweUI2.Show();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "White")
        {
            Debug.Log("Biały_Wyszedl");
            sklepoweUI.Hide();
        }

        if (collision.gameObject.name == "Black")
        {
            Debug.Log("Czarny_Wyszedl");
            sklepoweUI2.Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
