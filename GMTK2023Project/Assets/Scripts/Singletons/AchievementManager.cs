using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    //singleton
    public static AchievementManager instance;
    public GameObject menu;
    public GameObject shiftText;
    public Text[] texts;
    private int saintCount = 0;
    private int kickCount = 0;
    private int overallCount = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //this is all hardcoded
    public void AddAchievement(string name)
    {
        switch (name)
        {
            case "saint":
                saintCount++;
                if (saintCount == 3)
                {
                    texts[0].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Get a positive interaction with everyone";
                    texts[0].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    overallCount++;
                }
                break;
            case "kickout":
                kickCount++;
                if (kickCount == 3)
                {
                    texts[1].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Kick all 3 characters out of the tavern";
                    texts[1].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    overallCount++;
                }
                break;
            case "rob":
                texts[2].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Get robbed by the goblin";
                texts[2].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                overallCount++;
                break;
            case "ribbit":
                texts[3].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Get turned into a frog from the wizard";
                texts[3].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                overallCount++;
                break;
            case "prep":
                texts[4].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Send the adventurer off with a bucket";
                texts[4].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                overallCount++;
                break;
        }
        
    }

    private void Update()
    {
        if (overallCount >= 5)
        {
            texts[5].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Get all other the achievements";
            texts[5].gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            menu.SetActive(true);
            shiftText.SetActive(false);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            menu.SetActive(false);
            shiftText.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
