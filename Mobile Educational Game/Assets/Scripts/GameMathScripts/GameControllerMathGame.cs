
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControllerMathGame : MonoBehaviour
{

    [SerializeField] List<AudioClip> _audioClips;

    AudioSource _audioSource; //sound clips

    [HideInInspector] // Hides var below
    public int Number1;
    [HideInInspector] // Hides var below
    public int Number2;
    [HideInInspector] // Hides var below
    public int Operation;
    [HideInInspector] // Hides var below
    public int Answer;

    int correctAnswers = 1;

    int correctClicks;

    int correctClicksText = 0;

    int maxRange = 10;


    public static GameControllerMathGame Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>(); // to handle audio things
    }

    private void OnEnable()
    {
        GenerateEquation();
        Calculate();
        GenerateBoard();
        UpdateDisplayAnswers();
    }

  

    private void GenerateBoard()
    {
        var clickables = FindObjectsOfType<ClickableAnswer>();

        List<int> intList = new List<int>();

        for (int i = 0; i < correctAnswers; i++)
            intList.Add(Answer); //if we dont have correct number

        for (int i = correctAnswers; i < clickables.Length; i++)
        {
            var chosenAnswer = ChooseInvalidRandomAnswer();
            while (intList.Contains(chosenAnswer))
            {
                chosenAnswer = ChooseInvalidRandomAnswer();
            }

            intList.Add(chosenAnswer);
        }

        intList = intList
            .OrderBy(t => UnityEngine.Random.Range(0, 10000))
            .ToList();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetNumber(intList[i]);
        }
    }

    internal void HandleCorrectAnswerClick()
    {
        //clip here
        /*
        var clip = _audioClips.FirstOrDefault(t => t.name == Number.ToString());

        _audioSource.PlayOneShot(clip);
        */

        correctClicks++;
        correctClicksText++;
        FindObjectOfType<CorrectClicksText>().SetCorrectClicksText(correctClicksText);
        if (correctClicks >= correctAnswers)
        {
             
            GenerateEquation();
            UpdateDisplayAnswers();
            correctClicks = 0;
            Calculate();
            GenerateBoard();
        }

    }

  
    private void GenerateEquation()
    {
        Number1 = Random.Range(0, maxRange+ correctClicksText);
        Number2 = Random.Range(0, maxRange+ correctClicksText);
        Operation = Random.Range(1, 3);
    }

    private void UpdateDisplayAnswers()
    {
        foreach (var displayEquation in FindObjectsOfType<DisplayEquation>())
        {
            displayEquation.SetEquation(Number1,Number2,Operation);
        }
    }

    private int ChooseInvalidRandomAnswer()
    {
        
        var answer = UnityEngine.Random.Range(0, maxRange+ correctClicksText);
        while (answer == Answer)
        {
            answer = UnityEngine.Random.Range(0, maxRange+ correctClicksText);
        }

        return answer;
    }

    public void Calculate()
    {

        switch (Operation)
        {
            case 1: //addition
                Answer = Number1 + Number2;
                
                // code block
                break;
            case 2: //subtraction
                Answer = Number1 - Number2;
                // code block
                break;
           
            default:
                Answer = 0;
                break;

        }
    }

    internal void correctAudioClip()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
    }

    internal void wrongtAudioClip()
    {
        _audioSource.PlayOneShot(_audioClips[1]);
    }
}
