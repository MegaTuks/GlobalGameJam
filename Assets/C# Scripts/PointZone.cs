using UnityEngine;
using System.Collections;

public class PointZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.contacts);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Im hit! " + other.name);
    }

}
