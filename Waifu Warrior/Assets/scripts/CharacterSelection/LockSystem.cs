using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSystem : MonoBehaviour {

    public GameObject[] locked_screen;
    // Use this for initialization
    void Start () {
        CharacterLockSystem();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void CharacterLockSystem()
    {
        
        if (!PersistentDataManager.IsWaifuOwned(Waifu.Sora))
        {
            locked_screen[0].SetActive(true);
        }
        else if(PersistentDataManager.IsWaifuOwned(Waifu.Sora))
        {
            locked_screen[0].SetActive(false);
        }

        if (!PersistentDataManager.IsWaifuOwned(Waifu.Nana))
        {
            locked_screen[1].SetActive(true);
        }
        else if (PersistentDataManager.IsWaifuOwned(Waifu.Nana))
        {
            locked_screen[1].SetActive(false);
        }
        if (!PersistentDataManager.IsWaifuOwned(Waifu.Yellow))
        {
            locked_screen[2].SetActive(true);
        }
        else if (PersistentDataManager.IsWaifuOwned(Waifu.Yellow))
        {
            locked_screen[2].SetActive(false);
        }




    }
}
