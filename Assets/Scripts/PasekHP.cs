using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasekHP : MonoBehaviour
{

    WhiteController white;
    BlackController black;

    void Awake()
    {
        white = FindObjectOfType<WhiteController>();
        black = FindObjectOfType<BlackController>();
    }

    public float currentHP;


    public Slider slider;

    public void Start()
    {
        slider.value = 100f;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    void Update()
    {
        currentHP = white.GetComponent<Health>().AktualneHP();
        slider.value = currentHP;
    }
}
