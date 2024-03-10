using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour{
    
    public void LoadAnotherScene(int sceneNr){
        SceneManager.LoadScene(sceneNr, LoadSceneMode.Single);
    }
    
    public void PlayAudioClip(AudioClip audioClip){
        if(!audioClip)
            return;

        GameObject g = new GameObject("Audio - "+audioClip.name);
        AudioSource a = g.AddComponent<AudioSource>();
        a.clip = audioClip;

        a.Play();
        Destroy(g, audioClip.length+0.2f);
    }

}
