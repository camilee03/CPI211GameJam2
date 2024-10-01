using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    [SerializeField] List<Transform> animalLocations;
    [SerializeField] List<Transform> animalLocationsALT;
    [SerializeField] GameObject animalLocationsParent;
    [SerializeField] GameObject[] animalObjects;

    private void Start()
    {
        foreach (Transform t in animalLocationsParent.transform)
        {
            animalLocationsALT.Add(t);
        }

        foreach (GameObject animal in animalObjects) {
            Debug.Log("Animal Locations Count: " + animalLocationsALT.Count);
            Debug.Log("Animal Objects Count: " + animalObjects.Length);
            SpawnAnimal(animal); 
        }
    }
    public void SpawnAnimal(GameObject animal) {
        int spawnLocation = Random.Range(0, animalLocationsALT.Count);

        animal.transform.position =  animalLocationsALT[spawnLocation].position;
    }
}
