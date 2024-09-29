using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boyDream : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("boyDream");
    }

  
}
