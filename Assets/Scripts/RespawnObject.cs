using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public GameObject objectToRespawn;  // object to be respawning, must be set in the inspector
    public float respawnDelay = 1;  // designer set time for respawning an object, default of 1
    private GameObject spawnedObject; // spawned object tracked in the respawn point empty object

    public void Start()
    {
        startTimer();   // timer to spawn the object initially
    }

    public void startTimer()
    {
        StartCoroutine(respawnWait());

    }

    public void respawnObject()
    {
        spawnedObject = Instantiate(objectToRespawn) as GameObject; // creates an object from a prefab
        spawnedObject.GetComponent<startRespawnTimer>().respawnPoint = this.gameObject; // sets the respawnPoint of the object spawned to this object
        spawnedObject.transform.position = this.transform.position; // sets the spawned object to the spawn point's position
    }
    public IEnumerator respawnWait()    // IEnumerator for waiting a moment before respawning an object
    {
        yield return new WaitForSeconds(respawnDelay);
        spawnedObject = null;
        respawnObject();
    }
}
