using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] GameObject newCamera;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            newCamera.SetActive(true);
            this.gameObject.SetActive(false); 
        }
    }
}
