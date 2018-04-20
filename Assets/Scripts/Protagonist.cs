﻿using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// The manliest of men.
	/// </summary>
	public sealed class Protagonist : AbstractCharacter
	{
		[SerializeField]
		private int m_HitVelocity;

		[SerializeField]
		private AudioClip m_Augh;

		/// <summary>
		/// Gets the direction to move this frame.
		/// </summary>
		/// <returns></returns>
		protected override Vector2 GetDirectionVector()
		{
			Vector2 inputVector = Vector2.zero;

			if (Input.GetKey(KeyCode.W))
				inputVector += Vector2.up;
			if (Input.GetKey(KeyCode.S))
				inputVector += Vector2.down;
			if (Input.GetKey(KeyCode.A))
				inputVector += Vector2.left;
			if (Input.GetKey(KeyCode.D))
				inputVector += Vector2.right;

			return inputVector.normalized;
		}

		protected override void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.rigidbody != null && collision.rigidbody.gameObject.name == "Enemy")
			{
				AudioSource source = GetComponent<AudioSource>();

				Health -= 1;
				Mathf.Clamp(Health, 0, m_MaxHealth);
				Debug.Log(Health);
				if (source.isPlaying)
					source.Stop();
				
				source.pitch = Health > 0 ? 1.5f : 0.5f;
				source.PlayOneShot(m_Augh);
			}
		}

		protected override void OnCollisionStay2D(Collision2D collision)
		{
			if (collision.rigidbody != null && collision.rigidbody.gameObject.name == "Enemy")
			{
				Vector2 collisionDirection = collision.otherRigidbody.position - collision.rigidbody.position;
				collisionDirection = collisionDirection.normalized;
				GetComponent<Rigidbody2D>().velocity = collisionDirection * m_HitVelocity;
			}
		}
	}
}
