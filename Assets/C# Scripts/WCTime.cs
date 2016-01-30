using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WCTime : MonoBehaviour
{

    public GameObject bar;
    public float speed;
    public float openSpeed;
    public PlayerTime playerTime;
    private bool win;
    public GameObject winBanner;
    public GameObject defeatBanner;
    // Use this for initialization
    void Start()
    {
        win = false;
        bar.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTime.playTime > 0 && !win)
        {
            if (bar.GetComponent<Image>().fillAmount > 0)
            {
                bar.GetComponent<Image>().fillAmount -= speed;
            }
            if (Input.GetMouseButtonDown(0))
            {
                bar.GetComponent<Image>().fillAmount += openSpeed;
                if (bar.GetComponent<Image>().fillAmount >= 1)
                {
                    win = true;
                }
            }
        }
        else if (win)
        {
            winBanner.SetActive(true);
        }
        else
        {
            defeatBanner.SetActive(true);
        }
    }
}
