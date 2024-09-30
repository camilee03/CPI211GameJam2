using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    //Store global data like lives left and stuffed animals collected
    public int playerLives = 3;
    public bool stuffy1Collected = false;
    public bool stuffy2Collected = false;
    public bool stuffy3Collected = false;
    public bool stuffy4Collected = false;
    public bool stuffy5Collected = false;

    //used to check if the player has won - run when animals are collected
    public bool winCondition ()
    {
        if (stuffy1Collected && stuffy2Collected && stuffy3Collected && stuffy4Collected && stuffy5Collected)
        {
            return true;
            //Could add the transition for the win here - we don't need to return much of anything if the game is ending after all
        }
        else
        {
            return false;
        }
    }

    //called by the demon to end the game / take a life
    public void playerCaught()
    {
        playerLives--;

        if ( playerLives <= 0)
        {
            //end the game, pop up the jumpscare image & play the sfx (add a reference to the player if needed)
        }
        else
        {
            //fade to black, jumpscare sound, send the player back to spawn (the bed)
        }
    }
}
