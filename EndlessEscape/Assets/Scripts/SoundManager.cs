using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Coin,Jump,highScore;
    public static AudioClip  coinSound,jumpSound,hScoreSound;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc=GetComponent<AudioSource>();
        jumpSound = Jump;
        coinSound = Coin;
        hScoreSound = highScore;
    }

    public static void PlaySound(string soundClip)
    {
        switch (soundClip)
        {
            case "Coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "highScore":
                audioSrc.PlayOneShot(hScoreSound);
                break;

        }

    }
}
