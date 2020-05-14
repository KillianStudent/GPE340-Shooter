using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startRespawnTimer : MonoBehaviour
{
    public GameObject respawnPoint;

    public void OnDestroy() // starts the timer to spawn another instance when destroyed
    {
        respawnPoint.GetComponent<RespawnObject>().startTimer();    // starts the startTimer() function in the RespawnObject class
    }
}