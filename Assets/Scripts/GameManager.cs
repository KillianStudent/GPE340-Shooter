using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    public GameObject player;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private GameObject[] enemySpawnPoints;
    [SerializeField] private AIController aiController;
    public bool isPaused = false;
    public int Lives = 3;
    public Camera gameCamera;
    
    [SerializeField] private Text playerHealthText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPlayer", 2);
        foreach (GameObject spawnPoint in enemySpawnPoints)
        {
            spawnPoint.GetComponent<SpawnBox>().aiController = aiController;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            HandlePause();
        }
    }

    private void HandlePause()
    {
        if (isPaused)
            UnPause();
        else
            Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0; // pauses time, pausing the game
        isPaused = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    private void HandlePlayerDeath()
    {
        if (Lives > 0)
        {
            Invoke("SpawnPlayer", 1);
            Lives--;
        }
        else
        {
            //TODO: Game over
        }
    }

    void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.transform.rotation) as GameObject;   // sets the player to an instantiated player prefab at the playerSpawnPoint position
        player.GetComponent<TurnToMouse>().camera = gameCamera;
        gameCamera.GetComponent<CameraController>().target = player.transform;  // sets the camera's target to the player
        aiController.target = player.transform; // sets the AIcontroller to target the player
        playerHealthText.GetComponent<UIHealthText>().pawnHealth = player.GetComponent<Health>();
    }
}
