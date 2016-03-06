using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectList : MonoBehaviour {

    public List<Twistable> TwistableObjects;

    private static ObjectList instance = null;
    public static ObjectList Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject("ObjectList");
                instance = obj.AddComponent<ObjectList>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

	// Use this for initialization
	void Awake () {
        TwistableObjects = new List<Twistable>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddTwistable(Twistable twistable)
    {
        TwistableObjects.Add(twistable);
    }

    public void RemoveTwistable(Twistable twistable)
    {
        TwistableObjects.Remove(twistable);
    }
}
