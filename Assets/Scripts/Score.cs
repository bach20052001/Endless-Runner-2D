using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float time = 0;
    private TextMeshProUGUI score;
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            score.text = ((int)(time+=Time.deltaTime)).ToString();
        }
    }
}
