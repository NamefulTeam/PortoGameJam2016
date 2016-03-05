using UnityEngine;
using System.Collections;

public class PlayerTopDownBehaviourScript : MonoBehaviour {

    //settings for game
    public float speed = 5.0F;
    public GameObject parentObject;
    
    void Start () {
        
    }
	
	void FixedUpdate () {

        if (GameManager.Instance.CurrentMode == Mode.TopDown)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationZ = Input.GetAxis("Vertical");

            if (GetComponent<Rigidbody>().velocity.magnitude < 15) { 
                GetComponent<Rigidbody>().velocity = new Vector3(translationX, 0, translationZ) * speed;
        }
            
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           /* parentObject.GetComponent<PlayerController>().OnCollisionEnterChild();
            Destroy(collision.gameObject, 0.1f);*/
        }
    }
    
    /*void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            
        }
    }*/
}
