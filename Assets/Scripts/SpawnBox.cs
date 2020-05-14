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

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentActiveEnemies >= maxActiveEnemies)
            return;

        currentActiveEnemies++;
        GameObject enemy = Instantiate(enemyPrefab, this.transform.position, this.transform.rotation) as GameObject;
        enemy.GetComponent<Health>().onDie.AddListener(HandleEnemyDeath);
        enemy.GetComponent<AIPawn>().aiController = aiController;


        if (currentActiveEnemies >= maxActiveEnemies)
        {
            CancelInvoke("SpawnEnemy");
            spawningEnemies = false;
        }
    }

    private void HandleEnemyDeath()
    {
        currentActiveEnemies--;
        if (spawningEnemies == false)
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
            spawningEnemies = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.Lerp(Color.cyan, Color.clear, 0.5f);
        Gizmos.DrawCube(Vector3.up * scale.y / 2f, scale);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.4f);
    }
}
