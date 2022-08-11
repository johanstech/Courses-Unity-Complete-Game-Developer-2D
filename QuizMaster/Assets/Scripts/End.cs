using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI endText;

    Score _score;

    void Awake()
    {
        _score = FindObjectOfType<Score>();
    }

    public void ShowFinalScore()
    {
        endText.text = $"Congratulations!\nYou scored {_score.CalculateScore()}%";
    }
}
