using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TriggerEventScript : MonoBehaviour{

    public static int coinNr = 0;

    public UnityEvent playerEnteredTriggerEvent;
    public UnityEvent playerEnteredColliderEvent;

    private GameObject latestColObj;
    private Vector3 latestPos;
    private GameObject latestCreatedGameObject;

    void OnTriggerEnter2D(Collider2D col){
        latestPos = col.transform.position;
        latestColObj = col.gameObject;

        if(col.gameObject.tag == "Player"){
            playerEnteredTriggerEvent.Invoke();
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        latestPos = col.transform.position;
        latestColObj = col.gameObject;

        if(col.gameObject.tag == "Player"){
            playerEnteredColliderEvent.Invoke();
            return;
        }
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

    public void ActivateGameObject(GameObject toActivate){
        if(toActivate)
            toActivate.SetActive(true);
    }

    public void DeActivateGameObject(GameObject toDeActivate){
        if(toDeActivate)
            toDeActivate.SetActive(false);
    }

    public void CreateGameObject(GameObject createThis){
        if(createThis)
            latestCreatedGameObject = Instantiate(createThis, latestPos, Quaternion.identity);
    }

    public void DeleteGameObjectAfterTime(float time){
        if(latestCreatedGameObject)
            Destroy(latestCreatedGameObject, time);
    }

    public void LoadAnotherScene(int sceneNr){
        SceneManager.LoadScene(sceneNr, LoadSceneMode.Single);
    }

    public void StopVerticalForce(){
        if(!latestColObj || !latestColObj.GetComponent<Rigidbody2D>())
            return;

        Vector2 velo = latestColObj.GetComponent<Rigidbody2D>().velocity;
        velo.y = 0f;
        latestColObj.GetComponent<Rigidbody2D>().velocity = velo;
    }

    public void AddForceToObjectX(float strength){
        if(latestColObj && latestColObj.GetComponent<Rigidbody2D>())
            latestColObj.GetComponent<Rigidbody2D>().AddForce(Vector2.right*strength, ForceMode2D.Impulse);
    }

    public void AddForceToObjectY(float strength){
        if(latestColObj && latestColObj.GetComponent<Rigidbody2D>())
            latestColObj.GetComponent<Rigidbody2D>().AddForce(Vector2.up*strength, ForceMode2D.Impulse);
    }

    public void SetCoinNrToValue(int value){
        coinNr = value;
    }

    public void IncreaseCoinNr(int coinsToAdd){
        coinNr += coinsToAdd;
    }

    public void WriteCoinNrToText(TMPro.TextMeshProUGUI textMeshPro){
        if(textMeshPro)
            textMeshPro.text = ""+coinNr;
    }

    public void PlayAnimation(string stateName){
        if(latestColObj && latestColObj.GetComponent<Animator>())
            latestColObj.GetComponent<Animator>().Play(stateName);
    }

}
