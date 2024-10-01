using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [Header("HitScan Variables")]
    bool canPickup = true; // false if holding something already
    bool isRunning; // checks to see if coroutine is running

    [Header("Highlight Variables")]
    private Color highlightColor = Color.grey;
    private List<Material> materials;
    private  GameObject highlightedObject;
    private GameObject pickedupObject;

    [Header("Interactable Variables")]
    [SerializeField] TextMeshProUGUI popupText;
    [SerializeField] GameObject popupMenu;

    [Header("Door Variables")]
    Animator doorAnimator;

    [Header("Sound")]
    [SerializeField] AudioSource close;
    [SerializeField] AudioSource open;


    bool canChange = true;
    private void Update()
    {
        HitScan();
        if (Input.GetMouseButtonDown(1))
        {
            if (canPickup && highlightedObject != null) { Pickup(); }
            else { Place(); }
        }

        // Shows the pickedup object in hand
        if (!canPickup)
        {
            pickedupObject.transform.position = Camera.main.transform.position + 
                Camera.main.transform.forward * 1 + Camera.main.transform.right * 1;
            pickedupObject.transform.rotation = Camera.main.transform.rotation;
        }

        // Interacts with objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (highlightedObject.tag == "Door" && canChange)
            {
                doorAnimator = highlightedObject.GetComponentInParent<Animator>();

                if (doorAnimator.GetBool("isOpen")) { open.Play(); }
                else { close.Play(); }

                doorAnimator.SetBool("isOpen", !doorAnimator.GetBool("isOpen"));
                StartCoroutine(WaitForAnimation());
            }
        }
    }

    private void Pickup()
    {
        // Picks up highlighted object
        if (canPickup && highlightedObject.tag == "Selectable")
        {
            canPickup = false;
            pickedupObject = highlightedObject;
            highlightedObject = null;
        }
    }
    private void Place()
    {
        if (pickedupObject != null) {
            pickedupObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3;
            pickedupObject = null;
            canPickup = true;
        }
    }
    void HitScan()
    {
        // Finds objects that will be hit by raycast
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;

        //-- Highlights objects to be picked up -- //
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Selectable" && hit.distance < 3)
        {
            Debug.Log("hit scanned something" + hit.collider.gameObject);
            ToggleHighlight(hit.collider.gameObject);

            popupText.text = "Right click to pick up";
            if (!isRunning) { StartCoroutine(FadeMenu()); }
        }
        else if (highlightedObject != null && highlightedObject != pickedupObject)
        {
            foreach (var material in materials)
            {
                material.DisableKeyword("_EMISSION");
            }
            highlightedObject = null;
        }


        //-- Highlights doors --//
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Door" && hit.distance < 5)
        {
            ToggleHighlight(hit.collider.gameObject);

            popupText.text = "Press E to interact";
            if (!isRunning) { StartCoroutine(FadeMenu()); }
        }
    }

    public void ToggleHighlight(GameObject newObject)
    {
        // Highlights the raycast object
        materials = newObject.GetComponent<Renderer>().materials.ToList();

        foreach (var material in materials)
        {
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", highlightColor);
        }

        highlightedObject = newObject; // stores highlighted object.
    }

    IEnumerator FadeMenu()
    {
        Image fader = popupMenu.GetComponent<Image>();
        float transparencyMenu;
        float transparencyText;
        float transition;
        float max = 0.5f;
        float min = 0;
        isRunning = true;

        if (fader.color.a == 0) // fade in
        {
            transparencyMenu = 0;
            transparencyText = 0;
            transition = .01f;
        }
        else // fade out
        {
            transparencyMenu = .48f;
            transparencyText = .96f;
            transition = -.01f;
        }

        // Fades the menu and text out or in
        while (transparencyMenu >= min && transparencyMenu <= max)
        {
            transparencyMenu += transition;
            transparencyText += transition * 2;
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, transparencyMenu);
            popupText.color = new Color(255, 0, 0, transparencyText);

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5);

        if (transition == .01f) {  StartCoroutine(FadeMenu()); }
        else { isRunning = false; fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, 0); }
    }

    IEnumerator WaitForAnimation()
    {
        canChange = false;
        yield return new WaitForSeconds(3);
        canChange = true;
    }
}
