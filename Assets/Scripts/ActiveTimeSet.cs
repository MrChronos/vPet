using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterNamespace
{

    public class ActiveTimeSet : MonoBehaviour
    {


        public PlayerData playerData;
        public MonsterData monsterData;
        public TimeClock timeClock;


        public MonsterData.Monster partnerMonster;
        public int timeOfFed, timeOfPoop, timeOfSleep, foodMistakeTime, poopMistakeTime, sleepMistakeTime, wakeTime;


        void Start()
        {
            playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
            monsterData = GameObject.Find("PlayerData").GetComponent<MonsterData>();
            timeClock = GameObject.Find("ClockMain").GetComponent<TimeClock>();


        }

        void Update()
        {
            //SetActiveTimes2(timeClock.hour, timeClock.minute);
        }



        public void SetActiveTimes2(int hour, int minute)
        {



            if (partnerMonster.activeTimes == ActiveTimes.Fresh)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 1 || hour == 7 || hour == 12 || hour == 18 || hour == 22) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 3 || hour == 8 || hour == 13 || hour == 17 || hour == 23) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 4 || hour == 9 || hour == 14 || hour == 19 || hour == 23) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }
            if (partnerMonster.activeTimes == ActiveTimes.Morning)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 4 || hour == 8 || hour == 13) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 3 || hour == 9 || hour == 14) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 16) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }

            if (partnerMonster.activeTimes == ActiveTimes.DayEarly)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 6 || hour == 11 || hour == 17) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 7 || hour == 12 || hour == 16) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 19) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }
            if (partnerMonster.activeTimes == ActiveTimes.DayLate)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 9 || hour == 14 || hour == 20) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 10 || hour == 15 || hour == 19) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 22) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }
            if (partnerMonster.activeTimes == ActiveTimes.Evening)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 13 || hour == 19 || hour == 0) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 14 || hour == 18 || hour == 23) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 2) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }

            if (partnerMonster.activeTimes == ActiveTimes.NightEarly)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 4 || hour == 18 || hour == 0) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 5 || hour == 19 || hour == 23) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 7) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }
            if (partnerMonster.activeTimes == ActiveTimes.NightLate)
            {
                wakeTime = 8;
                // Food times
                if ((hour == 2 || hour == 8 || hour == 21) && minute == 0)
                {
                    timeOfFed = hour;
                    foodMistakeTime = (timeOfFed + 2);
                    //print(timeOfFed);
                    playerData.isHungry = true;
                }
                // Poop times
                if ((hour == 3 || hour == 7 || hour == 22) && minute == 0)
                {
                    timeOfPoop = hour;
                    poopMistakeTime = (timeOfPoop + 1);
                    // print(timeOfFed);
                    playerData.isPoop = true;
                }
                // Sleep times
                if ((hour == 10) && minute == 0)
                {
                    timeOfSleep = hour;
                    sleepMistakeTime = (timeOfSleep + 1);
                    //print(timeOfSleep);
                    playerData.isSleep = true;
                }
            }




            // Food care mistakes
            if (playerData.isHungry == true && foodMistakeTime == hour)
            {
                playerData.careMistakes += 1;
                playerData.happiness -= 3;
                playerData.discipline -= 2;
                print("you got a care mistake");
                playerData.isHungry = false;
            }
            // Poop care mistakes
            if (playerData.isPoop == true && poopMistakeTime == hour)
            {
                playerData.careMistakes += 1;
                playerData.happiness -= 3;
                playerData.discipline -= 5;
                playerData.timesPoop++;

                print("you got a care mistake");
                playerData.isPoop = false;
            }
            // Sleep care mistakes
            if (playerData.isSleep == true && sleepMistakeTime == hour)
            {
                playerData.careMistakes += 1;
                playerData.happiness -= 4;
                playerData.discipline -= 4;

                print("you got a care mistake");
                playerData.isSleep = false;
            }

        }






    }
}