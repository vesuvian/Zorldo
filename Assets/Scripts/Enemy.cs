﻿using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// The most beastly of enemies
	/// </summary>
	public class Enemy : AbstractMonoBehaviour
	{

		[SerializeField]
		private int m_Speed;

		[SerializeField]
		private GameObject _target;

		/// <summary>
		/// Called once per frame.
		/// </summary>
		protected override void Update()
		{
			Vector2 directionVector = _target.transform.position - this.transform.position;
			directionVector = directionVector.normalized;

			Vector2 moveVector = directionVector * m_Speed * Time.deltaTime;

			transform.Translate(moveVector);
		}
	}
}