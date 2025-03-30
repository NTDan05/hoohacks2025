using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundEffects;
    
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.Play();
    }

    public void playSoundEffect(int index)
    {
        if (index < 0 || index >= soundEffects.Length)
        {
            Debug.LogWarning("Sound effect index out of range: " + index);
            return;
        }
        audioSource.PlayOneShot(soundEffects[index]);
    }
}
