using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<StateManager>().currentState = StateManager.State.inDialogue;
            FindObjectOfType<ChoiceManager>().makingChoice = true;
        }
    }
}
