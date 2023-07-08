using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isChoice1;
    public AudioClip buttonSound;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ButtonClick()
    {
        SoundManager.instance.PlaySound(buttonSound);
        FindObjectOfType<ChoiceManager>().MakeChoice(isChoice1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("grow", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("grow", false);
    }

}
