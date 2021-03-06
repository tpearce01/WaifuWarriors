﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour {


    public TMP_Text timerText;
    //private float StartTime;
    private float time;
    private float best;
    public Text gamescore;
    public Text highscore;

    public Text killscore;
    public Text Bestkill;
    
    private string[] num = {"0", "1","2", "3", "4", "5", "6", "7", "8", "9"}; //Makes the timer consistent size.
	// Use this for initialization
	void Start () {
        
        time = 0;
        

        best = PlayerPrefs.GetFloat("Highscore");
        string Bestminutes = ((int)best / 60).ToString();
        string Bestseconds = (best % 60).ToString("f0");
        highscore.text = Bestminutes + ':' + Bestseconds;
        //highscore.text = PlayerPrefs.GetFloat("Highscore").ToString("f2");
        gamescore.text = PlayerPrefs.GetFloat("Gamescore").ToString("f2");
        Bestkill.text = PlayerPrefs.GetInt("HighKill").ToString();
	}

    // Update is called once per frame
    void Update () {
        
        
        time += Time.deltaTime;
        string minutes = ((int) time / 60).ToString();
        string seconds = (time % 60).ToString("f0");
        foreach(string n in num)
        { if (n == seconds)
            {
                seconds = "0" + seconds;
            }
        }
        timerText.text = minutes + ':' + seconds;
 

        if (time > PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", time);
            highscore.text = timerText.text;
        }
        PlayerPrefs.SetFloat("Gamescore", time);
        gamescore.text = timerText.text;

        if( WrathManager.Killed > PlayerPrefs.GetInt("HighKill", 0))
        {
            PlayerPrefs.SetInt("HighKill", WrathManager.Killed);
            Bestkill.text = WrathManager.Killed.ToString();
        }
        PlayerPrefs.SetInt("GameKill", WrathManager.Killed);
        killscore.text = WrathManager.Killed.ToString();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.DeleteKey("Gamescore");

    }


}
