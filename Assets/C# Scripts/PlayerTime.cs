using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour {
	
	// Time variables
	public float playTime;
	public float waitTime;
	// Game object variables
	public GameObject label;

	// Time variables
	private int seconds;
	private int minutes;
	private int hours;
	private int days;
	void Start () 
	{
		minutes = (int) playTime / 60;
		seconds = (int) playTime % 60;
	}
	
	// Update is called once per frame
	void Update () 
	{	if(playTime > 0) {
			waitTime -= Time.deltaTime;
			if (waitTime < 0) {
				playTime -= Time.deltaTime;
			}
		}
		CountDown ();
	}
	private void CountDown ()
	{	
		/*if(waitTime <= 0){
			instruct.SetActive (false);
		}*/
		if (playTime > 0){
			minutes = (int) playTime / 60;
			seconds = (int) playTime % 60; 
			label.transform.GetComponent<Text>().text = minutes.ToString("00") 
				+ ":" + seconds.ToString("00");
		}
		
	}
}
