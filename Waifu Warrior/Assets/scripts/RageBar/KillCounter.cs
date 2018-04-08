using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour {

    public TMP_Text KilledNum; //Screen Text
    private string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    void Start () {
        WrathManager.Killed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        string KilledString = WrathManager.Killed.ToString();
        foreach(string n in num)
        {
            if(n == KilledString)
            {
                KilledString = "0" + KilledString;
            }
        }
        KilledNum.text = KilledString;
	}
}
