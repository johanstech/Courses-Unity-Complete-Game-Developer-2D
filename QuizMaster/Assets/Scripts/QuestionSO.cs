using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField]
    string question = "Enter new question text here";
    [SerializeField]
    string[] answers = new string[4];
    [SerializeField]
    int correctAnswerIndex;

    public string GetQuestion() => question;

    public string GetAnswer(int index) => answers[index];

    public int GetCorrectAnswerIndex() => correctAnswerIndex;
}
