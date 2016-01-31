using UnityEngine;
using System.Collections;

public class CharacterWalk : MonoBehaviour
{
    public float speed = 1.0f;

	//Animation
	private Animator anim;
	AnimatorStateInfo currentState;

	float playbackTime;
	float xScale;

    // Use this for initialization
    void Start()
    {
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

        transform.position += move * speed * Time.deltaTime;
    }
}
