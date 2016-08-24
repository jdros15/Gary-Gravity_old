using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuyItem : MonoBehaviour {
    public string itemName;
    public int itemPrice,itemAmountLeft,playerGold;
    public Text curGold;
 
	// Use this for initialization
	void Start () {
	
        
        //check if items are on the prefs
        if (PlayerPrefs.HasKey(itemName+"Amount"))
        {
            //do nothing
        }
        else
        {
            
            //add key and restock 50 of it
            PlayerPrefs.SetInt(itemName+"Amount",50);
        }
        itemAmountLeft = PlayerPrefs.GetInt(itemName + "Amount");
        playerGold = PlayerPrefs.GetInt("PlayerGold");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buyItem()
    {
        
        //if has stock
        if (itemAmountLeft >= 1)
        {
            //check player gold
            if (playerGold >= itemPrice)
            {
                //buy
                itemAmountLeft = itemAmountLeft - 1;
                PlayerPrefs.SetInt(itemName + "Amount", itemAmountLeft);
                //check if player has this item already
                if (PlayerPrefs.HasKey("Player" + itemName))
                {// if yes, add the bought item
                    PlayerPrefs.SetInt("Player" + itemName, PlayerPrefs.GetInt("Player" + itemName) + 1);

                }
                else
                {
                    //if not add the item
                    PlayerPrefs.SetInt("Player" + itemName, 1);
                }
                //decrease price from gold
                PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") - itemPrice);
                curGold.text = PlayerPrefs.GetInt("PlayerGold").ToString();
                PlayerPrefs.Save();
            }
            else
            {
                //insufficient
                print("Insufficient Gold");
            }
        }
       
    }
}

