using UnityEngine;
using System.Collections;

public class SwordBehaviourScript : MonoBehaviour {

    //settings for game
    public GameObject parentObject;

    private bool isAnimationOccurring = false;
    private SwordState state = SwordState.SwordRight;
    private float timeForSlerp = 0f;
    private Vector3 oldPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.Instance.CurrentMode == Mode.TopDown && GetComponentInParent<PlayerController>().isAttacking() && !isAnimationOccurring)
        {
            isAnimationOccurring = true;
            oldPosition = transform.eulerAngles;
        }

        if (isAnimationOccurring) {
            if (timeForSlerp <= 1.0f)
            {
                timeForSlerp += 10f * Time.deltaTime;

                if (state == SwordState.SwordLeft)
                {
                    Vector3 newRotation = new Vector3(transform.eulerAngles.x, 90 + 45, transform.eulerAngles.z);
                    transform.eulerAngles = Vector3.Lerp(oldPosition, newRotation, timeForSlerp);
                }
                else
                {
                    Vector3 newRotation = new Vector3(transform.eulerAngles.x, 90 - 45, transform.eulerAngles.z);
                    transform.eulerAngles = Vector3.Lerp(oldPosition, newRotation, timeForSlerp);
                }
            }
            else
            {
                timeForSlerp = 0f;
                state = state == SwordState.SwordLeft ? SwordState.SwordRight : SwordState.SwordLeft;
                isAnimationOccurring = false;
                GetComponentInParent<PlayerController>().stoppedAttacking();
                transform.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            parentObject.GetComponent<PlayerController>().OnEnemyKilled();
            if (collider.gameObject.name == "SideScroller" || collider.gameObject.name == "TopDown")
                Destroy(collider.transform.parent.gameObject, 0.1f);
            else
            {
                Destroy(collider.gameObject, 0.1f);
            }
        }
    }
}

public enum SwordState
{
    SwordLeft,
    SwordRight
}