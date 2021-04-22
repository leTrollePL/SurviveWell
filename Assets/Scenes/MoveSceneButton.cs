using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveSceneButton : MonoBehaviour
{
    public void NewGameTest(string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }
}
