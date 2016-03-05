using UnityEngine;
using System.Collections;

public class PlayerTopDownBehaviourScript : MonoBehaviour {

    //settings for game
    public float speed = 20.0F;
    public float zMovement = 100.0f;

    TopDownZPosition currentZPos = TopDownZPosition.Middle;
    int lastTime = 10;
    const int updateCounter = 50;
    
    void Start () {
        
    }
	
	void FixedUpdate () {

        if (GameManager.Instance.CurrentMode == Mode.TopDown)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationZ = Input.GetAxis("Vertical");

            if(GetComponent<Rigidbody>().velocity.magnitude < 15)
                GetComponent<Rigidbody>().AddForce(new Vector3(translationX, 0, translationZ) * speed);
            
        }
    }
}

public enum TopDownZPosition
{
    Top,
    Middle,
    Down
}
