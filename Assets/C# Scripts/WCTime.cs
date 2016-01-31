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
    public GameObject[] brazos;
    public int tiempoBrazo;
    private int tiempoBrazoInit;
    public GameObject[] cabezas;
    private int indexCabeza;
    private int indexBrazo;

    // Use this for initialization
    void Start()
    {
        win = false;
        bar.GetComponent<Image>().fillAmount = 0;
        indexCabeza = 0;
        indexBrazo = 0;
        for(int i  = 1; i < brazos.Length; i++)
        {
            brazos[i].SetActive(false);
        }
        for (int i = 1; i < cabezas.Length; i++)
        {
            cabezas[i].SetActive(false);
        }
        tiempoBrazoInit = tiempoBrazo;
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
            cabezas[indexCabeza].SetActive(false);
            indexCabeza = (int)(bar.GetComponent<Image>().fillAmount * (cabezas.Length - 1));
            cabezas[indexCabeza].SetActive(true);
            if (tiempoBrazo <= 0)
            {
                brazos[indexBrazo].SetActive(false);
                indexBrazo = (indexBrazo + 1) % brazos.Length;
                brazos[indexBrazo].SetActive(true);
                tiempoBrazo = tiempoBrazoInit;
            }
            tiempoBrazo--;
        }
        else if (win)
        {
            winBanner.SetActive(true);
        }
        else
        {
            defeatBanner.SetActive(true);
            cabezas[indexCabeza].SetActive(false);
            cabezas[cabezas.Length - 2].SetActive(true);
        }
    }
}
