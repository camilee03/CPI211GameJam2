using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonManager : MonoBehaviour
{
    //A AI director script that tries to manage the target point for demon movement
    //The demon should only know of the player based off of their actions / detection
    //If a player is in hiding the location will not update, even if it otherwise would
    //The demon should only stick around to look for the player for a brief time, before wandering back towards a demon point
    //If the player grabs a stuffed animal, update the last known position so the demon wanders over "coincidentally"
    //Also, scale demon speed if the player is farther away so it can catch up to them
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
