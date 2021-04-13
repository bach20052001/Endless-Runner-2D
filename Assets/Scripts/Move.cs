using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 35 ;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x < -12 && this.gameObject.CompareTag("Obstacle"))
            {
                Destroy(this.gameObject);
            }
        }         
    }
}
