using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		animator.SetFloat("horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));
		animator.SetFloat("vertical", Mathf.Abs(Input.GetAxis("Vertical")));
	}
}
