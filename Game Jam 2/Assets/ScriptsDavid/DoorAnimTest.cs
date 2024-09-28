using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimTest : MonoBehaviour

    //this is just a script for testing the door animations and open/close sounds.
    //we need to trigger these events with the player's cursor instead.
    //When that is done, delete this script and remove it from any pivots. -David
{
    // Start is called before the first frame update
    private Animator animator;
    public AudioSource audio;
    public AudioClip open;
    public AudioClip close;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            PlayOpenAnimation();
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            PlayCloseAnimation();
        }
    }

    public void PlayOpenAnimation() {

        animator.Play("DoorOpen");
        audio.PlayOneShot(open);
    
    }

    public void PlayCloseAnimation() {

        animator.Play("DoorClose");
        audio.PlayOneShot(close);


    }
}
