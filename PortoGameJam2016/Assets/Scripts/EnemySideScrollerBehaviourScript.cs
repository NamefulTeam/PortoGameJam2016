using UnityEngine;
using System.Collections;

public class EnemySideScrollerBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponentInParent<EnemyAI>() == null || collision.contacts[0].normal == Vector2.down)
        {
            return;
        }
        if (collision.gameObject.tag == GetComponentInParent<EnemyAI>().Target.gameObject.tag)
        {
            GetComponentInParent<EnemyAI>().OnPlayerAttack();
        }
    }
}
