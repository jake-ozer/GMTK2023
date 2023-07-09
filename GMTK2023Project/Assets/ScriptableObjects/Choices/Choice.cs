using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{
    //choice1
    public string choice1Name;
    public string choice1AnimName;
    public Choice choice1Next;
    public string choice1Sentence;
    public string choice1AVal;
    //choice 2
    public string choice2Name;
    public string choice2AnimName;
    public Choice choice2Next;
    public string choice2Sentence;
    public string choice2AVal;
    public bool frog = false;
}
