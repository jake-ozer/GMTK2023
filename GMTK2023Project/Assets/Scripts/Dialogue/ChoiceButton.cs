using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public bool isChoice1;
    public AudioClip buttonSound;

    public void ButtonClick()
    {
        SoundManager.instance.PlaySound(buttonSound);
        FindObjectOfType<ChoiceManager>().MakeChoice(isChoice1);
    }

}
