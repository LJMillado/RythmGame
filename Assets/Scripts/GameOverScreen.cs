using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void retry()
    {
        GlobalValues.ScoreReset();
        SceneManager.LoadScene("GameScene");
    }

    public void menu()
    {
        GlobalValues.ScoreReset();
        SceneManager.LoadScene("GameMainMenu");
    }
}
