using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static string musicTrack = "";
    public static float musicBPM = 0;

    public static int ScoreHit = 0;
    public static int ScorePerfect = 0;
    public static int ScoreEarly = 0;
    public static int ScoreMiss = 0;

    public static void ScoreReset()
    {
        ScoreHit = 0;
        ScorePerfect = 0;
        ScoreEarly = 0;
        ScoreMiss = 0;
    }
}
