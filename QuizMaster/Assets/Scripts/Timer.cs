using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timeToAnswerQuestion = 15f;
    [SerializeField]
    float timeToShowCorrectAnswer = 5f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    float _timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if (_timerValue > 0)
        {
            fillFraction = _timerValue / (isAnsweringQuestion ? timeToAnswerQuestion : timeToShowCorrectAnswer);
        }
        else
        {
            _timerValue = isAnsweringQuestion ? timeToShowCorrectAnswer : timeToAnswerQuestion;
            if (!isAnsweringQuestion)
            {
                loadNextQuestion = true;
            }
            isAnsweringQuestion = !isAnsweringQuestion;
        }
    }
}
