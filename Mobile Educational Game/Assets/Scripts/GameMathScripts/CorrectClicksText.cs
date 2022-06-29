using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectClicksText : MonoBehaviour
{
    internal void SetCorrectClicksText(int correctClicks)
    {
        GetComponent<TMP_Text>().text = "Correct Clicks:" + correctClicks;
    }

    
}
