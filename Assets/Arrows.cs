using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Arrows : MonoBehaviour
{

    private GameObject instance;
    private List<GameObject> arrows;
    public int speed;
    private int separationIni;
    private int separation;
    public Sprite[] images;
    // Use this for initialization
    void Start()
    {
        arrows = new List<GameObject>();
        instance = Instantiate(Resources.Load("Arrow", typeof(GameObject))) as GameObject;
        instance.transform.SetParent(this.transform);
        instance.transform.localScale = new Vector3(1, 1, 1);
        instance.transform.localPosition = new Vector3(this.GetComponent<RectTransform>().rect.width / 2 +
            instance.GetComponent<RectTransform>().rect.width, 0, 0);
        int rand = Random.Range(1, 4);
        instance.GetComponent<Image>().sprite = images[rand];
        arrows.Add(instance);
        separationIni = (int) instance.GetComponent<RectTransform>().rect.width;
        separation = separationIni;
    }
        
    // Update is called once per frame
    void Update()
    {
        for (int i = arrows.Count - 1; i >= 0; i--)
        {
            GameObject obj = arrows[i];
            obj.transform.Translate(-speed, 0, 0);
            if (obj.transform.position.x <= 0)
            {
                arrows.Remove(obj);
                Destroy(obj);
            }
        }
        separation-=speed;
        if (separation <= 0)
        {
            separation = separationIni;
            instance = Instantiate(Resources.Load("Arrow", typeof(GameObject))) as GameObject;
            instance.transform.SetParent(this.transform);
            instance.transform.localScale = new Vector3(1, 1, 1);
            instance.transform.localPosition = new Vector3(this.GetComponent<RectTransform>().rect.width / 2 +
                instance.GetComponent<RectTransform>().rect.width, 0, 0);
            int rand = Random.Range(0, 4);
            instance.GetComponent<Image>().sprite = images[rand];
            arrows.Add(instance);
        }
    }
}
