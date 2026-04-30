using UnityEngine;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string questionText;
    [TextArea(3, 8)]
    public string textOption;
    public List<string> correctAnswers = new List<string>();
}

public class PCInteraction : MonoBehaviour
{
    [Header("UI")]
    public GameObject pcPanel;
    public TextMeshProUGUI questionText;
    public TMP_Text codeText;
    public TMP_InputField answerInput;

    [Header("Questions")]
    public List<Question> questions = new List<Question>();

    [Header("Porte Niveau Suivant")]
    public GameObject door;

    [Header("Debug")]
    public int currentQuestionIndex = 0;
    public bool levelCompleted = false;

    bool playerInRange = false;

    void Start()
    {
        pcPanel.SetActive(false);

        if (door != null)
            door.SetActive(false);

        DisplayQuestion();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pcPanel.SetActive(!pcPanel.activeSelf);

            if (answerInput != null && pcPanel.activeSelf)
            {
                answerInput.text = "";
                answerInput.Select();
                answerInput.ActivateInputField();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    void DisplayQuestion()
    {
        if (questions.Count == 0) return;

        questionText.text = questions[currentQuestionIndex].questionText;
        codeText.text = questions[currentQuestionIndex].textOption;
    }

    public void OnValidateClicked()
    {
        if (questions.Count == 0) return;

        string answer = answerInput.text.ToLower().Trim();
        bool correct = false;

        foreach (string goodAnswer in questions[currentQuestionIndex].correctAnswers)
        {
            if (answer.Contains(goodAnswer.ToLower().Trim()))
            {
                correct = true;
                break;
            }
        }

        if (correct && !levelCompleted)
        {
            levelCompleted = true;
            Debug.Log("Bonne réponse");

            if (door != null)
                door.SetActive(true);
        }
        else
        {
            Debug.Log("Mauvaise réponse");
        }

        pcPanel.SetActive(false);
        answerInput.text = "";
    }
}