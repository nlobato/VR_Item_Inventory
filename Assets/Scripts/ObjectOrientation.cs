using UnityEngine;
using System.Collections;

public class ObjectOrientation : MonoBehaviour, IGvrGazeResponder {

	private bool isGazedAt;
	private GameObject controlPad;

	// Use this for initialization
	void Start () {
		controlPad = GameObject.FindGameObjectWithTag ("ControlPad");
		controlPad.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGazedAt(bool gazedAt) {
		isGazedAt = gazedAt;
	}

	public void SetControlPad(){
		controlPad.SetActive (!controlPad.activeSelf);
	}

	#region IGvrGazeResponder implementation

	public void OnGazeEnter() {
		Debug.Log ("OnGazeEnter");
		SetGazedAt (true);
	}

	public void OnGazeExit() {
		Debug.Log ("OnGazeExit");
		SetGazedAt (false);
	}

	public void OnGazeTrigger() {

	}

	#endregion
}
