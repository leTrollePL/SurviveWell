using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiomanagerScript : MonoBehaviour
{
    public static AudioClip shotSound, deatchSound, playerhitSound, meeleSound, reloadSound;
    static AudioSource AudioScrc;

    // Start is called before the first frame update
    void Start()
    {
        playerhitSound = Resources.Load<AudioClip>("playerhit");
        shotSound = Resources.Load<AudioClip>("fire");
        deatchSound = Resources.Load<AudioClip>("plauerdie");
        reloadSound = Resources.Load<AudioClip>("reloadSound");
        meeleSound = Resources.Load<AudioClip>("meleesound");

        AudioScrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string Clip){


        switch (Clip) {

            case "playerhit":
                AudioScrc.PlayOneShot(playerhitSound);
                    break;
            case "fire":
                AudioScrc.PlayOneShot(shotSound);
                break;
            case "deatchSound":
                AudioScrc.PlayOneShot(deatchSound);
                break;
            case "reloadSound":
                AudioScrc.PlayOneShot(reloadSound);
                break;
            case "meeleSound":
                AudioScrc.PlayOneShot(meeleSound);
                break;
        }

}
}
