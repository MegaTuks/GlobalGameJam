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
    public GameObject pointZone;
    public GameObject winBanner;
    public GameObject defeatBanner;
    public PlayerTime playerTime;
    public bool lost;
    public bool won;
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
        instance.AddComponent<BoxCollider2D>();
        Rigidbody2D body = instance.AddComponent<Rigidbody2D>() as Rigidbody2D;
        body.isKinematic = true;
        arrows.Add(instance);
        separationIni = (int)(instance.GetComponent<RectTransform>().rect.width * 1.5);
        separation = separationIni;
        lost = false;
        won = false;
        //defeatBanner.SetActive(false);
        //winBanner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTime.playTime > 0 && !lost)
        {
            for (int i = arrows.Count - 1; i >= 0; i--)
            {
                GameObject obj = arrows[i];
                obj.transform.Translate(-speed, 0, 0);
                Rect rectObj, rectZone;
                rectObj = new Rect(obj.transform.position.x - obj.GetComponent<RectTransform>().rect.width,
                    obj.transform.position.y - obj.GetComponent<RectTransform>().rect.height,
                    obj.GetComponent<RectTransform>().rect.width, obj.GetComponent<RectTransform>().rect.height);
                rectZone = new Rect(pointZone.transform.position.x - pointZone.GetComponent<RectTransform>().rect.width,
                   pointZone.transform.position.y - pointZone.GetComponent<RectTransform>().rect.height,
                   pointZone.GetComponent<RectTransform>().rect.width, pointZone.GetComponent<RectTransform>().rect.height);
                bool hit = false;
                if (rectObj.Overlaps(rectZone))
                {
                    Debug.Log("Obj " + rectObj + rectObj.size.x * rectObj.size.y);
                    Debug.Log("Zone " + rectZone + rectZone.size.x * rectZone.size.y);
                    Rect inter = new Rect(rectObj.xMin, rectObj.yMin, Mathf.Abs(rectObj.xMin - rectZone.xMax),
                        Mathf.Abs(rectObj.yMin - rectZone.yMax));
                    Debug.Log("inter " + inter + inter.size.x * inter.size.y);
                    int image = 0;
                    for (int j = 0; j < images.Length; j++)
                    {
                        if (obj.GetComponent<Image>().sprite == images[j])
                        {
                            image = j;
                        }
                    }
                    switch (image)
                    {
                        case 0:
                            if (Input.GetKeyDown("up"))
                            {
                                Debug.Log("Acertado");
                                hit = true;
                                Debug.Log("Obj " + rectObj + rectObj.size.x * rectObj.size.y);
                                Debug.Log("Zone " + rectZone + rectZone.size.x * rectZone.size.y);
                                inter = new Rect(rectObj.xMin, rectObj.yMin, Mathf.Abs(rectObj.xMin - rectZone.xMax),
                                    Mathf.Abs(rectObj.yMin - rectZone.yMax));
                                Debug.Log("inter " + inter + inter.size.x * inter.size.y);
                            }
                            break;
                        case 1:
                            if (Input.GetKeyDown("right"))
                            {
                                Debug.Log("Acertado");
                                hit = true;
                                Debug.Log("Obj " + rectObj + rectObj.size.x * rectObj.size.y);
                                Debug.Log("Zone " + rectZone + rectZone.size.x * rectZone.size.y);
                                inter = new Rect(rectObj.xMin, rectObj.yMin, Mathf.Abs(rectObj.xMin - rectZone.xMax),
                                    Mathf.Abs(rectObj.yMin - rectZone.yMax));
                                Debug.Log("inter " + inter + inter.size.x * inter.size.y);
                            }
                            break;
                        case 2:
                            if (Input.GetKeyDown("left"))
                            {
                                Debug.Log("Acertado");
                                hit = true;
                                Debug.Log("Obj " + rectObj + rectObj.size.x * rectObj.size.y);
                                Debug.Log("Zone " + rectZone + rectZone.size.x * rectZone.size.y);
                                inter = new Rect(rectObj.xMin, rectObj.yMin, Mathf.Abs(rectObj.xMin - rectZone.xMax),
                                    Mathf.Abs(rectObj.yMin - rectZone.yMax));
                                Debug.Log("inter " + inter + inter.size.x * inter.size.y);
                            }
                            break;
                        case 3:
                            if (Input.GetKeyDown("down"))
                            {
                                Debug.Log("Acertado");
                                hit = true;
                                Debug.Log("Obj " + rectObj + rectObj.size.x * rectObj.size.y);
                                Debug.Log("Zone " + rectZone + rectZone.size.x * rectZone.size.y);
                                inter = new Rect(rectObj.xMin, rectObj.yMin, Mathf.Abs(rectObj.xMin - rectZone.xMax),
                                    Mathf.Abs(rectObj.yMin - rectZone.yMax));
                                Debug.Log("inter " + inter + inter.size.x * inter.size.y);
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (obj.transform.position.x <= 0 || hit)
                {
                    arrows.Remove(obj);
                    Destroy(obj);
                    lost = !hit;
                }
                if (lost)
                {
                    defeatBanner.SetActive(true);
                }
            }
            separation -= speed;
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
        else if(playerTime.playTime <= 0 && !lost && !won)
        {
            won = true;
            winBanner.SetActive(true);
        }
    }
}
