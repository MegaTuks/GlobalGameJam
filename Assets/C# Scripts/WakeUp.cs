using UnityEngine;
using System.Collections;

public class WakeUp : MonoBehaviour {

    public GameObject upLid;
    public GameObject downLid;
    public int speed;
    public int position;
    public int openSpeed;
    public PlayerTime playerTime;
    private bool lost;
    public GameObject winBanner;
    public GameObject defeatBanner;
    // Use this for initialization
    void Start () {
        lost = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerTime.playTime > 0 && !lost)
        {
            upLid.transform.Translate(0, -speed, 0);
            downLid.transform.Translate(0, speed, 0);
            if (Input.GetMouseButtonDown(0))
            {
                upLid.transform.Translate(0, openSpeed, 0);
                downLid.transform.Translate(0, -openSpeed, 0);
                position += openSpeed;
            }
            position -= speed;
            if (position < 0)
            {
                lost = true;
                defeatBanner.SetActive(true);
            }
        }
        else if (!lost)
        {
            winBanner.SetActive(true);
        }
    }
}
