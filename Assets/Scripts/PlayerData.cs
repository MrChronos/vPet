using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterNamespace;


public class PlayerData : MonoBehaviour
{
    #region variables
    public bool isHungry, isPoop, isSleep, isSick, isTired;

    [Range(-100f, 100f)]
    public float happiness;
    [Range(-100f, 100f)]
    public float discipline;

    public int ageHours = 0;
    public int ageDays = 0;
    private Text ageText, weightText, careMistakesText, stageText;

    public int weight = 8;

    public int careMistakes = 0;
    public int timesPoop = 0;

    private Image foodButton, toiletButton, sleepButton, sickButton, tiredButton;
    private Slider happinessSlider, disciplineSlider;

    private Color currentColor = Color.black;
    private Color statusColor = Color.white;

    private MonsterData monsterData;
    private TimeClock timeClock;
    private FadeIn fadeIn;

    public Stage stage;
    public Animator statusAnim;

    public bool hasBeenFed;
    #endregion

    void Start () {
        FindComponents();
    }

    void FindComponents()
    {
        ageText = GameObject.Find("AgeText").GetComponent<Text>();
        weightText = GameObject.Find("WeightText").GetComponent<Text>();
        stageText = GameObject.Find("StageText").GetComponent<Text>();
        careMistakesText = GameObject.Find("CareMistakesText").GetComponent<Text>();

        foodButton = GameObject.Find("Food").GetComponent<Image>();
        toiletButton = GameObject.Find("Toilet").GetComponent<Image>();
        sleepButton = GameObject.Find("Sleep").GetComponent<Image>();
        sickButton = GameObject.Find("Bandage").GetComponent<Image>();
        tiredButton = GameObject.Find("Rest").GetComponent<Image>();

        happinessSlider = GameObject.Find("Happiness").GetComponent<Slider>();
        disciplineSlider = GameObject.Find("Discipline").GetComponent<Slider>();

        monsterData = GameObject.Find("PlayerData").GetComponent<MonsterData>();
        timeClock = GameObject.Find("ClockMain").GetComponent<TimeClock>();





    }

    void Update () {
        UpdateStrings();
        SetHappiness();
        CheckStatus();
        CheckDigivolve();
        //TestDigivolve();
        CheckDeath();

        if (Input.GetKeyDown("space"))
        {
            ResetDigimon();
        }
    }

    void UpdateStrings()
    {
        ageText.text = ageDays.ToString();
        weightText.text = weight.ToString();
        careMistakesText.text = careMistakes.ToString();
        stageText.text = stage.ToString();
    }

    void SetHappiness()
    {
        happinessSlider.value = happiness;
        disciplineSlider.value = discipline;
    }

    void CheckStatus()
    {
        // Hungry conditions
        if (isHungry == true)
        {
            statusAnim.SetBool("isFood", true);
            foodButton.color = statusColor;
        }
        else if(isHungry == false)
        {
            statusAnim.SetBool("isFood", false);
            foodButton.color = currentColor;            
        }

        // Poop conditions
        if (isPoop == true)
        {
            statusAnim.SetBool("isPoop", true);
            toiletButton.color = statusColor;
        }
        else if (isPoop == false)
        {
            statusAnim.SetBool("isPoop", false);
            toiletButton.color = currentColor;
        }

        // Sleep conditions
        if (isSleep == true)
        {
            statusAnim.SetBool("isSleep", true);
            sleepButton.color = statusColor;
        }
        else if (isSleep == false)
        {
            statusAnim.SetBool("isSleep", false);
            sleepButton.color = currentColor;
        }

        // Sick conditions
        if (isSick == true)
        {
            sickButton.color = statusColor;
        }
        else if (isSick == false)
        {
            sickButton.color = currentColor;
        }

        // Tired conditions
        if (isTired == true)
        {
            tiredButton.color = statusColor;
        }
        else if (isTired == false)
        {
            tiredButton.color = currentColor;
        }
    }

    void CheckDigivolve()
    {
        stage = monsterData.stage;
        
        // Digivolve to InTraining
        if (stage == Stage.Fresh && ageHours >= 6)
        {
            Digivolve();
        }

        // Digivolve to Rookie
        if (stage == Stage.InTraining && ageHours >= 30)
        {
            Digivolve();
        }

        // Digivolve to Champion
        if (stage == Stage.Rookie && ageHours >= 102)
        {
            Digivolve();
        }

        // Digivolve to Ultimate
        if (stage == Stage.Champion && ageHours >= 264)
        {
            Digivolve();
        }

        // Sukamon
        if ((stage == Stage.Fresh || stage == Stage.InTraining || stage == Stage.Rookie || stage == Stage.Champion || stage == Stage.Ultimate) 
            && monsterData.currentMonster != MonsterName.Sukamon && timesPoop >= 10)
        {
            SukamonDigivolve();
        }

    }

    void TestDigivolve()
    {
        stage = monsterData.stage;

        // Digivolve to InTraining
        if (stage == Stage.Fresh && ageHours >= 1)
        {
            Digivolve();
        }

        // Digivolve to Rookie
        if (stage == Stage.InTraining && ageHours >= 2)
        {
            Digivolve();
        }

        // Digivolve to Champion
        if (stage == Stage.Rookie && ageHours >= 3)
        {
            Digivolve();
        }

        // Digivolve to Ultimate
        if (stage == Stage.Champion && ageHours >= 4)
        {
            Digivolve();
        }

        // Sukamon
        if ((stage == Stage.Fresh || stage == Stage.InTraining || stage == Stage.Rookie || stage == Stage.Champion || stage == Stage.Ultimate)
            && monsterData.currentMonster != MonsterName.Sukamon && timesPoop >= 10)
        {
            SukamonDigivolve();
        }

    }

    void SukamonDigivolve()
    {
        timesPoop = 0;
        print("Digivolve to " + MonsterName.Sukamon + "!");
        monsterData.currentMonster = MonsterName.Sukamon;
    }

    void Digivolve()
    {

        // Digivolves to highest Digimon in DigivolveTo chain
        if (monsterData.evolveToRequirements(monsterData.partnerMonster.digivolveTo_05))
        {
            monsterData.currentMonster = monsterData.partnerMonster.digivolveTo_05;
            print("Digivolve to " + monsterData.partnerMonster.digivolveTo_02 + "!");
        }
        if (monsterData.evolveToRequirements(monsterData.partnerMonster.digivolveTo_04))
        {
            monsterData.currentMonster = monsterData.partnerMonster.digivolveTo_04;
            print("Digivolve to " + monsterData.partnerMonster.digivolveTo_03 + "!");
        }
        if (monsterData.evolveToRequirements(monsterData.partnerMonster.digivolveTo_03))
        {
            monsterData.currentMonster = monsterData.partnerMonster.digivolveTo_03;
            print("Digivolve to " + monsterData.partnerMonster.digivolveTo_04 + "!");
        }
        if (monsterData.evolveToRequirements(monsterData.partnerMonster.digivolveTo_02))
        {
            monsterData.currentMonster = monsterData.partnerMonster.digivolveTo_02;
            print("Digivolve to " + monsterData.partnerMonster.digivolveTo_05 + "!");
        }
        if (monsterData.evolveToRequirements(monsterData.partnerMonster.digivolveTo_01))
        {
            monsterData.currentMonster = monsterData.partnerMonster.digivolveTo_01;
            print("Digivolve to " + monsterData.partnerMonster.digivolveTo_01 + "!");
        }


    }

    void CheckDeath()
    {
        if ((stage == Stage.Fresh || stage == Stage.InTraining || stage == Stage.Rookie || stage == Stage.Champion)
            && ageHours >= 34) //360
        {
            ResetDigimon();
        }
        if ((stage == Stage.Ultimate) && ageHours >= 432)
        {
            ResetDigimon();
        }
    }

    void ResetDigimon()
    {
        monsterData.currentMonster = MonsterName.Botamon;
        isHungry = false;
        isPoop = false;
        isSleep = false;
        isSick = false;
        isTired = false;
        hasBeenFed = false;
        happiness = 50;
        discipline = 50;
        ageHours = 0;
        ageDays = 0;
        careMistakes = 0;
        timesPoop = 0;
        monsterData.timeOfFed = 0;
        monsterData.timeOfPoop = 0;
        monsterData.timeOfSleep = 0;
        monsterData.foodMistakeTime = 0;
        monsterData.poopMistakeTime = 0;
        monsterData.sleepMistakeTime = 0;

    }


    public void EatFood()
    {
        // Hungry data
        if(isHungry == true)
        {
            print("You just gave your "+monsterData.currentMonster+" some food!");
            weight++;
            happiness += 4;
            discipline += 2;
            isHungry = false;
            hasBeenFed = true;
        }
        if (isHungry == false && hasBeenFed == false)
        {
            print(monsterData.currentMonster+" isnt hungry!");
        }
    }

    public void UseToilet()
    {
        // Poop data
        if (isPoop == true)
        {
            print("Toilet used!");
            weight--;
            happiness += 3;
            discipline += 4;
            isPoop = false;
        }
        else
        {
            print("Digimon doesn't need to use the toilet!");
        }
    }

    public void GoToSleep()
    {
        // Sleep data
        if (isSleep == true)
        {
            print("Time to take a nap!");
            happiness += 3;
            discipline += 3;
            ageHours += monsterData.wakeTime;
            timeClock.hour += monsterData.wakeTime;
            timeClock.minute = 0;
            isSleep = false;            
        }
        else
        {
            print("Digimon is not tired!");
        }
    }
}
