using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Sword : AbstractMonoBehaviour
	{

		protected override void OnTriggerEnter2D(Collider2D collider)
		{
			var rigidbody = collider.GetComponent<Rigidbody2D>();
			if (rigidbody == null)
				return;
			
			var enemy = rigidbody.gameObject.GetComponent<Enemy>();
			if (enemy == null)
				return;
			
			enemy.TakeDamage(1);
		}

		protected override void OnTriggerStay2D(Collider2D collider)
		{
			var rigidbody = collider.GetComponent<Rigidbody2D>();
			if (rigidbody == null)
				return;

			var enemy = rigidbody.gameObject.GetComponent<Enemy>();
			if (enemy == null)
				return;

			Vector2 collisionDirection = rigidbody.position - (Vector2)transform.position;
			enemy.Knockback(collisionDirection);
		}
	}
}
