using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;
  
    [SerializeField] GameObject fallingPlatform;
    [SerializeField] float czasOdrodzeniaPlatformy = 3f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(fallingPlatform, new Vector2(1f,1f), fallingPlatform.transform.rotation);

    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(czasOdrodzeniaPlatformy);
        Instantiate(fallingPlatform, spawnPosition, fallingPlatform.transform.rotation);
    }
}
