using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{
    public void firstSong()
    {
        GlobalValues.ScoreReset();
        GlobalValues.musicTrack = "Taylor Swift";
        GlobalValues.musicBPM = 120;
        SceneManager.LoadScene("GameScene");
    }

}
