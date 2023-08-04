using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_script : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(RandomClip());   
    }
    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
