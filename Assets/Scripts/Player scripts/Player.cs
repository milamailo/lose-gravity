using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float speed = 8f, maxVelocity = 4f;

    //[SerializeField]
    private Rigidbody2D mybody;
    private Animator animator;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMoveKeyboard ();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float xVelocity = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0) {
            if (xVelocity < maxVelocity) {
                forceX = speed;
            }

            Vector3 vector3 = transform.localScale;
            vector3.x = 1f;
            transform.localScale = vector3;

            animator.SetBool("isWalk", true);
        }
        else if (h < 0)
        {
            if (xVelocity < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 vector3 = transform.localScale;
            vector3.x = -1f;
            transform.localScale =  vector3;

            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
        mybody.AddForce (new Vector2(forceX, 0));
    }
}
