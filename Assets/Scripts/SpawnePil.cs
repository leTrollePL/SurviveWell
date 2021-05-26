using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnePil : MonoBehaviour
{
    public GameObject pila;
    [SerializeField] float czasSpawnuWSek = 0f;
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
    float czasa;
    // Start is called before the first frame update
    void Start()
    {
        czasa = czasSpawnuWSek;
    }

    // Update is called once per frame
    void Update()
    {

        czasSpawnuWSek -= Time.deltaTime;

        if (czasSpawnuWSek <= 0)
        {
            Instantiate(pila, new Vector2(x, y), Quaternion.identity);
            czasSpawnuWSek = czasa;
        }
    }

}

