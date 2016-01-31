using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	public string labelText = "";
	public bool hasCollided = false;
	public string destination;


	public CameraMovement camera;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<CameraMovement> ();
	}

	void Update(){
		if (hasCollided) {
			if (Input.GetKey (KeyCode.Return))
				{
			Application.LoadLevelAsync (destination);
				}

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<CharacterWalk> () == null)
			return;

		hasCollided = true;
		camera.focused = true;
		labelText = "Interact!";
	}

	void OnTriggerExit2D (Collider2D other)
	{
		hasCollided = false;
		camera.focused = false;
	}

}
