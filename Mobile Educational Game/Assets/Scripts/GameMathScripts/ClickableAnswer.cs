using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableAnswer : MonoBehaviour, IPointerClickHandler
{
    int randomAnswer;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Clicked on letter {randomAnswer}");
        if (randomAnswer == GameControllerMathGame.Instance.Answer)
        {
            GameControllerMathGame.Instance.correctAudioClip();
            GetComponent<TMP_Text>().color = Color.green;
            enabled = false;
            GameControllerMathGame.Instance.HandleCorrectAnswerClick();
        }
        else
        {
            GameControllerMathGame.Instance.wrongtAudioClip();
            GetComponent<TMP_Text>().color = Color.red;
            enabled = false;
        }
    }


    public void SetNumber(int number)
    {
        enabled = true;
        GetComponent<TMP_Text>().color = Color.white;
        randomAnswer = number;
        GetComponent<TMP_Text>().text = randomAnswer.ToString();

    }
}
