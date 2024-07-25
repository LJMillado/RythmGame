using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDeath : MonoBehaviour
{ 
    //if time ends it kill it self as a miss
    public void killSelf()
    {
        Destroy(gameObject);
    }
}
