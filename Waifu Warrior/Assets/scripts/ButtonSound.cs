using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

	public void ButtonPressed()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
    }
    public void Switch()
    {
        FindObjectOfType<AudioManager>().Play("Switch");
    }
    public void Bought()
    {
        FindObjectOfType<AudioManager>().Play("CashBell");
    }
    public void Close()
    {
        FindObjectOfType<AudioManager>().Play("CloseWindow");
    }
}
