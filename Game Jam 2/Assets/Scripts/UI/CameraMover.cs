using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMover : MonoBehaviour
{
    [SerializeField] Transform target;
    float rotationSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Return)) { SceneManager.LoadScene(1); }
    }
}
