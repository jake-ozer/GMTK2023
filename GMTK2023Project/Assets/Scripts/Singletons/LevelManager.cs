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
    public int numScenes = 5;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
    }


    public void EndLevel()
    {
        StartCoroutine(Fading());
    }

    public void NextLevel()
    {
        Debug.Log("Next Level called");
        //int next = index + 1;
        if (index >= numScenes-1)
        {
            index = 0;
            SceneManager.LoadScene(0);
        }
        else
        {
            index++;
            SceneManager.LoadScene(index);
        }
    }

    private IEnumerator Fading()
    {
        yield return new WaitForSeconds(timeTillEnd);
        transitionAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => transitionAnim.gameObject.GetComponent<Image>().color.a == 1);
        int next = index + 1;
        if (next == numScenes)
        {
            index = 0;
            SceneManager.LoadScene(next);
        }
        else
        {
            index++;
            SceneManager.LoadScene(next);
        }
    }
}
