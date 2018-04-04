using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockButton : MonoBehaviour {

    public int price;
    public Button Unlock;
    public Text LetterPrice;
    public int ID; //know which waifu
	// Use this for initialization
	void Start () {

        LetterPrice.text = price.ToString();
        
        
	}
	
    public void BuyCharacter()
    {
        if (ID == 1)
        {
            GameManager.gameManager.SubtractMoney(price);
            PersistentDataManager.BuyWaifu(Waifu.Sora);
        }
        else if (ID == 2)
        {
            GameManager.gameManager.SubtractMoney(price);
            PersistentDataManager.BuyWaifu(Waifu.Nana);
        }
        else if (ID == 3)
        {
            GameManager.gameManager.SubtractMoney(price);
            PersistentDataManager.BuyWaifu(Waifu.Yellow);
        }
        else if (ID == 4)
        {
            GameManager.gameManager.SubtractMoney(price);
            PersistentDataManager.BuyWaifu(Waifu.Rival);
        }
    }
	// Update is called once per frame
	void Update () {
        if (GameManager.gameManager.CheckMoney(price)) //money cost param
        {
            Unlock.interactable = true;

        }
        else if(!GameManager.gameManager.CheckMoney(price))
        {
            Unlock.interactable = false;
        }
    }
}
