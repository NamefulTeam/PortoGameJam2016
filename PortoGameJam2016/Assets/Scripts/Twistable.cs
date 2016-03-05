using UnityEngine;
using System.Collections;

public class Twistable : MonoBehaviour {

    public Transform SideScroller;
    public Transform TopDowner;

    public bool IsGround;

    public enum TwistState
    {
        SideScroll,
        TopDown
    }

    public TwistState State { get; private set; }

    // Use this for initialization
    void Awake () {
        ObjectList.Instance.AddTwistable(this);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.localPosition;
        switch (State)
        {
            case TwistState.SideScroll:
                position.x += SideScroller.transform.localPosition.x;
                position.y += SideScroller.transform.localPosition.y;
                transform.localPosition = position;
                SideScroller.transform.localPosition = new Vector3(0, 0, -transform.localPosition.z);
                break;
            case TwistState.TopDown:
                position.x += TopDowner.transform.localPosition.x;
                position.z += TopDowner.transform.localPosition.z;
                transform.localPosition = position;
                TopDowner.transform.localPosition = new Vector3(0, 0, 0);
                break;
        }

        
    }

    public void SwitchState(TwistState state)
    {
        State = state;
        switch (state)
        {
            case TwistState.SideScroll:
                TopDowner.gameObject.SetActive(false);
                SideScroller.gameObject.SetActive(true);
                break;
            case TwistState.TopDown:
                SideScroller.gameObject.SetActive(false);
                if (!IsGround)
                    TopDowner.gameObject.SetActive(true);
                break;
        }
    }

}
