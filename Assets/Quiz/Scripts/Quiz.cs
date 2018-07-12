using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[ExecuteInEditMode]
public class Quiz : MonoBehaviour {

    public GameObject choices;
    public GameObject popupCanvas;
    public Text questionText;
    public Text popupCanvasText;
    public GameObject choicePrefab;
    public AudioSource audioSource;
    public AudioClip sfx_correct;
    public AudioClip sfx_wrong;
    public List<Question> questions;
    public int currentQuestionIndex;
    Question currentQuestion;
    public UnityEvent OnQuizFinished;

    public void LoadQuestion()
    {
        // Ensure currentQuestion is a valid index
        if (currentQuestionIndex < 0 || currentQuestionIndex >= questions.Count)
        {
            Debug.Log("currentQuestion does not fall under the range 0 to questions.Count");
            return;
        }
        currentQuestion = questions[currentQuestionIndex];
        // Set GUI text to string from question
        questionText.text = currentQuestion.text;

        // Ensure we have same number of buttons as choices
        if (choices.transform.childCount != currentQuestion.choices.Count)
        {
            Debug.Log(choices.transform.childCount + " buttons but " + currentQuestion.choices.Count + " choices.");
            return;
        }

        // Set each button text to current question choices text
        for (int i = 0; i < currentQuestion.choices.Count; i++)
        {
            ChoiceButton currentChoiceButton = choices.transform.GetChild(i).GetComponent<ChoiceButton>();
            Choice currentChoice = currentQuestion.choices[i];
            // Set button text to current choice text
            currentChoiceButton.label.text = currentChoice.text;

            // Will be used to set button colors
            ColorBlock colors = currentChoiceButton.button.colors;

            // Remove all listeners from button
            currentChoiceButton.button.onClick.RemoveAllListeners();
            // Add listeners for right and wrong responses
            if (currentChoice.correct)
            {
                currentChoiceButton.button.onClick.AddListener(NextQuestion);
                colors.pressedColor = Color.green;
            }
            else
            {
                colors.pressedColor = Color.red;
                currentChoiceButton.button.onClick.AddListener(() => ShowPopup(currentChoice.correction_text));
            }
            currentChoiceButton.button.colors = colors;
        }
    }

    public void NextQuestion()
    {
        audioSource.clip = sfx_correct;
        audioSource.Play();

        // Increment our currentQuestionIndex
        currentQuestionIndex++;
        // End the quiz if we have reached the end of our list of questions
        if (currentQuestionIndex >= questions.Count)
        {
            EndQuiz();
            return;
        }
        // otherwise, load the next question
        LoadQuestion();
    }

    public void ShowPopup(string text)
    {
        audioSource.clip = sfx_wrong;
        audioSource.Play();

        popupCanvasText.text = text;
        popupCanvas.SetActive(true);
    }

    void HidePopup()
    {
        popupCanvas.SetActive(false);
    }

    void EndQuiz()
    {
        if (OnQuizFinished != null)
            OnQuizFinished.Invoke();
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
