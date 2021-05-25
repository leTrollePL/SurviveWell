using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    WhiteController white;
    BlackController black;

    public int iLeveltoLoad;
    public string sLeveltoLoad;

    public bool useInttoLoadLVL = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 9)
        {
            loadScene();

        }
    }

    void loadScene()
    {
        if(useInttoLoadLVL)
        {
            SceneManager.LoadScene(iLeveltoLoad);
        }
        else
        {
            SceneManager.LoadScene(sLeveltoLoad);
        }
    }
}
