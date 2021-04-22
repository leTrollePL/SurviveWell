using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    [SerializeField] private string newLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
        }
        //if (collision.gameObject.name == "Black" &&  collision.gameObject.name=="White")
        //{
        //    SceneManager.LoadScene(newLevel);
        //}
    }
}
