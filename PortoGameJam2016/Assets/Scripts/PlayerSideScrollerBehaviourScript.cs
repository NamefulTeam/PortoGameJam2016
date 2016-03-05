using UnityEngine;
using System.Collections;

public class PlayerSideScrollerBehaviourScript : MonoBehaviour {
    //local variables
    bool isGrounded = true;

    //settings for game
    public float speed = 10.0F;
    public float jumpSpeed = 200.0f;
    
    void Start () {

    }
	
	void FixedUpdate () {

        if (GameManager.Instance.CurrentMode == Mode.SideScroller)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationY = Input.GetAxis("Vertical");

            GetComponent<Rigidbody2D>().AddForce(new Vector2(translationX, 0) * speed);

            if (translationY > 0 && isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed);
            }

        }
    }

    //consider when character is falling and touches the ground, it will enter collision.
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
