using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveSceneButton : MonoBehaviour
{
    private AsyncOperation sceneAsync;
    public GameObject dane;


    public void NewGameTest(string newLevel)
    {


        SceneManager.LoadScene(newLevel);

        //dane = GameObject.Find("DaneOGrze");
        //AsyncOperation scene = SceneManager.LoadSceneAsync(newLevel, LoadSceneMode.Single);
        //scene.allowSceneActivation = false;
        //sceneAsync = scene;

        //while (scene.progress < 0.9f)
        //{
        //    Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
        //}
        //Scene stara = SceneManager.GetActiveScene();

        //Debug.Log(stara.name);

        //sceneAsync.allowSceneActivation = true;
        //Scene sceneToLoad = SceneManager.GetSceneByName(newLevel);
        //if (sceneToLoad.IsValid())
        //{
        //    Debug.Log("Scene is Valid");
        //    SceneManager.MoveGameObjectToScene(dane, sceneToLoad);
        //    SceneManager.SetActiveScene(sceneToLoad);


        //}

    }
}
