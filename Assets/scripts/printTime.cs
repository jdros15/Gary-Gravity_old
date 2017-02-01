using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class PrintTime : MonoBehaviour
{


    DateTime currentDate;
    DateTime oldDate;
    public Text timerBoost,timerAttack,timerShield;
    public string itemName;
    TimeSpan timeLeftBoost;
    DateTime endTime,curTime;
    public double itmTime;
    long temp;
    void Start()
    {


        
        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        refreshTime();
        
      
    }

    public void refreshTime()
    {
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
         oldDate = DateTime.FromBinary(temp);
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

        if (PlayerPrefs.HasKey("endTime"+itemName))
        {
            string dT = PlayerPrefs.GetString("endTime"+itemName);
            endTime = Convert.ToDateTime(dT);
         //   print(endTimeBoost);

        }
    }
   
    void Update()
    {
       
        curTime = System.DateTime.Now;
        timeLeftBoost = endTime - curTime;
        var secsLeftBoost = timeLeftBoost.TotalSeconds;

      //  print("Total Hours: " + secsLeftBoost.ToString());

        string output = String.Format("{0:D2}:{1:D2}:{2:D2}", timeLeftBoost.Hours, timeLeftBoost.Minutes, timeLeftBoost.Seconds);



        if (secsLeftBoost <= 0)
        {
            timerBoost.text = "0 boost";
          
        }
        else if (secsLeftBoost <= 60)
        {
            string secsLeftBoostStr = secsLeftBoost.ToString().Substring(0,2);
            if (secsLeftBoost >= 10) timerBoost.text = "00:00:" + secsLeftBoostStr;
            else
            {
                secsLeftBoostStr = secsLeftBoost.ToString().Substring(0,1);
                timerBoost.text = "00:00:0" + secsLeftBoostStr;
            }
        }
        else
        {
            timerBoost.text = output;
        }

       
    }
    void OnApplicationQuit()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
       
        print("Saving this date to prefs: " + System.DateTime.Now);
        
    }

    public void iprintna()
    {

      Debug.Log(itmTime);
      TimeSpan time1 = TimeSpan.FromMinutes(itmTime);
      TimeSpan time2 = oldDate.TimeOfDay;
      TimeSpan ts1 = DateTime.Now.TimeOfDay;
      var ts2 = ts1.Add(time1);
      string op = String.Format("{0:D2}:{1:D2}:{2:D2}", ts2.Hours, ts2.Minutes,ts2.Seconds);
      PlayerPrefs.SetString("endTime"+itemName, op);
      print("OPPA: "+op);
      
      refreshTime();
        }



} 


