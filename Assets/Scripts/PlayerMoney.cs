using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public int money = 0;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }

    public void setMoney(int x)
    {
        money = x;
    }

    public int currentMoney()
    {
        return money;
    }

    public void SubbMoney(int moneyToSubb)
    {
        if (money - moneyToSubb < 0)
        {
            Debug.Log("Money is already 0");
        }
        else
        {
            money -= moneyToSubb;
        }
    }
}
