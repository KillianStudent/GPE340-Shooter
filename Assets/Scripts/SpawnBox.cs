using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    // TODO: finish singleton, get player transform from singleton, fix miscellaneous files on this file

    public Vector3 scale;
    public float spawnDelay;
    public int currentActiveEnemies;
    public int maxActiveEnemies;
    public GameObject enemyPrefab;
    public AIController aiController;
    private bool spawningEnemies = true;

    private void Start()    // starts spawning the enemies in 0 seconds with a delay of spawnDelay
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentActiveEnemies >= maxActiveEnemies)   // if the function tries to spawn an enemy while there are too many enemies, return.
            return;

        currentActiveEnemies++;
        GameObject enemy = Instantiate(enemyPrefab, this.transform.position, this.transform.rotation) as GameObject;
        enemy.GetComponent<Health>().onDie.AddListener(HandleEnemyDeath);
        enemy.GetComponent<AIPawn>().aiController = aiController;


        if (currentActiveEnemies >= maxActiveEnemies)   // when the max number of enemies is hit, the enemies stop spawning
        {
            CancelInvoke("SpawnEnemy");
            spawningEnemies = false;
        }
    }

    private void HandleEnemyDeath() // function that is called to handle when the enemy dies, subtracting from the active number of enemies
    {
        currentActiveEnemies--;
        if (spawningEnemies == false)   // checks if the enemies are not spawning anymore, and sets it to spawn again if it is not
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
            spawningEnemies = true;
        }
    }

    private void OnDrawGizmos() // gizmos to draw a red sphere on the spawner's area
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.gameObject.transform.position, 1);
    }
}
