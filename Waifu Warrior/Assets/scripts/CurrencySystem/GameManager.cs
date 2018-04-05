using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {


    public static GameManager gameManager;
    [SerializeField] private int Money; //Players Money 

    public TMP_Text moneyText;


	void Awake ()
    {
        gameManager = this;
        PersistentDataManager.LoadData();
    }

	void Start(){
		//Money = Bank.BankCoins;
		
		UpdateUI();
	}
	
	

    public void AddMoney(int amount)
    {
        Money += amount;
        PersistentDataManager.SaveData();
        UpdateUI();
    }

    public void SubtractMoney(int amount)
    {
        Money -= amount;
        PersistentDataManager.SaveData();
        UpdateUI();
    }

    public bool CheckMoney(int amount)
    {
        Debug.Log("Below this");
        Debug.Log(amount);
        if (amount <= Money)
        {
            
            
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
		if (moneyText != null) {
			moneyText.text = Money.ToString ();
		}
    }

	public void SetMoney(int amount){
		Money = amount;
        PersistentDataManager.SaveData();
        UpdateUI ();
	}

	public int GetMoney(){
		return Money;
	}

	void OnApplicationQuit(){
		PersistentDataManager.SaveData ();
	}

	void OnDestroy(){
		PersistentDataManager.SaveData ();
	}
}
