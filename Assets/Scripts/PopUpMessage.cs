using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpMessage : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUptext;

    public void  PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUptext.text = text;
        animator.SetTrigger("pop");
    }
}
