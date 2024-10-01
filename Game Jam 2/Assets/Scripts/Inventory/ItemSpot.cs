using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSpot : MonoBehaviour
{
    [SerializeField] string objectName;
    [SerializeField] GameObject nextLocation;
    [SerializeField] TMP_Text instructions;
    [SerializeField] Globals global;

    private void Start()
    {
        instructions = GetComponentInChildren<TMP_Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.gameObject.name);
        if (collision.collider.tag == "Selectable" && collision.collider.name == objectName)
        {
            instructions.gameObject.SetActive(false);
            if (nextLocation != null) { nextLocation.SetActive(true); }
            else { global.WinCondition(); } // has collected all the animals
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == objectName)
        {
            instructions.gameObject.SetActive(true);
        }
    }
}
