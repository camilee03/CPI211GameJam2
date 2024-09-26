using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("HitScan Variables")]
    bool canPickup = true; // false if holding something already


    [Header("Highlight Variables")]
    private Color highlightColor = Color.grey;
    private List<Material> materials;
    private GameObject highlightedObject;
    private GameObject pickedupObject;

    private void Update()
    {
        HitScan();
        if (Input.GetMouseButtonDown(0))
        {
            if (canPickup && highlightedObject != null) { Pickup(); }
            else { Place(); }
        }

        // Shows the pickedup object in hand
        if (!canPickup)
        {
            pickedupObject.transform.position = Camera.main.transform.position + 
                Camera.main.transform.forward * 2 + Camera.main.transform.right * 1;
            pickedupObject.transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void Pickup()
    {
        // Picks up highlighted object
        if (canPickup)
        {
            canPickup = false;
            pickedupObject = highlightedObject;
            pickedupObject.transform.localScale /= 1.2f;
            highlightedObject = null;
        }
    }
    private void Place()
    {
        if (pickedupObject != null) {
            pickedupObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3;
            pickedupObject.transform.localScale *= 1.2f;
            pickedupObject = null;
            canPickup = true;
        }
    }

    void HitScan()
    {
        // Finds objects that will be hit by raycast
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Selectable" && hit.distance < 3)
        {
            Debug.Log("hit scanned something" + hit.collider.gameObject);
            ToggleHighlight(hit.collider.gameObject);
        }
        else if (highlightedObject != null && highlightedObject != pickedupObject)
        {
            foreach (var material in materials)
            {
                material.DisableKeyword("_EMISSION");
            }
            highlightedObject = null;
        }
    }

    public void ToggleHighlight(GameObject gameObject)
    {
        // Highlights the raycast object
        materials = gameObject.GetComponent<Renderer>().materials.ToList();

        foreach (var material in materials)
        {
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", highlightColor);
        }
        highlightedObject = gameObject;
    }

}
