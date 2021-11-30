using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFoundObjects : MonoBehaviour
{

    Text txt;
    private GameObject go;
    public GameStatus gs;
    private float initKeysFound = 0f;

    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("GameStatus");
        gs = go.GetComponent<GameStatus>();

        txt = gameObject.GetComponent<Text>();
        txt.text = "Keys Found:    " + initKeysFound + " / " + gs.totalKeys;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Keys Found:    " + gs.keysFound + " / " + gs.totalKeys;
    }
}