using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaneOGrze : MonoBehaviour
{

    public float hpBialy = 75;
    public float hpCzasrny = 75;

    public int hajsBialy = 0;
    public int hajsCzasrny = 0;

    public bool buffBialy = false;
    public bool buffCzarny = false;

    public double poziomGlosnosci;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHpBialy()
    {
        return hpBialy;
    }
    public float getHpCzasrny()
    {
        return hpCzasrny;
    }

    public double getHajsBialy()
    {
        return hajsBialy;
    }
    public double getHajsCzasrny()
    {
        return hajsCzasrny;
    }
    public bool getBuffBialy()
    {
        return buffBialy;
    }

    public bool getBuffCzarny()
    {
        return buffCzarny;
    }



    /// <summary>
    /// set
    /// </summary>
    /// <returns></returns>


    public void setHpBialy(float x)
    {
        hpBialy = x;
    }
    public void setHpCzasrny(float x)
    {
         hpCzasrny = x;
    }

    public void setHajsBialy(int x)
    {
         hajsBialy = x;
    }
    public void setHajsCzasrny(int x)
    {
        hajsCzasrny = x;
    }
    public void setBuffBialy(bool x)
    {
         buffBialy = x;
    }

    public void setBuffCzarny(bool x)
    {
         buffCzarny = x;
    }
}
