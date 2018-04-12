using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
    public AudioClip otherClip;


    private void Update()
    {

    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        AudioSource audio = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
       
        //audio.Play();
        //var volume = audio.volume;
        //audio.volume = Mathf.Lerp(audio.volume, 0.01f, Time.time/2);
        yield return new WaitForSeconds(0);
        audio.clip = otherClip;
        
        audio.Play();
        //audio.volume = Mathf.Lerp(0f, 0.5f, Time.time);
    }
}

