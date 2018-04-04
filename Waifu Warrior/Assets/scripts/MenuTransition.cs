﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour {

    public GameObject FirstTimeScreen;
	// Use this for initialization
	void Start () {
        if(!PlayerPrefs.HasKey("NotFirstTime"))
        {
            FirstTimeScreen.SetActive(true);
            GameManager.gameManager.AddMoney(40);
            Debug.Log("WOOOOW FIRST TME BABBY LETS GOOOOOOO");  
        }
        //PlayerPrefs.DeleteKey("NotFirstTime");
        PlayerPrefs.SetInt("NotFirstTime", 0);
        FindObjectOfType<MusicManager>().Play("MenuSong");
        Time.timeScale = 1f;
        
        FindObjectOfType<MusicManager>().Stop("GameSong");
        FindObjectOfType<AudioManager>().Stop("Tap");
        FindObjectOfType<AudioManager>().Stop("Siren");
        FindObjectOfType<AudioManager>().Stop("Fire");
        FindObjectOfType<AudioManager>().Stop("Clock");
        FindObjectOfType<AudioManager>().Stop("Whistle");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
