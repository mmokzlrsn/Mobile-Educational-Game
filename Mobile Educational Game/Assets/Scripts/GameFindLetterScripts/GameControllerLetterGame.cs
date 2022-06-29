using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControllerLetterGame : MonoBehaviour
{
    public static GameControllerLetterGame Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>(); // to handle audio things
    }

    public char Letter = 'a'; //the game starts with a always and goes like that

    [SerializeField] List<AudioClip> _audioClips;

    AudioSource _audioSource; //sound clips

    int correctClicks; //if correct clicks are equal to correctanswers it will move to next letter
    int correctAnswers = 2; //correct answer count will generate that much the current letter
    

    void OnEnable()
    {
        GenerateBoard();
        UpdateDiplayLetters();
    }

    private void MoveToNextLetter()
    {
        Letter++;

        var clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString());
        if (clip == null)
            Letter = 'a';

    }

    private char ChooseInvalidRandomLetter()
    {
        var randomLetter = (char)('a' + UnityEngine.Random.Range(0, 26));

        while (randomLetter == Letter)
        {
            randomLetter = (char)('a' + UnityEngine.Random.Range(0, 26));
        }

        return randomLetter;
    }

    private void UpdateDiplayLetters()
    {
        foreach (var displayletter in FindObjectsOfType<DisplayLetter>())
        {
            displayletter.SetLetter(Letter);
        }
    }



    void GenerateBoard() //this will generate a board when we start a game and when we move to next letter
    {
        List<char> charsList = new List<char>(); //the letters are inside of this list to check whater or not we have same number of letter with the current target
        correctAnswers = Random.Range(2, Letter/ 14 );
        var clickables = FindObjectsOfType<ClickableLetter>();

        for (int i = 0; i < correctAnswers; i++)
        {
            charsList.Add(Letter); //if we dont have that much correct letter it will add to list
        }

        for (int i = correctAnswers; i < clickables.Length; i++)
        {
            var chosenLetter = ChooseInvalidRandomLetter();
            charsList.Add(chosenLetter);
        }

        charsList = charsList
            .OrderBy(t => UnityEngine.Random.Range(0, 10000))
            .ToList();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetLetter(charsList[i]);
        }

        FindObjectOfType<RemainingCounterText>().SetRemaining(correctAnswers - correctClicks);

    }

    internal void HandleCorrectLetterClick(bool upperCase)
    {
        
        var clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString());
        if (upperCase)
            clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString() + Letter.ToString());

        _audioSource.PlayOneShot(clip);
        
        correctClicks++;
        FindObjectOfType<RemainingCounterText>().SetRemaining(correctAnswers - correctClicks);
        if (correctClicks >= correctAnswers)
        {
            MoveToNextLetter();
            UpdateDiplayLetters();
            correctClicks = 0;
            GenerateBoard();
        }
    }

    
}