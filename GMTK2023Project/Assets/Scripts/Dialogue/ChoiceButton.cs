using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public bool isChoice1;

    public void ButtonClick()
    {
        FindObjectOfType<ChoiceManager>().MakeChoice(isChoice1);
    }

}
