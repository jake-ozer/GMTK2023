using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool once = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<StateManager>().currentState = StateManager.State.inDialogue;
            if (once)
            {
                FindObjectOfType<ChoiceManager>().makingChoice = true;
                once = false;
            }
            this.gameObject.SetActive(false);
        }
    }
}
