using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPosition;
    private float RepeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < StartPosition.x - RepeatWidth)
        {
            transform.position = StartPosition;
        }
    }
}
