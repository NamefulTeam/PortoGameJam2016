using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {
    //local variables
    bool isGrounded = true;

    //settings for game
    public float speed = 10.0F;
    public float jumpSpeed = 200.0f;

    public bool isInSideScrollMode = true;
    
    void Start () {

    }
	
	void FixedUpdate () {

        if (isInSideScrollMode)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationY = Input.GetAxis("Vertical");

            GetComponent<Rigidbody2D>().AddForce(new Vector2(translationX, 0) * speed);

            if (translationY > 0 && isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed);
            }

        } else
        {
         /*   float translationZ = Input.GetAxis("Horizontal") * speed;
            float inputX = Input.GetAxis("Vertical");
            float translationX = 0;
            translationZ *= Time.deltaTime;
            

            transform.Translate(translationX, 0, translationZ);*/
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
