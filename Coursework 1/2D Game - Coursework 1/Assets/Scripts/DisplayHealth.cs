﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {

    Text txt;
    private GameObject go;
    public GameStatus gs;
    private float initHealth = 100f;

    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("GameStatus");
        gs = go.GetComponent<GameStatus>();

        txt = gameObject.GetComponent<Text>();
        txt.text = "Health:    " + initHealth;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Health:    " + gs.health;
    }
}