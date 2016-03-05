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
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = new Vector3();
        switch (State)
        {
            case TwistState.SideScroll:
                position.x = SideScroller.transform.position.x;
                position.y = SideScroller.transform.position.y;
                break;
            case TwistState.TopDown:
                position.x = TopDowner.transform.position.x;
                position.z = TopDowner.transform.position.z;
                break;
        }
        transform.position = position;
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
                if(!IsGround)
                    TopDowner.gameObject.SetActive(true);
                break;
        }
    }
}
