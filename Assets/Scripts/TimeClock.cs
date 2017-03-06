using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeClock : MonoBehaviour {


    public enum Season {Summer, Autumn, Winter, Spring};
    public enum TimeOfDay { Morning, Day, Afternoon, Night };


    public Season season;
    public TimeOfDay timeOfDay;


    public const int timescale = 2500;

    public Text clockText;
    public Text dayText;
    private Text seasonText;
    private Text yearText;

    public double second;
    public int minute, hour, day, month, year;


    private PlayerData playerData;

	// Use this for initialization
	void Start () {
        month = 1;
        day = 1;
        year = 2016;

        getComponents();

    }

    void getComponents()
    {
        clockText = GameObject.Find("Clock").GetComponent<Text>();
        dayText = GameObject.Find("Day").GetComponent<Text>();
        seasonText = GameObject.Find("Season").GetComponent<Text>();
        yearText = GameObject.Find("Year").GetComponent<Text>();

        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();



    }


    // Update is called once per frame
    void Update () {
        CalculateTime();
        TextCallFunction();
        CalculateSeason();
        CalculateTimeOfDay();

    }

    void TextCallFunction()
    {
        dayText.text = "Day: " + day;
        clockText.text = "Time: " + hour + ":" + minute;
        yearText.text = "Year: " + year;
    }


    void CalculateSeason()
    {

        if (month == 1 || month == 2 || month == 3)
        {
            season = Season.Summer;
        }
        else if (month == 4 || month == 5 || month == 6)
        {
            season = Season.Autumn;
        }
        else if (month == 7 || month == 8 || month == 9)
        {
            season = Season.Winter;
        }
        else if (month == 10 || month == 11 || month == 12)
        {
            season = Season.Spring;
        }
        //seasonText.text = season.ToString();
    }


    void CalculateTimeOfDay()
    {

        if (hour >= 4 && hour <= 7)
        {
            timeOfDay = TimeOfDay.Morning;
        }
        else if (hour >= 8 && hour <= 15)
        {
            timeOfDay = TimeOfDay.Day;
        }
        else if (hour >= 16 && hour <= 19)
        {
            timeOfDay = TimeOfDay.Afternoon;
        }
        else if (hour >= 20 && hour <= 3)
        {
            timeOfDay = TimeOfDay.Night;
        }
        seasonText.text = timeOfDay.ToString();
    }





    void CalculateMonth()
    {
        if(day >= 31)
        {
            month++;
            day = 1;
            TextCallFunction();
            CalculateSeason();
        }
    }

    public void CalculateTime()
    {
        second += Time.deltaTime * timescale;

        if (second >= 60)
        {
            minute++;
            second = 0;
            TextCallFunction();
        }
        else if (minute >= 60)
        {
            hour++;
            playerData.ageHours++;
            minute = 0;
            TextCallFunction();
        }
        else if (hour >= 24)
        {
            day++;
            playerData.ageDays++;
            hour = 0;
            TextCallFunction();
        }
        else if(day >= 28)
        {
            CalculateMonth();
        }
        else if(month >= 13)
        {
            month = 1;
            year++;
            TextCallFunction();
            CalculateSeason();
        }
    }



}
