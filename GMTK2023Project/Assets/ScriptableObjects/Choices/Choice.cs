using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Choice : ScriptableObject
{
    //choice1
    public string choice1Name;
    public AnimationClip choice1Anim;
    public Choice choice1Next;
    public string choice1Sentence;
    //choice 2
    public string choice2Name;
    public AnimationClip choice2Anim;
    public Choice choice2Next;
    public string choice2Sentence;
}