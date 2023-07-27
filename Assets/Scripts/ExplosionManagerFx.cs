using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManagerFx : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    private Clip clip;

    [Header("Prefab")]
    [SerializeField]
    private GameObject prefab;

    public static ExplosionManagerFx Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void Create(Vector3 position, Quaternion rotation)
    {
        Instantiate(prefab, position, rotation);

        //audio
        AudioManager.PlayClip(clip);
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip.audio;
        audioSource.volume = clip.volume;

        audioSource.Play();

        Destroy(newGameObject, clip.audio.length);
    }
}
