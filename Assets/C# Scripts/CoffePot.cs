using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class CoffePot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private bool dragged;
    private Vector3 start;
    public GameObject bar;
    public GameObject cup;
    private int timeshiftIni;
    public int timeshift;
    public int cupSpeed;
    public PlayerTime playerTime;
    public GameObject defeatBanner;
    public GameObject defeatBanner2;
    public GameObject winBanner;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (playerTime.playTime > 0)
        {
            transform.Rotate(new Vector3(0, 0, 45));
            start = transform.position;
            dragged = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (playerTime.playTime > 0)
        {
            transform.position = new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (playerTime.playTime > 0)
        {
            transform.position = start;
            transform.Rotate(new Vector3(0, 0, -45));
            dragged = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        dragged = false;
        bar.GetComponent<Image>().fillAmount = 0;
        timeshiftIni = timeshift;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTime.playTime > 0)
        {
            if (dragged)
            {
                if ((Mathf.Abs(this.transform.position.x - this.GetComponent<RectTransform>().rect.width / 2 -
                    cup.transform.position.x)) <= cup.GetComponent<RectTransform>().rect.width / 2)
                {
                    bar.GetComponent<Image>().fillAmount += 0.003f;
                }
            }
            cup.transform.Translate(cupSpeed, 0, 0);
            timeshift--;
            if (timeshift <= 0)
            {
                timeshift = timeshiftIni;
                cupSpeed *= -1;
            }
        }
        else
        {
            if (bar.GetComponent<Image>().fillAmount < 0.9f && bar.GetComponent<Image>().fillAmount > 0.7f)
            {
                winBanner.SetActive(true);
            }
            else if (bar.GetComponent<Image>().fillAmount > 0.9f)
            {
                defeatBanner2.SetActive(true);
            }
            else
            {
                defeatBanner.SetActive(true);
            }
        }
    }
}
