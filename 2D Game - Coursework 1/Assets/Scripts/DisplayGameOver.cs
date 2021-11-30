using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGameOver : MonoBehaviour
{

    Text txt;
    private GameObject go;
    public GameStatus gs;

    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("GameStatus");
        gs = go.GetComponent<GameStatus>();

        txt = gameObject.GetComponent<Text>();
        txt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gs.isGameOver && !gs.hasWon)
        {
            txt.enabled = gs.isGameOver;
        }   
    }
}
