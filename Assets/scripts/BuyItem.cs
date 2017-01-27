using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class BuyItem : MonoBehaviour {
    public string itemName;
    public int itemPrice,playerGold;
    public double itemTime;
    private double tempItemTime = 0;
    public Text curGold;
    //public string itmTime;
    public PrintTime printTime;
    public GameObject _printTime;
    PlayerGold pGold;




	// Use this for initialization
	void Start () {
        _printTime = GameObject.Find("timerPrinter");
      //  gameObject.SendMessage("itemTime", 69);

        playerGold = PlayerPrefs.GetInt("PlayerGold");
     
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buyItem()
    {
        
                //check player gold
            if (playerGold >= itemPrice)
            {
   
                //check if player has this item already


                if (itemTime <= 480)
                {
                    if ((PlayerPrefs.HasKey("endTime" + itemName)))
                    {
                        print("BEFORE: " + itemTime.ToString());
                        if (tempItemTime == 0) tempItemTime = itemTime;
                        itemTime = (Convert.ToDateTime(PlayerPrefs.GetString("endTime" + itemName)) - System.DateTime.Now).TotalMinutes + tempItemTime;
                        print("AFTER: " + itemTime.ToString());
                    }

                    printTime.itmTime = itemTime;
                    printTime.iprintna();
                
       
                //decrease price from gold
                PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") - itemPrice);
                //curGold.text = PlayerPrefs.GetInt("PlayerGold").ToString();
                pGold.playerGold = PlayerPrefs.GetInt("PlayerGold");
                PlayerPrefs.Save();
                }
            }
            else
            {
                //insufficient
                print("Insufficient Gold");
            }
        
       
    }

   
}

