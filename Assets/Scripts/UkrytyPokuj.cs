using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkrytyPokuj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Biały/niebieski
        if (Input.GetKey("e") && collision.gameObject.layer == 9)
        {
            Debug.Log("White");
            Destroy(this.gameObject);
        }
        //Czarny/czerwony
        if (Input.GetMouseButtonDown(2) && collision.gameObject.layer == 10)
        {
            Debug.Log("Black");
            Destroy(this.gameObject);
        }
    }
}
