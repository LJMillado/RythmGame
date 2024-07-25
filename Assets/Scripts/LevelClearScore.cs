using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelClearScore : MonoBehaviour
{
    [SerializeField] private Text textHit;
    [SerializeField] private Text textPerf;
    [SerializeField] private Text textEarly;
    [SerializeField] private Text textMiss;
    // Start is called before the first frame update
    void Start()
    {
        textHit.text = "HIT : " + GlobalValues.ScoreHit.ToString();
        textHit.text = "PERFECT : " + GlobalValues.ScorePerfect.ToString();
        textHit.text = "EARLY : " + GlobalValues.ScoreEarly.ToString();
        textHit.text = "MISS : " + GlobalValues.ScoreMiss.ToString();
    }
}
