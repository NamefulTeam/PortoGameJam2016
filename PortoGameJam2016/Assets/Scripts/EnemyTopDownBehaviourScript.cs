using UnityEngine;
using System.Collections;

public class EnemyTopDownBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (GetComponentInParent<EnemyAI>() == null || GetComponentInParent<EnemyAI>().Target.gameObject.GetComponent<PlayerController>().isAttacking())
        {
            return;
        }
        if (collision.gameObject.tag == GetComponentInParent<EnemyAI>().Target.gameObject.tag)
        {
            GetComponentInParent<EnemyAI>().OnPlayerAttack();
        }
    }
}
