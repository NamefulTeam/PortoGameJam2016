using UnityEngine;
using System.Collections;

public class Twistable : MonoBehaviour {

    public Transform SideScroller;
    public Transform TopDowner;

    public bool IsGround;

    public Mode State { get; private set; }

    // Use this for initialization
    void Awake () {
        ObjectList.Instance.AddTwistable(this);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.localPosition;
        switch (State)
        {
            case Mode.SideScroller:
                position.x += SideScroller.transform.localPosition.x;
                position.y += SideScroller.transform.localPosition.y;
                transform.localPosition = position;
                SideScroller.transform.localPosition = new Vector3(0, 0, -transform.localPosition.z);
                break;
            case Mode.TopDown:
                position.x += TopDowner.transform.localPosition.x;
                position.y += TopDowner.transform.localPosition.y;
                position.z += TopDowner.transform.localPosition.z;
                transform.localPosition = position;
                TopDowner.transform.localPosition = new Vector3(0, 0, 0);
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
                if (IsGround)
                {
                    SideScroller.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                    SideScroller.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                break;
            case Mode.TopDown:
                SideScroller.gameObject.SetActive(false);
                TopDowner.gameObject.SetActive(true);
                break;
        }
    }

}
