using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TextMeshProUGUI textdisplay;


    WhiteController white;
    BlackController black;

    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    public int score;

    
    // Start is called before the first frame update
    void Start()
    {
        textdisplay = GetComponent<TextMeshProUGUI>();
        score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        score = black.GetComponent<PlayerMoney>().currentMoney();
        textdisplay.text = score.ToString();
        // score = player.GetComponents<PlayerMoney>().
    }
}
