using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLives : MonoBehaviour
{

    Text txt;
    private GameObject go;
    public GameStatus gs;
    private float initLives = 100f;

    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("GameStatus");
        gs = go.GetComponent<GameStatus>();

        txt = gameObject.GetComponent<Text>();
        txt.text = "Lives:      " + initLives;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Lives:      " + gs.lives;
    }
}
