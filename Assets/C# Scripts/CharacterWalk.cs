using UnityEngine;
using System.Collections;

public class CharacterWalk : MonoBehaviour
{
    public float speed = 1.0f;
    private int direccion;
    public Sprite[] sprites;

	//Animation
	private Animator anim;
	AnimatorStateInfo currentState;

	float playbackTime;
	float xScale;

    // Use this for initialization
    void Start()
    {
        direccion = 1;
		anim = GetComponent<Animator> ();
		xScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
		//get animations
		currentState = anim.GetCurrentAnimatorStateInfo (0);

		playbackTime = currentState.normalizedTime % 1;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);


		anim.SetFloat ("Speed", Mathf.Abs(move.x) + Mathf.Abs(move.y));

		if (move.x > 0)
			transform.localScale = new Vector2 (xScale, transform.localScale.y);
		if (move.x < 0)
			transform.localScale = new Vector2 (-Mathf.Abs(xScale), transform.localScale.y);



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
