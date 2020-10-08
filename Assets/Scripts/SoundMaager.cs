using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaager : MonoBehaviour
{
    public static SoundMaager instance;
    [SerializeField]
    private AudioSource SoundFX;

    [SerializeField]
    private AudioClip landclip, gameoverclip;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LandSound()
    {
        SoundFX.clip = landclip;
        SoundFX.Play();
    }

    public void GameoverSound()
    {
        SoundFX.clip = gameoverclip;
        SoundFX.Play();
    }
}
