using UnityEngine;
using System.Collections;

public class DirectionArrow : MonoBehaviour, IGvrGazeResponder {

	public enum Direction {upArrow, downArrow, leftArrow, rightArrow};
	public Direction selectedDirection;
	public float rotationSpeed;

	private GameObject item;
	private Transform itemTransform;
	private bool isGazedAt;

	// Use this for initialization
	void Start () {
		item = GameObject.FindGameObjectWithTag ("item");
		itemTransform = item.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if (isGazedAt) {
			switch (selectedDirection) {
			case Direction.leftArrow:
				AddYaw (1.0f);
				break;
			case Direction.rightArrow:
				AddYaw (-1.0f);
				break;
			case Direction.upArrow:
				AddPitch (1.0f);
				break;
			case Direction.downArrow:
				AddPitch (-1.0f);
				break;
			default:
				break;
			}
		}
	}

	void AddYaw(float direction) {
		//rb.rotation = rb.rotation * Quaternion.Euler (0.0f, rotationSpeed * direction, 0.0f);
		Quaternion qParent_0 = Quaternion.LookRotation (Vector3.forward, Vector3.up);
		Quaternion qChild_0 = itemTransform.rotation;
		Quaternion qRelative_PC_0 = Quaternion.Inverse (qParent_0) * qChild_0;
		Quaternion qParent1 = qParent_0 * Quaternion.Euler (0.0f, rotationSpeed * direction, 0.0f);
		Quaternion qTrans = qParent1 * qRelative_PC_0;

		itemTransform.rotation = qTrans;

		//rb.rotation = qTrans;

	}

	void AddPitch(float direction) {
		//rb.rotation = rb.rotation * Quaternion.Euler (rotationSpeed * direction, 0.0f, 0.0f);

		Quaternion qParent_0 = Quaternion.LookRotation (Vector3.forward, Vector3.up);
		Quaternion qChild_0 = itemTransform.rotation;
		Quaternion qRelative_PC_0 = Quaternion.Inverse (qParent_0) * qChild_0;
		Quaternion qParent1 = qParent_0 * Quaternion.Euler (rotationSpeed * direction, 0.0f, 0.0f);
		Quaternion qTrans = qParent1 * qRelative_PC_0;

		itemTransform.rotation = qTrans;

		//rb.rotation = qTrans;
	}

	public void SetGazedAt(bool gazedAt) {
		isGazedAt = gazedAt;
	}

	#region IGvrGazeResponder implementation

	public void OnGazeEnter() {
		SetGazedAt (true);
	}

	public void OnGazeExit() {
		SetGazedAt (false);
	}

	public void OnGazeTrigger() {

	}

	#endregion
}
