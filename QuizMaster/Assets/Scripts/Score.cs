using UnityEngine;

public class Score : MonoBehaviour
{
    int _correctAnswers;
    int _questionsSeen;

    public int GetCorrectAnswers() => _correctAnswers;

    public int GetQuestionsSeen() => _questionsSeen;

    public void IncrementCorrectAnswers() => _correctAnswers++;

    public void IncrementQuestionsSeen() => _questionsSeen++;

    public int CalculateScore()
    {
        return Mathf.RoundToInt((float)_correctAnswers / (float)_questionsSeen * 100);
    }
}
