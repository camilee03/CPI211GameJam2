using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFXs : MonoBehaviour
{
    [SerializeField] AudioSource[] sfxs;
    int soundPos;
    bool playSound;

    private void Update()
    {
        if (playSound) { StartCoroutine(Play()); }
    }

    IEnumerator Play()
    {
        playSound = false;
        sfxs[soundPos].Play();
        if (soundPos < sfxs.Length) { soundPos++; }
        else {  soundPos = 0; }

        yield return new WaitForSeconds(5);
        playSound = true;
    }
}
