using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    public GameObject white;
    public GameObject black;
    public GameObject dane;

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
        //white = FindObjectOfType<WhiteController>();
        //black = FindObjectOfType<BlackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 9)
        {
            dane = GameObject.Find("DaneOGrze");
            white = GameObject.Find("White");
            black = GameObject.Find("Black");

            var dane2 = dane.GetComponent<DaneOGrze>();

            var healthBialy = white.GetComponent<Health>();
            var healthCzarny = black.GetComponent<Health>();

            var hajsBialy = white.GetComponent<PlayerMoney>();
            var hajsCzarny = black.GetComponent<PlayerMoney>();

            var bialy = white.GetComponent<WhiteController>();
            var czarny = black.GetComponent<BlackController>();

            dane2.hpBialy = healthBialy.AktualneHP();
            dane2.hajsBialy = hajsBialy.currentMoney();
            dane2.buffBialy = bialy.betterjump;

            dane2.hpCzasrny = healthCzarny.AktualneHP();
            dane2.hajsCzasrny = hajsCzarny.currentMoney();
            dane2.buffCzarny = czarny.betterjump;


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
