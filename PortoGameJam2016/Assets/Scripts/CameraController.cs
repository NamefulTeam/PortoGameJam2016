using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int CameraDistance = 10;
    public float TransitionDuration = 1;

    public void SwitchToTopDown()
    {
        transform.position = new Vector3(0, CameraDistance, 0);
        transform.localRotation = Quaternion.Euler(90, 0, 0);
    }

    public void SwitchToSideScroller()
    {
        transform.position = new Vector3(0, 0, -CameraDistance);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void RotateToSideScroller()
    {
        GameManager.Instance.CurrentMode = Mode.TransitioningToSideScroller;

        var currentAngle = transform.localEulerAngles.x;
        if (currentAngle > 180)
        {
            currentAngle = 360 - currentAngle;
        }
        StartCoroutine(DoRotation(currentAngle, 0, Mode.SideScroller));
    }

    public void RotateToTopDown()
    {
        GameManager.Instance.CurrentMode = Mode.TransitioningToTopDown;

        StartCoroutine(DoRotation(transform.localEulerAngles.x, 90, Mode.TopDown));
    }

    IEnumerator DoRotation(float from, float to, Mode targetMode)
    {
        var diffAngle = to - from;
        var totalTime = 0f;

        for (;;)
        {
            var currentAngle = transform.localEulerAngles.x;
            if (currentAngle > 180)
            {
                currentAngle = 360 - currentAngle;
            }

            totalTime += Time.deltaTime;

            if (totalTime >= TransitionDuration)
            {
                transform.RotateAround(Vector3.zero, Vector3.right, to - currentAngle);

                GameManager.Instance.CurrentMode = targetMode;
                yield break;
            }
            else
            {
                transform.RotateAround(Vector3.zero, Vector3.right, diffAngle * Time.deltaTime / TransitionDuration);
            }

            yield return null;
        }
    }
}
