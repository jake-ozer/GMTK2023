using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public GameObject NameBox;
    public GameObject TextBox;
    private Queue<string> sentences = new Queue<string>();

    public void Start()
    {
        //NameBox.SetActive(false);
        TextBox.SetActive(false);
    }

    public void StartDialogue(string response)
    {
        //NameBox.SetActive(true);
        TextBox.SetActive(true);

        StartCoroutine(TypeSentence(response));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        TextBox.GetComponent<Text>().text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            TextBox.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(0.032f);
        }
        yield return new WaitForSeconds(2f);
        TextBox.SetActive(false);
        FindObjectOfType<ChoiceManager>().TriggerNextChoice();
    }

}
