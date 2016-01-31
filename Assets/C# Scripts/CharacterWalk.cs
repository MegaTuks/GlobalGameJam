using UnityEngine;
using System.Collections;

public class CharacterWalk : MonoBehaviour
{
    public float speed = 1.0f;
    private int direccion;
    public Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        direccion = 1;
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
                direccion = -1;
                break;
            case "Down-Right":
                move = new Vector3(-1, 1, 0);
                transform.position += move * speed * 1.2f;
                direccion = 1;
                break;
            case "Up-Left":
                move = new Vector3(1, -1, 0);
                transform.position += move * speed * 1.2f;
                direccion = -1;
                break;
            case "Up-Right":
                move = new Vector3(-1, -1, 0);
                transform.position += move * speed * 1.2f;
                direccion = 1;
                break;
            default:
                break;
        }
    }
}
