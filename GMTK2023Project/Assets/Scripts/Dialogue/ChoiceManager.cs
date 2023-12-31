using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private Choice startingChoice;
    [SerializeField] private GameObject choiceMenu;
    [SerializeField] private float timeTillNextChoice = 2f;
    [SerializeField] private float timeTillChoicesAppearAfterSwitch = 2f;
    public Choice currentChoice;
    public bool makingChoice = false;
    private bool choice1Pointer;
    private Animator partnerAnim;

    private void Awake()
    {
        currentChoice = startingChoice;
    }

    private void Update()
    {
        if (makingChoice)
        {
            choiceMenu.SetActive(true);
            choiceMenu.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = currentChoice.choice1Name;
            choiceMenu.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = currentChoice.choice2Name;
        }
        else
        {
            choiceMenu.SetActive(false);
        }
    }

    public void MakeChoice(bool isChoice1)
    {
        FindObjectOfType<StateManager>().rotateCharacters = false; //this is for state manager rotation of characters

        choice1Pointer = isChoice1;

        if (isChoice1)
        {
            //play animation and do stuff
            //start dialogue
            FindObjectOfType<DialogueManager>().StartDialogue(currentChoice.choice1Sentence);
            if (currentChoice.choice1AnimName != null)
            {
                //Debug.Log(FindObjectOfType<StateManager>().partnerPivot.name);
                //Debug.Log(FindObjectOfType<StateManager>().partnerPivot.transform.childCount);
                partnerAnim = FindObjectOfType<StateManager>().partnerPivot.transform.GetChild(0).gameObject.GetComponent<Animator>();
                
                if (partnerAnim != null)
                {
                    partnerAnim.Play(currentChoice.choice1AnimName);
                }
                
            }

            if (currentChoice.choice1AVal != null)
            {
                FindObjectOfType<AchievementManager>().AddAchievement(currentChoice.choice1AVal);
            }

            if (currentChoice.frog)
            {
                //do frog logic
                GameObject.Find("Frog").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Bartender").SetActive(false);
            }
        }
        else
        {
            //play animation and do stuff
            FindObjectOfType<DialogueManager>().StartDialogue(currentChoice.choice2Sentence);

            if (currentChoice.choice2AnimName != null)
            {
                partnerAnim = FindObjectOfType<StateManager>().partnerPivot.transform.GetChild(0).gameObject.GetComponent<Animator>();
                partnerAnim.Play(currentChoice.choice2AnimName);
            }

            if (currentChoice.choice2AVal != null)
            {
                FindObjectOfType<AchievementManager>().AddAchievement(currentChoice.choice2AVal);
            }
        }
        makingChoice = false;
    }

    public void TriggerNextChoice()
    {
        StartCoroutine(NextChoice());
    }

    public IEnumerator NextChoice()
    {
        yield return new WaitForSeconds(timeTillNextChoice);

        if (choice1Pointer)
        {
            if (currentChoice.choice1Next != null)
            {
                currentChoice = currentChoice.choice1Next;
                FindObjectOfType<StateManager>().SwitchCharacters();
                yield return new WaitForSeconds(timeTillChoicesAppearAfterSwitch);
                makingChoice = true;
            }
            else
            {
                EndEncounter();
                FindObjectOfType<LevelManager>().EndLevel();
            }
        }
        else
        {
            if (currentChoice.choice2Next != null)
            {
                currentChoice = currentChoice.choice2Next;
                FindObjectOfType<StateManager>().SwitchCharacters();
                yield return new WaitForSeconds(timeTillChoicesAppearAfterSwitch);
                makingChoice = true;
            }
            else
            {
                EndEncounter();
                FindObjectOfType<LevelManager>().EndLevel();
            }
        }
    }

    private void EndEncounter()
    {
        Debug.Log("Encounter over");
        makingChoice = false;
        FindObjectOfType<StateManager>().currentState = StateManager.State.freeRoam;
    }
}
