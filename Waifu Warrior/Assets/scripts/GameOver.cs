using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    //[SerializeField]private string MenuName;

	void Start () {
        FindObjectOfType<MusicManager>().Stop("GameSong");
        

        Time.timeScale = 0.0f;	
	}

    void Update()
    {
        FindObjectOfType<AudioManager>().Stop("Siren");
        FindObjectOfType<AudioManager>().Stop("Fire");
        FindObjectOfType<AudioManager>().Stop("Explosion");
        FindObjectOfType<AudioManager>().Stop("Clock");
        FindObjectOfType<AudioManager>().Stop("Whistle");
        FindObjectOfType<AudioManager>().Stop("ChargedWrath");
        FindObjectOfType<AudioManager>().Stop("Wave");
        FindObjectOfType<AudioManager>().Stop("coin");
        FindObjectOfType<AudioManager>().Stop("electricwave");
        FindObjectOfType<AudioManager>().Stop("rain");
        FindObjectOfType<AudioManager>().Stop("bubble");
        FindObjectOfType<AudioManager>().Stop("holy");
        FindObjectOfType<AudioManager>().Stop("sparklight");

        Time.timeScale = 0.0f;
    }



}
