using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSyncBPM : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject BeatPos1;
    [SerializeField] private GameObject BeatPos2;
    [SerializeField] private GameObject BeatPos3;
    [SerializeField] private GameObject BeatPos4;    
    [SerializeField] private GameObject BeatObj;
    [SerializeField] private Text uiLife;
    [SerializeField] private int PlayerLife = 3;
    [SerializeField] private Intervals[] _intervals; // array of serializable method below to check if it hits the beat from 4/4 or half step
    private int beatCount = 0;
    private string filePath;    
    private List<string> BeatMap = new List<string>();

    void Start()
    {
        uiLife.text = "LIVES:" + PlayerLife.ToString();
        filePath = Application.dataPath + "/Map/" + GlobalValues.musicTrack +".txt";
        _bpm = GlobalValues.musicBPM;
        BeatMap.Add("000");
        readBeatmap();
    }

    void Update()
    {
        //This is just something optional whenever I want to maybe make something that detects 2/4 or 1/4 steps just scaled it back to 1 for now
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetBeatLength(_bpm)));
            interval.CheckForNewInterval(sampledTime);
        }       
    }

    //Runs every BPM to check the map
    public void BeatCounter()
    {
        beatCount++;
        //_testaudioSource.Play();
        if (beatCount == BeatMap.Count() - 1)
        {
            SceneManager.LoadScene("GameFinishedScreen");
        }

        if(beatCount < BeatMap.Count())
        {
            //check the four numbers if it would fill any of the four beat node
            string currentMap = BeatMap[beatCount];
            //Debug.Log(beatCount);
            if (currentMap[1] != '0')
            {                
                spawnBeat(1);
            }
            if (currentMap[2] != '0')
            {                
                spawnBeat(2);
            }
            if (currentMap[3] != '0')
            {                
                spawnBeat(3);
            }
            if (currentMap[4] != '0')
            {                
                spawnBeat(4);
            }
        }        
    }

    public void lifeDamage()
    {        
        PlayerLife--;
        if (PlayerLife > 0) 
        { 
            uiLife.text = "LIVES:" + PlayerLife.ToString();
        }
        else
        {
            SceneManager.LoadScene("GameOverScreen");
        }

    }

    //Spawning of the beat circles
    private void spawnBeat(int iPos)
    {
        switch (iPos)
        {
            case 1:             
                Instantiate(BeatObj, BeatPos1.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(BeatObj, BeatPos2.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(BeatObj, BeatPos3.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(BeatObj, BeatPos4.transform.position, Quaternion.identity);
                break;
        }
    }

    private void readBeatmap()
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach(string line in lines)
        {
            //Debug.Log(line);            
            BeatMap.Add(line.Substring(3));
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;

    public float GetBeatLength(float bpm)
    {
        return 60f / (bpm * _steps);
    }

    public void CheckForNewInterval(float interval)
    {
        //make sure to check this one if it repeated as to avoid hitting the same 1/4, 2/4, 3/4, 4/4 metro
        if(Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}