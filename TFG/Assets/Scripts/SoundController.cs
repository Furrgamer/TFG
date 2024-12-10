using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Fuente de sonido de los botones
    public AudioSource aS_Game;
    // Fuente de sonido de la m�sica
    public AudioSource aS_Music;
    // M�sica
    public AudioClip aC_Game;
    // Botones
    public AudioClip aC_Music;

    void Start()
    {
        PlayMusicStart(aC_Music);
    }

    public void SoundButtons()
    {
        // Toca Sonido de un bot�n
        aS_Game.PlayOneShot(aC_Game);
    }
    public void PlayMusicStart(AudioClip aC)
    {
        aS_Music.Stop();
        // Toca Sonido de la musica
        aS_Music.clip = aC;
        aS_Music.Play();
    }
}
