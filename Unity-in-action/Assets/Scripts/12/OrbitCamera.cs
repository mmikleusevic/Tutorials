﻿using UnityEngine;

namespace _12
{
	public class OrbitCamera : MonoBehaviour {
		[SerializeField] Transform target;

		public float rotSpeed = 1.5f;

		private float rotY;
		private Vector3 offset;
		
		void Start() {
			rotY = transform.eulerAngles.y;
			offset = target.position - transform.position;
		}

		void LateUpdate() {
			rotY -= Input.GetAxis("Horizontal") * rotSpeed;
			Quaternion rotation = Quaternion.Euler(0, rotY, 0);
			transform.position = target.position - (rotation * offset);
			transform.LookAt(target);
		}
	}
}