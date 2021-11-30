using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc)
        {
            bool pickedUp = pc.pickUp(gameObject);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
