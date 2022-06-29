using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEquation : MonoBehaviour
{
    internal void SetEquation(int number1, int number2, int operation)
    {
        if(operation == 1)
            GetComponent<TMP_Text>().text =
            number1.ToString() +
            "+" +
            number2.ToString();
        else
            GetComponent<TMP_Text>().text =
            number1.ToString() +
            "-" +
            number2.ToString();
    }
}
