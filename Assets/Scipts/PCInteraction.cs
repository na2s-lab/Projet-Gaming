using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string questionText;
    [TextArea(1, 2)]
    public List<string> correctAnswers = new List<string>();
}

public class PCInteraction : MonoBehaviour  // ← MonoBehaviour obligatoire !
{
    [Header("UI")]
    public GameObject pcPanel;
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;

    [Header("Questions")]
    public List<Question> questions = new List<Question>();

    [Header("Porte Niveau Suivant")]
    public GameObject door;
    public string nextLevelScene = "Niveau2";

    [Header("Debug")]
    public int currentQuestionIndex = 0;
    public bool levelCompleted = false;

    bool playerInRange = false;

    void Start()
    {
        Collider2D colliderPC = GetComponent<Collider2D>();
        if (colliderPC != null)
            colliderPC.enabled = false;  // Bloqué au début

        pcPanel.SetActive(false);
        if (door != null)
            door.SetActive(false);

        if (questions.Count > 0)
            questionText.text = questions[0].questionText;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pcPanel.SetActive(!pcPanel.activeSelf);
            if (answerInput != null && pcPanel.activeSelf)
                answerInput.Select();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger PC : " + other.tag);  // Debug
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    public void OnValidateClicked()
    {
        Debug.Log("🔥 BOUTON VALIDER !");  // Debug

        string answer = answerInput.text.ToLower().Trim();
        bool correct = false;

        foreach (string goodAnswer in questions[currentQuestionIndex].correctAnswers)
        {
            if (answer.Contains(goodAnswer.ToLower()))
            {
                correct = true;
                break;
            }
        }

        if (correct && !levelCompleted)
        {
            levelCompleted = true;
            Debug.Log("✅ BONNE RÉPONSE !");

            if (door != null)
            {
                door.SetActive(true);
                Debug.Log("🚪 PORTE ACTIVÉE !");
            }

            currentQuestionIndex = (currentQuestionIndex + 1) % questions.Count;
            if (questions.Count > 0)
                questionText.text = questions[currentQuestionIndex].questionText;
        }
        else if (!correct)
        {
            Debug.Log("❌ FAUX");
        }

        pcPanel.SetActive(false);
        answerInput.text = "";
    }
}
