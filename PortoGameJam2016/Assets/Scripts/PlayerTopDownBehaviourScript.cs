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
                GetComponent<Rigidbody>().velocity = new Vector3(translationX, GetComponent<Rigidbody>().velocity.y, translationZ) * speed;
            }
            Debug.DrawRay(transform.position, Vector3.down, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                float dist = Vector3.Distance(hit.point, transform.position);
                if (dist > 0.5)
                {
                    GetComponent<Rigidbody>().drag = 0;
                }
                else
                {
                    GetComponent<Rigidbody>().drag = 10;
                }
            }
            else
            {
                GetComponent<Rigidbody>().drag = 0;
            }


        }
    }
}
