using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static void PlayClip(Clip clip)
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip.audio;
        audioSource.volume = clip.volume;

        audioSource.Play();

        Destroy(newGameObject, clip.audio.length);
    }
}
