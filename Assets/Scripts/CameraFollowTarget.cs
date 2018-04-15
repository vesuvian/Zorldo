using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class CameraFollowTarget : AbstractMonoBehaviour
	{

		/// <summary>
		/// GameObject that the camera should follow
		/// </summary>
		[SerializeField]
		private GameObject _target;

		// Update is called once per frame
		protected override void Update()
		{
			var cameraTransform = GetComponent<Transform>();
			Vector2 difference = _target.GetComponent<Transform>().position - cameraTransform.position;

			cameraTransform.Translate(difference);
		}
	}
}
