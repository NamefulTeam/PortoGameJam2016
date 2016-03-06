using UnityEngine;
using System.Collections;

public class PlayerSideScrollerBehaviourScript : MonoBehaviour {
    //local variables
    bool isGrounded = true;

    //settings for game
    public float speed = 10.0F;
    public float speedAir = 10.0F;
    public float jumpSpeed = 10.0f;
    public float maxSpeedGround = 10.0f;
    public float maxSpeedAir = 10.0f;
    public float horizontalDrag = 15f;
    public GameObject parentObject;

    private float maxSpeed = 0;

    private float jumpCooldown = 0.5f;

    void Start () {

    }
	
	void FixedUpdate () {

        jumpCooldown = Mathf.Max(jumpCooldown - Time.fixedDeltaTime, 0);

        if (GameManager.Instance.CurrentMode == Mode.SideScroller)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 0.501f, Vector2.down);
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if (hit.rigidbody == null)
            {
                isGrounded = false;
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.down * 0.501f, Vector2.down * 50, Color.red);
                if (distance <= 0.55)
                {
                    isGrounded = true;
                }
                else
                {
                    isGrounded = false;
                }
            }

            float translationX = Input.GetAxisRaw("Horizontal");
            float translationY = Input.GetAxisRaw("Vertical");

            var currentVel = GetComponent<Rigidbody2D>().velocity;

            var vel = new Vector2(translationX, 0).normalized;
            Vector2 jumpVel = Vector2.zero;
            if (translationY > 0 && isGrounded && jumpCooldown <= float.Epsilon)
            {
                jumpVel = jumpSpeed * Vector2.up;
                isGrounded = false;
                jumpCooldown = 0.25f;
            }

            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().drag = horizontalDrag;
                maxSpeed = maxSpeedGround;
                vel *= speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().drag = 0.5f;
                maxSpeed = maxSpeedAir;
                vel *= speedAir;
            }
            currentVel += (jumpVel + vel);
            currentVel.x = Mathf.Clamp(currentVel.x, -maxSpeed, maxSpeed);

            GetComponent<Rigidbody2D>().velocity = currentVel;
        }
    }

    //consider when character is falling and touches the ground, it will enter collision.
    void OnCollisionEnter2D (Collision2D collision)
    {
        /*
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        */
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            //isGrounded = false;
        } else if (collision.gameObject.tag == "Enemy")
        {
            parentObject.GetComponent<PlayerController>().OnCollisionEnterChild();
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
