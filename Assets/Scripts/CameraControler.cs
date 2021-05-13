using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject Camera;
    public GameObject blackPlayer;
    public GameObject whitePlayer;
    public Camera CCamera;
    private float standardCamera;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        standardCamera = CCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        //Kamera dla obu graczy, jeśli obaj żyją
        if (blackPlayer != null && whitePlayer != null)
        {
            whitePlayer.transform.position = new Vector3((whitePlayer.transform.position.x), whitePlayer.transform.position.y, whitePlayer.transform.position.z);
            float playerXdiff = (whitePlayer.transform.position.x + blackPlayer.transform.position.x) / 2;
            float playerYdiff = (whitePlayer.transform.position.y + blackPlayer.transform.position.y) / 2;
            Camera.transform.position = new Vector3(playerXdiff, playerYdiff, Camera.transform.position.z);
            if (Mathf.Abs(whitePlayer.transform.position.x - blackPlayer.transform.position.x) > 10 && Mathf.Abs(whitePlayer.transform.position.x - blackPlayer.transform.position.x) < 20)
            {
                scale = Mathf.Abs((whitePlayer.transform.position.x - blackPlayer.transform.position.x) / 10f);
            }
            else if (Mathf.Abs(whitePlayer.transform.position.x - blackPlayer.transform.position.x) < 10)
            {
                scale = 1f;
            }
            else
            {
                scale = 2f;
            }
            float scaleY = 1;
            if (Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) > 5 && Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) < 10)
            {
                scaleY = Mathf.Abs((whitePlayer.transform.position.y - blackPlayer.transform.position.y) / 5f);
            }
            else if (Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) < 5)
            {
                scaleY = 1f;
            }
            else
            {
                scale = 2f;
                if (Mathf.Abs(whitePlayer.transform.position.y - blackPlayer.transform.position.y) >30)
                {
                    if (whitePlayer.transform.position.y > blackPlayer.transform.position.y)
                    {
                        blackPlayer.GetComponent<Health>().DealDamage(10);
                        blackPlayer.GetComponent<Transform>().position = whitePlayer.GetComponent<Transform>().position;
                    }
                    else
                    {
                        whitePlayer.GetComponent<Health>().DealDamage(10);
                        whitePlayer.GetComponent<Transform>().position = blackPlayer.GetComponent<Transform>().position;
                    }
                }
            }
            scale = (scale + scaleY) / 2f;
            CCamera.orthographicSize = standardCamera * scale;
        }
        else if (blackPlayer == null)
        {

        }
        else if (whitePlayer == null)
        {

        }
    }
}
