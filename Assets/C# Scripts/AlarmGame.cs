using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlarmGame : MonoBehaviour 
{
	public GameObject hand;
	public GameObject alarmClock;
	public int randomHits;
	public float speed = 1;
	public bool moveHand = false;
	private Vector3 handVector;
	private bool victoryBool = false;
	private Vector3 startVector = new Vector3 (-4,128, 0);	
	public GameObject defeatBanner;
	public GameObject victoryBanner;
	public bool EndingTime= false;
	public PlayerTime playerTime;
	// Use this for initialization
	void Start () {
		randomHits = Random.Range (3, 10);
		startVector = hand.transform.position;
		speed = Vector3.Distance (alarmClock.transform.position, hand.transform.position) / .3f;
		defeatBanner.SetActive (false);
		victoryBanner.SetActive (false);
	
	}


	// Update is called once per frame
	void Update () {
		if (playerTime.playTime <= 0){
			defeatBanner.SetActive (true);
			return;
		}
		float step = speed * Time.deltaTime;
		if (Input.GetKeyUp (KeyCode.A) ) {
			TakeHits ();
		}
		if (moveHand) {
			hand.transform.position = Vector3.MoveTowards(hand.transform.position,handVector,step);
			if (hand.transform.position == handVector && !victoryBool) {
				hand.transform.position = startVector;
				moveHand = false;
			} else if (hand.transform.position == handVector && victoryBool) {
				victoryBanner.SetActive (true);		
			}
		}
	
	}

	public void TakeHits () {
		int randomY;
		if (!moveHand) {
			randomHits--;
			}
		if (randomHits > 0 && !moveHand) {
			handVector = new Vector3 
				(alarmClock.transform.position.x+Random.Range (-200,200), alarmClock.transform.position.y);
			moveHand = true;
		} else if (randomHits <= 0 && !moveHand) {
			handVector = new Vector3 
				(alarmClock.transform.position.x * 1.4f,alarmClock.transform.position.y * 1.5f);
			moveHand = true;
			victoryBool = true;
			Debug.Log("Ganaste!!! pinche luis verga!");
		}
	}
}
