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
    public bool playButton = false;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (playButton)
        {
            Button b = GetComponent<Button>();
            b.onClick.AddListener(this.GetNextScene);
        }
    }

    private void GetNextScene()
    {
        Debug.Log("dheddsfjsdf");
        FindObjectOfType<LevelManager>().NextLevel();
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
