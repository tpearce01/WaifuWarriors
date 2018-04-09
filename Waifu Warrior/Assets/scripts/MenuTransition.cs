using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour {

    public GameObject QuitApplication;
    public GameObject FirstTimeScreen;
	// Use this for initialization
	void Start () {
        if(!PlayerPrefs.HasKey("NotFirstTime"))
        {
            FindObjectOfType<AudioManager>().MuiscOn();
            FindObjectOfType<MusicManager>().MuiscOn();
            PlayerPrefs.SetInt("AudioSound", 1);
            PlayerPrefs.SetInt("MusicSound", 1);
            FirstTimeScreen.SetActive(true);
            GameManager.gameManager.AddMoney(40);   
             FindObjectOfType<AudioManager>().Play("CashBell");
            //PlayerPrefs.DeleteKey("NotFirstTime");
            PlayerPrefs.SetInt("NotFirstTime", 0);
        }
        
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication.SetActive(true);
        }
		
	}
}
