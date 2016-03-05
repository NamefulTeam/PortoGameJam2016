using UnityEngine;
using System.Collections;

public class TransitionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Twist(GameManager.Instance.CurrentMode);
    }

	// Update is called once per frame
	void Update () {
    }

    public void Twist(Mode mode)
    {
        foreach(var obj in ObjectList.Instance.TwistableObjects)
        {
            obj.SwitchState(mode);
        }
    }
}
