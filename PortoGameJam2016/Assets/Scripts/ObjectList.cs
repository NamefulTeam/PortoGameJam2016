using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectList : MonoBehaviour {

    public List<Twistable> TwistableObjects;

    private static ObjectList instance;
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
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
