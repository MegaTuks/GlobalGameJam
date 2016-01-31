using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public CharacterWalk player;

	public bool isFollowing;
	public bool focused;

	public float xOffset;
	public float yOffset;
	public float firstZ;
	public float closeupZ;

	public float meh;
	public Bounds bounds;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<CharacterWalk> ();
		//Camera.main.aspect = 16f / 9f;
		firstZ = transform.position.z;
		closeupZ = 2*firstZ / 3;
		isFollowing = true;

	}


	// Update is called once per frame
	void Update () {

		/*
		isFollowing = false;
		meh = transform.position.x - Camera.main.pixelWidth/2;

		if (transform.position.x - Camera.main.pixelWidth/2 > player.transform.position.x ) {
			isFollowing = true;
		}
		*/

		if (isFollowing)
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
		if (focused) {
			if (transform.position.z < closeupZ)
				transform.position = new Vector3 (transform.position.x ,transform.position.y, transform.position.z + 20*(transform.position.z/closeupZ));
		} else {
			if (transform.position.z > firstZ)
				transform.position = new Vector3 (transform.position.x ,transform.position.y, transform.position.z - 18*(firstZ /transform.position.z));
		}

	}
}
