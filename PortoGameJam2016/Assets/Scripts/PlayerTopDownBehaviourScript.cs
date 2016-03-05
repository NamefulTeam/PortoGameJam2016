using UnityEngine;
using System.Collections;

public class PlayerTopDownBehaviourScript : MonoBehaviour {

    //settings for game
    public float speed = 5.0F;
    
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
}
