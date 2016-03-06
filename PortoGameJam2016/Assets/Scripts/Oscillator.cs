using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour {

    public float OscillationAmplitude = 4f;
    public float OscillationFrequency = 1;
	
	void Update () {
        transform.localPosition = new Vector3(0, OscillationAmplitude * Mathf.Sin(Time.timeSinceLevelLoad * 2 * Mathf.PI * OscillationFrequency), 0);
	}
}
