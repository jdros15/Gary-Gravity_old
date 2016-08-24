using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class printTime : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public Text timer;

    TimeSpan timeLeft;
    DateTime endTime,curTime;

    long temp;
    void Start()
    {
        //Store the current time when it starts
        currentDate = System.DateTime.Now;
        
        //Grab the old time from the player prefs as a long
        if (PlayerPrefs.HasKey("sysString"))
        {
            temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        }
        else
        {
            PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        }

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        //check if timeleft is present
        if (PlayerPrefs.HasKey("timeLeft"))
        {
            //do nothing
        }
        else
        {
            //PlayerPrefs.SetString("")
        }
      
       if (PlayerPrefs.HasKey("endTime"))
        {

            string dT = PlayerPrefs.GetString("endTime");
            endTime = Convert.ToDateTime(dT);
            print(endTime);

         
        }
        
      /*
        TimeSpan time1 = TimeSpan.FromMinutes(30);
        TimeSpan ts1= DateTime.Now.TimeOfDay;
        var ts2 = ts1.Add(time1);
        string op = String.Format("{0:D2}:{1:D2}", ts2.Hours, ts2.Minutes);
        PlayerPrefs.SetString("endTime",op);
        print(op);
       */
        
    }
    void Update()
    {
        
        curTime = System.DateTime.Now;
        timeLeft = endTime - curTime;
        string output = String.Format("{0:D2}:{1:D2}", timeLeft.Hours, timeLeft.Minutes);
        timer.text = "Time Left: " + output;
    }
    void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
       
        print("Saving this date to prefs: " + System.DateTime.Now);
        
    }

}