using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Quiz : MonoBehaviour {

    public GameObject questionText;
    public GameObject choices;
    public GameObject choicePrefab;
    public List<Question> questions;
    public int currentQuestion;

    public void LoadQuestion()
    {
        // Ensure currentQuestion is a valid index
        if (currentQuestion < 0 || currentQuestion >= questions.Count)
        {
            Debug.Log("currentQuestion does not fall under the range 0 to questions.Count");
            return;
        }
        Question question = questions[currentQuestion];

        // Set GUI text to string from question
        questionText.GetComponent<Text>().text = question.text;

        

        foreach(Choice c in question.choices)
        {
        }
    }

    private void OnEnable()
    {
        LoadQuestion();
    }

    private void OnGUI()
    {
        LoadQuestion();
    }

}
