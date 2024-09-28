using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private NavMeshAgent demon;
    void Start()
    {
        demon = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        demon.destination = target.position;
    }
}
