using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

    Text txt;
    private GameObject go;
    public GameStatus gs;
    private float initScore = 0f;

    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("GameStatus");
        gs = go.GetComponent<GameStatus>();

        txt = gameObject.GetComponent<Text>();
        txt.text = "Score:            " + initScore;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Score:            " + gs.score;
    }
}
