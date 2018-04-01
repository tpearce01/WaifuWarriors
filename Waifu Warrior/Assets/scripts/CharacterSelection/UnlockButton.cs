using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockButton : MonoBehaviour {

    public int price;
    public Button Unlock;
    public Text LetterPrice;
	// Use this for initialization
	void Start () {

        LetterPrice.text = price.ToString();
        if (GameManager.gameManager.CheckMoney(price)) //money cost param
        {
            Unlock.interactable = true;
            GameManager.gameManager.SubtractMoney(price);
            PersistentDataManager.BuyWaifu(Waifu.Emiko);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
