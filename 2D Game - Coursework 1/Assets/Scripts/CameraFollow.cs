using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject followObject;
	public Vector2 followOffset;
	private Vector2 threshold;
	private float idealCameraSpeed = 0.175f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		threshold = calculateThreshold();
		rb = followObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 v = Vector3.zero;
		Vector2 follow = followObject.transform.position;
		float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
		float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

		Vector3 newPosition = transform.position;

		//Ensures the camera is centered with the player vertically at all times
		newPosition.y = follow.y - followOffset.y;
		transform.position = newPosition;

		if (Mathf.Abs(xDifference) >= threshold.x)
        {
			newPosition.x = follow.x;
        }

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref v, idealCameraSpeed);
	}

	private Vector3 calculateThreshold()
    {
		Rect aspect = Camera.main.pixelRect;
		Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
		t.x -= followOffset.x;
		t.y -= followOffset.y;
		return t;
	}

	private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Vector2 border = calculateThreshold();
		Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));


		Gizmos.color = Color.blue;
		Vector2 border2 = calculateThreshold();
		Gizmos.DrawWireCube(transform.position, new Vector3(Camera.main.pixelRect.x, Camera.main.pixelRect.y, 1));
	}
}
