using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BeatScripts : MonoBehaviour
{
    public KeyCode key;
    bool activeHit = false;
    bool successHit = false;
    GameObject noteObj;
    [SerializeField] AudioSource aNoteHit;
    [SerializeField] AudioSource aNoteFail;
    [SerializeField] MusicSyncBPM MusicController;
    [SerializeField] Animation textAnim;
    [SerializeField] Text textHit;

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(key) && activeHit)
        {
            successHit = true;
            aNoteHit.Play();
            if (noteObj.transform.localScale.z > 0.80)
            {
                GlobalValues.ScoreHit++;
                textHit.text = "Perfect!";
                textAnim.Play();
            }
            else
            {
                GlobalValues.ScoreEarly++;
                textHit.text = "Early!";
                textAnim.Play();
            }
            Destroy(noteObj);            
        }    
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        activeHit = true;
        if (col.gameObject.tag == "Note")
        {
            noteObj = col.gameObject;            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (successHit)
        {
            GlobalValues.ScoreHit++;            
            successHit = false;
        }
        else
        {
            textHit.text = "Miss!";
            textAnim.Play();
            GlobalValues.ScoreMiss++;
            MusicController.lifeDamage();
            aNoteFail.Play();
        }
        
        activeHit = false;
    }
}
