using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]
    TextMeshProUGUI questionText;
    [SerializeField]
    List<QuestionSO> questions = new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField]
    GameObject[] answerButtons;

    [Header("Button Colours")]
    [SerializeField]
    Sprite defaultAnswerSprite;
    [SerializeField]
    Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField]
    Image timerImage;

    [Header("Score")]
    [SerializeField]
    TextMeshProUGUI scoreText;

    [Header("Progress")]
    [SerializeField]
    Slider progressBar;

    public bool isComplete;

    QuestionSO _question;
    int _correctAnswerIndex;
    bool _hasAnsweredEarly;
    Timer _timer;
    Score _score;

    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        _score = FindObjectOfType<Score>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = _timer.fillFraction;
        if (_timer.loadNextQuestion)
        {
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _timer.loadNextQuestion = false;
        }
        else if (!_hasAnsweredEarly && !_timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        _hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        _timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == _question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            _score.IncrementCorrectAnswers();
        }
        else
        {
            _correctAnswerIndex = _question.GetCorrectAnswerIndex();
            string correctAnswer = _question.GetAnswer(_correctAnswerIndex);
            questionText.text = $"Not quite, the correct answer is; {correctAnswer}";
            buttonImage = answerButtons[_correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        if (progressBar.value == progressBar.maxValue)
        {
            isComplete = true;
        }
        scoreText.text = $"Score: {_score.CalculateScore()}%";
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            _score.IncrementQuestionsSeen();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        _question = questions[index];

        if (questions.Contains(_question))
        {
            questions.Remove(_question);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = _question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
