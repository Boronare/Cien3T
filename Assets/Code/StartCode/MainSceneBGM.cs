using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneBGM : MonoBehaviour {

    private AudioSource audio;
    public AudioClip jumpSound;
    void Start(){
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

    }
    void Update(){
    this.audio.Play();
    }
}

