using UnityEngine;
using System.Collections;

public class PlayerTopDownBehaviourScript : MonoBehaviour {

    //settings for game
    public float speed = 5.0F;
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

            GetComponent<Rigidbody>().AddForce(new Vector3(translationX, 0, 0) * speed);

            if (lastTime > updateCounter)
            {
                switch (currentZPos)
                {
                    case TopDownZPosition.Top:
                        if (translationZ < -0.5f)
                        {
                            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * zMovement);
                            currentZPos = TopDownZPosition.Middle;
                            lastTime = 0;
                        }
                        break;
                    case TopDownZPosition.Middle:
                        if (translationZ < -0.5f)
                        {
                            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * zMovement);
                            currentZPos = TopDownZPosition.Down;
                            lastTime = 0;
                        }
                        else if (translationZ > 0.5f)
                        {
                            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * zMovement);
                            currentZPos = TopDownZPosition.Top;
                            lastTime = 0;
                        }
                        break;
                    case TopDownZPosition.Down:
                        if (translationZ > 0.5f)
                        {
                            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * zMovement);
                            currentZPos = TopDownZPosition.Middle;
                            lastTime = 0;
                        }
                        break;
                }
            } else
            {
                lastTime++;
            }
        }
    }
}

public enum TopDownZPosition
{
    Top,
    Middle,
    Down
}
