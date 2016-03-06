using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    
    public Transform Target;
    public float TargetDist;
    public bool WillChase;
    public float WalkingSpeed;

    public Vector3 TopPatrolStart;
    public Vector3 TopPatrolEnd;

    public Vector2 SidePatrolStart;
    public Vector2 SidePatrolEnd;

    private bool startPatrol = false;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Twistable>().State == Mode.TopDown)
        {
            if (WillChase && Vector3.Distance(transform.position, Target.transform.position) < TargetDist)
            {
                Vector3 direction = Target.transform.position - transform.position;
                direction.Normalize();
                direction *= (WalkingSpeed * Time.deltaTime);
                transform.position += direction;
            }
            else
            {
                Vector3 targetPosition = transform.position;
                if (startPatrol)
                {
                    targetPosition = TopPatrolEnd;
                }
                else
                {
                    targetPosition = TopPatrolStart;
                }
                Vector3 direction = targetPosition - transform.position;
                if (direction.magnitude <= WalkingSpeed * Time.deltaTime)
                    startPatrol = !startPatrol;
                direction.Normalize();
                direction *= (WalkingSpeed * Time.deltaTime);
                transform.position += direction;
            }
        }
        else if (GetComponent<Twistable>().State == Mode.SideScroller)
        {
            Vector2 selfPos = transform.position;
            Vector2 targetPos = Target.transform.position;
            if (WillChase && Vector3.Distance(transform.position, Target.transform.position) < TargetDist)
            {
                Vector2 direction = targetPos - selfPos;
                direction.Normalize();
                direction *= (WalkingSpeed * Time.deltaTime);
                transform.position += new Vector3(direction.x, direction.y, 0);
            }
            else
            {
                Vector2 targetPosition = transform.position;
                Vector2 selfPosition = transform.position;
                if (startPatrol)
                {
                    targetPosition = SidePatrolEnd;
                }
                else
                {
                    targetPosition = SidePatrolStart;
                }
                Vector2 direction = targetPosition - selfPosition;
                if (direction.magnitude <= WalkingSpeed*Time.deltaTime)
                    startPatrol = !startPatrol;
                
                direction.Normalize();
                direction *= (WalkingSpeed * Time.deltaTime);
                transform.position += new Vector3(direction.x, direction.y, 0);
            }
        }
	
	}

    public void OnPlayerAttack()
    {
        Target.gameObject.GetComponent<PlayerController>().attacked();
    }
}
