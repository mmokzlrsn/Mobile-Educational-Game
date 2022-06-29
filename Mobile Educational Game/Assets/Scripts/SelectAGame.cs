using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectAGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMathGame()
    {
        SceneManager.LoadScene("GameMath");
    }

    public void LoadFindLetterGame()
    {
        SceneManager.LoadScene("GameFindLetter");
    }

    public void LoadMemoryGame()
    {
        SceneManager.LoadScene("GameMemory");
    }


    public void LoadPuzzleGame()
    {
        SceneManager.LoadScene("GamePuzzle");
    }

    public void LoadFindNumberGame()
    {
        SceneManager.LoadScene("GameFindNumber");
    }


}
