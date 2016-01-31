using UnityEngine;
using System.Collections;

public class CharacterWalk : MonoBehaviour
{
    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        Vector3 move;
        switch (coll.gameObject.tag)
        {
            case "Down-Left":
                move = new Vector3(1, 1, 0);
                transform.position += move * speed * 1.2f;
                break;
            case "Down-Right":
                move = new Vector3(-1, 1, 0);
                transform.position += move * speed * 1.2f;
                break;
            case "Up-Left":
                move = new Vector3(1, -1, 0);
                transform.position += move * speed * 1.2f;
                break;
            case "Up-Right":
                move = new Vector3(-1, -1, 0);
                transform.position += move * speed * 1.2f;
                break;
            default:
                break;
        }
    }
}
