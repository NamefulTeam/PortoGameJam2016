using UnityEngine;
using System.Collections;

public class EnemySideScrollerBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollision2DEnter(Collision2D collision)
    {
        if (GetComponentInParent<EnemyAI>() == null)
        {
            return;
        }
        if (collision.gameObject.tag == GetComponentInParent<EnemyAI>().Target.gameObject.tag)
        {
            GetComponentInParent<EnemyAI>().OnPlayerAttack();
        }
    }
}
