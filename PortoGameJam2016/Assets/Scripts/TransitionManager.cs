using UnityEngine;
using System.Collections;

public class TransitionManager : MonoBehaviour {

    public ObjectList ObjectList;

	// Use this for initialization
	void Start () {
        ObjectList = ObjectList.Instance;
        Twist(GameManager.Instance.CurrentMode);
    }

	// Update is called once per frame
	void Update () {
    }

    public void Twist(Mode mode)
    {
        foreach(var obj in ObjectList.TwistableObjects)
        {
            obj.SwitchState(mode);
        }
    }
}
