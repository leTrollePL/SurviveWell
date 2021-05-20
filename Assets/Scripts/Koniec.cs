using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koniec : MonoBehaviour
{
    
    public void KoniecKlik()
    {
        Debug.Log("Wyszedles z gry");
        Application.Quit();
    }
}
