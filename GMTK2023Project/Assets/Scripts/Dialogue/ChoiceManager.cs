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
    public Choice currentChoice;
    public bool makingChoice = false;
    private bool choice1Pointer;

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
        choice1Pointer = isChoice1;

        if (isChoice1)
        {
            //play animation and do stuff
            //start dialogue
            FindObjectOfType<DialogueManager>().StartDialogue(currentChoice.choice1Sentence);
        }
        else
        {
            //play animation and do stuff
            FindObjectOfType<DialogueManager>().StartDialogue(currentChoice.choice2Sentence);
        }
        makingChoice = false;
    }

    public void TriggerNextChoice()
    {
        StartCoroutine(NextChoice());
    }

    public IEnumerator NextChoice()
    {
        Debug.Log("NEXT CHOICE WAS CALLED");
        yield return new WaitForSeconds(timeTillNextChoice);

        if (choice1Pointer)
        {
            currentChoice = currentChoice.choice1Next;
        }
        else
        {
            currentChoice = currentChoice.choice2Next;
        }

        FindObjectOfType<StateManager>().SwitchCharacters();
    }
}
