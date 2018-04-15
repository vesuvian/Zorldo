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
			Vector2 playerPosition = _target.GetComponent<Transform>().position;

			var x = Mathf.Clamp(playerPosition.x / 8.0f, -1, 1);
			var y = Mathf.Clamp(playerPosition.y / 4.5f, -1, 1);

			transform.position = new Vector3(x, y, -10);
		}
	}
}
