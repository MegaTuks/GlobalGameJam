using UnityEngine;
using System.Collections;

public class EnterIcon : MonoBehaviour {

	public CharacterWalk player;
	public CameraMovement camera;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<CameraMovement> ();
		player = FindObjectOfType<CharacterWalk> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (-19000,0, 0);
		if (camera.focused) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 900, 0);
		}
	}
}
