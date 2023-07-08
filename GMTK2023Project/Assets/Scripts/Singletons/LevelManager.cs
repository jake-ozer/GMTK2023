using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Animator transitionAnim;
    public int index;
    public float timeTillEnd = 2f;

    //singleton
    private static LevelManager instance;

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

    private void Start()
    {
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
    }

    public void EndLevel()
    {
        StartCoroutine(Fading());
    }

    private IEnumerator Fading()
    {
        yield return new WaitForSeconds(timeTillEnd);
        transitionAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => transitionAnim.gameObject.GetComponent<Image>().color.a == 1);
        SceneManager.LoadScene(index);
    }
}
