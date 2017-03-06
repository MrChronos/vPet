using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterNamespace
{
    public enum Attribute
    {
        Vaccine, Virus, Data
    }
    public enum Stage
    {
        Egg, Fresh, InTraining, Rookie, Champion, Ultimate, Mega
    }
    public enum Type
    {
        Egg, Reptile, Dinosaur, Cyborg, Skeleton, Beast, Puppet, Dragon, Machine, Mutant
    }
    public enum Element
    {
        Fire, Battle, Air, Ice, Mech, Earth, Holy, Darkness, Filth
    }
    public enum ActiveTimes
    { 
        Egg, Fresh, Morning, DayEarly, DayLate, Evening, NightEarly, NightLate
    }
    public enum MonsterName
    {   
        Egg,      
        Botamon,
        Koromon,
        Agumon, 
        Greymon, Tyrannomon, Cyclonemon, Flarerizamon, 
        Metalgreymon, Skullgreymon, Mastertyrannomon, Metaltyrannomon, Extyrannomon, Datamon, Megadramon, Gigadramon, 
        Gabumon,
        Garurumon, Drimogemon, Monochromon, 
        Weregarurumon, Mammothmon, Giromon, Triceramon,
        Numemon, Sukamon,
        none
    }

    public class MonsterData : MonoBehaviour
    {
        public MonsterName currentMonster;
        public MonsterName nextMonster;
        public Monster partnerMonster;
        public Stage stage;

        [HideInInspector]
        public Sprite
        Botamon,
        Koromon,
        Agumon,
        Greymon, Tyrannomon, Cyclonemon, Flarerizamon,
        Metalgreymon, Skullgreymon, Mastertyrannomon, Metaltyrannomon, Extyrannomon, Datamon, Megadramon, Gigadramon,
        Gabumon,
        Garurumon, Drimogemon, Monochromon,
        Weregarurumon, Mammothmon, Giromon, Triceramon,
        Numemon, Sukamon;

        public SpriteRenderer player;
        public PlayerData playerData;
        public TimeClock timeClock;
        public ActiveTimeSet activeTimeSet;
        public int timeOfFed, timeOfPoop, timeOfSleep, foodMistakeTime, poopMistakeTime, sleepMistakeTime, wakeTime, timeOfHatch, timeOfBirth;



        public class Monster
        {
            public MonsterName monsterName;
            public Stage stage;
            public Attribute attribute;
            public Type type;
            // public Element element_01, element_02, element_03, element_04;
            public List<Element> elements = new List<Element>();

            public ActiveTimes activeTimes;
            public int baseWeight;
            public MonsterName digivolveTo_01, digivolveTo_02, digivolveTo_03, digivolveTo_04, digivolveTo_05;
            public Sprite partnerSprite;

            public Monster(monsterName, stage, attribute, type, elements, activeTimes, baseWeight, partnerSprite)
            {
                this.monsterName = monsterName;
                this.state = stage;
                this.attribute = attribute;
                this.type = type;
                this.elements = elements;
                this.activeTimes = activeTimes;
                this.baseWeight = baseWeight;
                this.partnerSprite = partnerSprite;
            }
        }

        void Start()
        {
            player = GameObject.Find("Partner").GetComponent<SpriteRenderer>();
            playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
            timeClock = GameObject.Find("ClockMain").GetComponent<TimeClock>();
            activeTimeSet = GameObject.Find("PlayerData").GetComponent<ActiveTimeSet>();
        }

        void Update()
        {
            partnerMonster = CurrentMonster(currentMonster);            
            player.sprite = partnerMonster.partnerSprite;
            SetActiveTimes(timeClock.hour, timeClock.minute);
            //activeTimeSet.SetActiveTimes2(timeClock.hour, timeClock.minute);            
        }

        #region Active Times
        public void SetActiveTimes(int hour, int minute)
        {
            #region Egg
            if (partnerMonster.activeTimes == ActiveTimes.Fresh)
            {
                wakeTime = 0;
                // Food times
                if ((hour == 0 ) && minute == 0)
                {
                    timeOfBirth = hour;
                    timeOfHatch = (timeOfBirth + 5);
                }


            }
            #endregion

            #region Fresh
            if (partnerMonster.activeTimes == ActiveTimes.Fresh)
            {
                wakeTime = 1;
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
            #endregion
            
            #region Morning
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
            #endregion

            #region DayEarly
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
            #endregion

            #region DayLate
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
            #endregion

            #region Evening
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
            #endregion

            #region NightEarly
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
            #endregion

            #region Nightlate
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
            #endregion


            #region Care Mistakes
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
            #endregion
        }
        #endregion


        public Monster CurrentMonster(MonsterName currentMonster)
        {
            Monster m = new Monster();
            if (currentMonster == MonsterName.Egg)
            {
                m = Monster(currentMonster, Stage.Fresh, Attribute.Vaccine, Type.Dinosaur, new List(Element.Fire), ActiveTimes.Egg, 1, Egg)
                // m.monsterName = currentMonster;
                // m.stage = Stage.Fresh;
                // m.attribute = Attribute.Vaccine;
                // m.type = Type.Dinosaur;
                // m.element_01 = Element.Fire;
                // m.activeTimes = ActiveTimes.Egg;
                // m.baseWeight = 1;
                m.digivolveTo_01 = MonsterName.Botamon;
                // m.partnerSprite = Egg;
            }

            if (currentMonster == MonsterName.Botamon)
            {                
                m.monsterName = currentMonster;
                m.stage = Stage.Fresh;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.activeTimes = ActiveTimes.Fresh;
                m.baseWeight = 5;
                m.digivolveTo_01 = MonsterName.Koromon;
                m.partnerSprite = Botamon;
            }
            else if (currentMonster == MonsterName.Koromon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.InTraining;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.activeTimes = ActiveTimes.DayEarly;
                m.baseWeight = 5;
                m.digivolveTo_01 = MonsterName.Agumon;
                m.digivolveTo_02 = MonsterName.Gabumon;
                m.partnerSprite = Koromon;
            }

            #region Agumon line
            else if (currentMonster == MonsterName.Agumon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Rookie;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Reptile;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.DayEarly;
                m.baseWeight = 15;
                m.digivolveTo_01 = MonsterName.Greymon;
                m.digivolveTo_02 = MonsterName.Tyrannomon;
                m.digivolveTo_03 = MonsterName.Cyclonemon;
                m.digivolveTo_04 = MonsterName.Flarerizamon;
                m.digivolveTo_05 = MonsterName.Numemon;
                m.partnerSprite = Agumon;                
            }

            else if (currentMonster == MonsterName.Greymon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.DayEarly;
                m.baseWeight = 30;
                m.digivolveTo_01 = MonsterName.Metalgreymon;
                m.partnerSprite = Greymon;
            }

            else if (currentMonster == MonsterName.Metalgreymon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Cyborg;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.element_03 = Element.Mech;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Metalgreymon;
            }

            else if (currentMonster == MonsterName.Skullgreymon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Virus;
                m.type = Type.Skeleton;
                m.element_01 = Element.Fire;
                m.element_03 = Element.Darkness;
                m.activeTimes = ActiveTimes.NightEarly;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Skullgreymon;
            }


            else if (currentMonster == MonsterName.Tyrannomon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Data;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.Evening;
                m.baseWeight = 30;
                m.digivolveTo_01 = MonsterName.Mastertyrannomon;
                m.digivolveTo_02 = MonsterName.Metaltyrannomon;
                m.digivolveTo_03 = MonsterName.Extyrannomon;
                m.partnerSprite = Tyrannomon;
            }

            else if (currentMonster == MonsterName.Mastertyrannomon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Mastertyrannomon;
            }

            else if (currentMonster == MonsterName.Metaltyrannomon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Virus;
                m.type = Type.Cyborg;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.element_03 = Element.Battle;
                m.activeTimes = ActiveTimes.Evening;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Metaltyrannomon;
            }

            else if (currentMonster == MonsterName.Extyrannomon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Virus;
                m.type = Type.Puppet;
                m.element_01 = Element.Earth;
                m.element_02 = Element.Darkness;
                m.activeTimes = ActiveTimes.NightEarly;
                m.baseWeight = 20;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Extyrannomon;
            }

            else if (currentMonster == MonsterName.Cyclonemon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Virus;
                m.type = Type.Dragon;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.element_03 = Element.Darkness;
                m.element_04 = Element.Filth;
                m.activeTimes = ActiveTimes.Evening;
                m.baseWeight = 30;
                m.digivolveTo_01 = MonsterName.Datamon;
                m.digivolveTo_02 = MonsterName.Megadramon;
                m.partnerSprite = Cyclonemon;
            }

            else if (currentMonster == MonsterName.Datamon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Virus;
                m.type = Type.Machine;
                m.element_01 = Element.Mech;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 20;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Datamon;
            }

            else if (currentMonster == MonsterName.Megadramon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Virus;
                m.type = Type.Cyborg;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Air;
                m.element_03 = Element.Mech;
                m.activeTimes = ActiveTimes.NightEarly;
                m.baseWeight = 50;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Megadramon;
            }

            else if (currentMonster == MonsterName.Flarerizamon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Data;
                m.type = Type.Dragon;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 20;
                m.digivolveTo_01 = MonsterName.Gigadramon;
                m.partnerSprite = Flarerizamon;
            }

            else if (currentMonster == MonsterName.Gigadramon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Virus;
                m.type = Type.Cyborg;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Air;
                m.element_03 = Element.Mech;
                m.activeTimes = ActiveTimes.NightEarly;
                m.baseWeight = 50;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Gigadramon;
            }
            #endregion

            #region Gabumon line
            else if (currentMonster == MonsterName.Gabumon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Rookie;
                m.attribute = Attribute.Data;
                m.type = Type.Reptile;
                m.element_01 = Element.Ice;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 15;
                m.digivolveTo_01 = MonsterName.Garurumon;
                m.digivolveTo_02 = MonsterName.Drimogemon;
                m.digivolveTo_03 = MonsterName.Monochromon;
                m.digivolveTo_04 = MonsterName.Numemon;
                m.partnerSprite = Gabumon;
            }

            else if (currentMonster == MonsterName.Garurumon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Beast;
                m.element_01 = Element.Ice;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 30;
                m.digivolveTo_01 = MonsterName.Weregarurumon;
                m.partnerSprite = Garurumon;
            }

            else if (currentMonster == MonsterName.Weregarurumon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Reptile;
                m.element_01 = Element.Ice;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.NightEarly;
                m.baseWeight = 30;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Weregarurumon;
            }

            else if (currentMonster == MonsterName.Mammothmon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Beast;
                m.element_01 = Element.Ice;
                m.element_02 = Element.Earth;
                m.activeTimes = ActiveTimes.Morning;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Mammothmon;
            }

            else if (currentMonster == MonsterName.Drimogemon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Data;
                m.type = Type.Beast;
                m.element_01 = Element.Earth;
                m.activeTimes = ActiveTimes.NightEarly;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.Giromon;
                m.partnerSprite = Drimogemon;
            }

            else if (currentMonster == MonsterName.Giromon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Vaccine;
                m.type = Type.Machine;
                m.element_01 = Element.Mech;
                m.activeTimes = ActiveTimes.Morning;
                m.baseWeight = 10;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Giromon;
            }

            else if (currentMonster == MonsterName.Monochromon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Data;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Earth;
                m.activeTimes = ActiveTimes.DayEarly;
                m.baseWeight = 40;
                m.digivolveTo_01 = MonsterName.Triceramon;
                m.partnerSprite = Monochromon;
            }

            else if (currentMonster == MonsterName.Triceramon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Ultimate;
                m.attribute = Attribute.Data;
                m.type = Type.Dinosaur;
                m.element_01 = Element.Fire;
                m.element_02 = Element.Battle;
                m.activeTimes = ActiveTimes.Evening;
                m.baseWeight = 30;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Triceramon;
            }
            #endregion 

            #region Special
            else if (currentMonster == MonsterName.Numemon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Virus;
                m.type = Type.Mutant;
                m.element_01 = Element.Filth;
                m.activeTimes = ActiveTimes.DayEarly;
                m.baseWeight = 15;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Numemon;
            }

            else if (currentMonster == MonsterName.Sukamon)
            {
                m.monsterName = currentMonster;
                m.stage = Stage.Champion;
                m.attribute = Attribute.Virus;
                m.type = Type.Mutant;
                m.element_01 = Element.Filth;
                m.activeTimes = ActiveTimes.DayLate;
                m.baseWeight = 15;
                m.digivolveTo_01 = MonsterName.none;
                m.partnerSprite = Sukamon;
            }
            #endregion

            nextMonster = m.digivolveTo_01;
            stage = m.stage;
            return m;
        }

        public bool evolveToRequirements(MonsterName m)
        {
            if(m == MonsterName.Koromon)
            {
                return true;
            }

            #region Rookies
            if (m == MonsterName.Agumon)
            {
                if(playerData.careMistakes <= 2)
                {
                    return true;
                }                
            }

            if (m == MonsterName.Gabumon)
            {
                if (playerData.careMistakes > 2)
                {
                    return true;
                }
            }
            #endregion

            #region Champions
            if (m == MonsterName.Greymon)
            {
                if (playerData.careMistakes < 1)
                {
                    return true;
                }
            }

            if (m == MonsterName.Tyrannomon)
            {
                if (playerData.careMistakes < 5)
                {
                    return true;
                }
            }

            if (m == MonsterName.Cyclonemon)
            {
                if (playerData.careMistakes > 1 && playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Flarerizamon)
            {
                if (playerData.careMistakes < 5 && playerData.weight < 20)
                {
                    return true;
                }
            }

            if (m == MonsterName.Garurumon)
            {
                if (playerData.careMistakes < 1)
                {
                    return true;
                }
            }

            if (m == MonsterName.Drimogemon)
            {
                if (playerData.careMistakes < 5 && playerData.happiness > 100)
                {
                    return true;
                }
            }

            if (m == MonsterName.Monochromon)
            {
                if (playerData.careMistakes < 5 && playerData.weight > 30)
                {
                    return true;
                }
            }
            #endregion

            #region Ultimates

            if (m == MonsterName.Metalgreymon)
            {
                if (playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Metalgreymon)
            {
                if (playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Skullgreymon)
            {
                if (playerData.careMistakes > 5 && playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Mastertyrannomon)
            {
                if (playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Metaltyrannomon)
            {
                if (playerData.careMistakes > 5 && playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Extyrannomon)
            {
                if (playerData.careMistakes < 5 && playerData.weight < 20)
                {
                    return true;
                }
            }

            if (m == MonsterName.Datamon)
            {
                if (playerData.careMistakes < 10 && playerData.weight < 30)
                {
                    return true;
                }
            }

            if (m == MonsterName.Megadramon)
            {
                if (playerData.careMistakes < 10 && playerData.weight > 30)
                {
                    return true;
                }
            }

            if (m == MonsterName.Gigadramon)
            {
                if (playerData.careMistakes < 10 && playerData.weight > 30)
                {
                    return true;
                }
            }

            if (m == MonsterName.Weregarurumon)
            {
                if (playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Mammothmon)
            {
                if (playerData.careMistakes < 10 && playerData.weight > 30)
                {
                    return true;
                }
            }

            if (m == MonsterName.Giromon)
            {
                if (playerData.careMistakes < 10)
                {
                    return true;
                }
            }

            if (m == MonsterName.Triceramon)
            {
                if (playerData.careMistakes < 10)
                {
                    return true;
                }
            }
            #endregion

            #region Specials
            if (m == MonsterName.Numemon)
            {
                if (playerData.careMistakes > 1)
                {
                    return true;
                }
            }
            #endregion

            return false;
        }
    }
}
