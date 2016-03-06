using UnityEngine;
using System.Collections;
using System;

public class Twistable : MonoBehaviour {

    public Transform SideScroller;
    public Transform TopDowner;

    public bool IsGround;
    public bool RestoreOriginalY;

    public Mode State { get; private set; }
    
    float initialY;

    // Use this for initialization
    void Awake () {
        ObjectList.Instance.AddTwistable(this);

        initialY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.localPosition;
        switch (State)
        {
            case Mode.SideScroller:
                if (SideScroller != null)
                {
                    position.x += SideScroller.transform.localPosition.x;
                    position.y += SideScroller.transform.localPosition.y;
                    transform.localPosition = position;
                    SideScroller.transform.localPosition = new Vector3(0, 0, -transform.localPosition.z);
                }
                break;
            case Mode.TopDown:
                if (TopDowner != null)
                {
                    position.x += TopDowner.transform.localPosition.x;
                    position.y += TopDowner.transform.localPosition.y;
                    position.z += TopDowner.transform.localPosition.z;
                    transform.localPosition = position;
                    TopDowner.transform.localPosition = new Vector3(0, 0, 0);
                }
                break;
        }

        
    }

    public void SwitchState(Mode state)
    {
        State = state;
        switch (state)
        {
            case Mode.SideScroller:
                TopDowner.gameObject.SetActive(false);
                SideScroller.gameObject.SetActive(true);
                
                var rb2d = SideScroller.GetComponent<Rigidbody2D>();
                if (IsGround)
                {
                    rb2d.gravityScale = 0.0f;
                    rb2d.isKinematic = true;
                }

                if (!IsGround)
                {
                    float newY = float.MinValue;
                    foreach (var obj in ObjectList.Instance.TwistableObjects)
                    {
                        if (!obj.IsGround)
                        {
                            continue;
                        }

                        var objPosition = obj.transform.position;
                        var objSize = obj.transform.localScale;

                        if (objPosition.x + objSize.x / 2 > transform.position.x - transform.localScale.x / 2 &&
                            objPosition.x - objSize.x / 2 < transform.position.x + transform.localScale.x / 2)
                        {
                            newY = Mathf.Max(newY, objPosition.y + objSize.y / 2 - transform.localScale.y / 2 + 0.1f);
                        }
                    }

                    Debug.Log(gameObject.transform.root.gameObject.name + "@" + transform.position + ": " + newY);
                    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
                }

                if (RestoreOriginalY)
                {
                    transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
                }

                break;
            case Mode.TopDown:
                SideScroller.gameObject.SetActive(false);
                TopDowner.gameObject.SetActive(true);
                if (IsGround)
                {
                    TopDowner.GetComponent<Rigidbody>().useGravity = false;
                    TopDowner.GetComponent<Rigidbody>().isKinematic = true;
                }
                break;
        }
    }

    void OnDestroy()
    {
        ObjectList.Instance.RemoveTwistable(this);
    }

}
