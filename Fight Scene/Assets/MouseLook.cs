using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseLook : MonoBehaviour
{
	public float XSensitivity;
	public float YSensitivity;
	public bool clampVerticalRotation = true;
	public float MinimumX;
	public float Maximumx;
	public bool Smooth;
	public float SmoothTime;
	public bool lockCursor = true;

	private Quaternion CharacterTargetRotation;
	private Quaternion CameraTargetRotation;

	public void Init(Transform character, Transform camera)
	{
		CharacterTargetRotation = character.localRotation;
		CameraTargetRotation = camera.localRotation;
	}

	public void LookRotation(Transform character, Transform camera)
	{
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		CharacterTargetRotation *= Quaternion.Euler(0f, yRot, 0f);
		CameraTargetRotation *= Quaternion.Euler(-xRot, 0f, 0f);

		if (clampVerticalRotation)
		{
			CameraTargetRotation = ClampRotationAroundXAxis(CameraTargetRotation);
		}

		if (Smooth)
		{
			character.localRotation = Quaternion.Slerp(character.localRotation, CharacterTargetRotation, SmoothTime * Time.deltaTime);
			camera.localRotation = Quaternion.Slerp(camera.localRotation, CameraTargetRotation, SmoothTime * Time.deltaTime);
		}
		else
		{
			character.localRotation = CharacterTargetRotation;
			camera.localRotation = CameraTargetRotation;
		}

	}

	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w /= 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
		angleX = Mathf.Clamp(angleX, MinimumX, Maximumx);
		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}

}
