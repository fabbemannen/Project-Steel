using UnityEngine;
using System.Collections;

public class SmoothFollow2 : MonoBehaviour {
	
	public Transform target;
	public float distanceUp;
	public float distanceBack;
	public float minimumHeight;
	public float rotationSpeed;

	private Vector3 positionVelocity;

	void FixedUpdate () {
		Vector3 newPosition = target.position + (target.forward * distanceBack);
		newPosition.y = Mathf.Max(newPosition.y + distanceUp, minimumHeight);

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, 0.18f);

		Vector3 focalPoint = target.position + (target.forward * 5);
		transform.LookAt(focalPoint);
		/*
		Vector3 targetDir = (focalPoint - transform.position).normalized;
		float step = rotationSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);

		transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Lerp(transform.rotation.z, target.rotation.z, 1.0f), transform.rotation.w), step);
		*/
	}
}
