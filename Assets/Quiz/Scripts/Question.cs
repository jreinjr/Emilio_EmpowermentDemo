using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Question", order = 1)]
public class Question : ScriptableObject {

    public string text;
    //public AudioClip audio;
    public List<Choice> choices;

}
