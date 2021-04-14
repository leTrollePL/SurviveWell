using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float CzasZniknięcia = 2f;
    [SerializeField] float CzasDoSpadku = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("step on");
        if (collision.gameObject.tag == "Player")
        {
            PlatformManager.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
            Invoke("Drop", CzasDoSpadku);
            Destroy(gameObject, CzasZniknięcia);
        }
    }

    void Drop()
    {
        rb.isKinematic = false;
    }
}
