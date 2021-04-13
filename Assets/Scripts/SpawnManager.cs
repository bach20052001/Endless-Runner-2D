using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public Transform Obstacles;
    public List<GameObject> obstacles = new List<GameObject>();
    private float StartDelay = 0;
    private float Interval = 2f;
    private Vector3 offset = new Vector3(25, 0, 0);
    private PlayerController playerController;

    private int numberOfObstacles;
    // Start is called before the first frame update
    void Start()
    {
        numberOfObstacles = obstacles.Count;
        InvokeRepeating(nameof(Spawn), StartDelay, Interval);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Spawn()
    {
        if (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            offset = new Vector3(Random.Range(15, 25), 0, 0);
            GameObject newObstacle = Instantiate(obstacles[Random.Range(0, numberOfObstacles)], offset, Quaternion.identity, Obstacles);
            newObstacle.AddComponent<Move>();
        }
    }
}
