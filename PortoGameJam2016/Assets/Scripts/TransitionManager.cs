using UnityEngine;
using System.Collections;

public class TransitionManager : MonoBehaviour {

    public ObjectList ObjectList;

	// Use this for initialization
	void Awake () {
        ObjectList = ObjectList.Instance;
    }

    void Start()
    {
        Twist(Twistable.TwistState.TopDown);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Twist(Twistable.TwistState state)
    {
        foreach(var obj in ObjectList.TwistableObjects)
        {
            obj.SwitchState(state);
        }
    }
}
