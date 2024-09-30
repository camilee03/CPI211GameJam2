using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    [SerializeField] Transform[] animalLocations;
    [SerializeField] GameObject[] animalObjects;

    private void Start()
    {
        foreach (GameObject animal in animalObjects) {  SpawnAnimal(animal); }
    }
    public void SpawnAnimal(GameObject animal) {
        int spawnLocation = Random.Range(0, animalLocations.Length);

        animal.transform.position =  animalLocations[spawnLocation].position;
    }
}
