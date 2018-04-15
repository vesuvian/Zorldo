using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// The most beastly of enemies
	/// </summary>
	public class Enemy : AbstractCharacter
	{
		[SerializeField]
		private GameObject _target;

		[SerializeField]
		private int m_HitVelocity;

		public GameObject Target { get { return _target; } set { _target = value; } }

		/// <summary>
		/// Gets the direction to move this frame.
		/// </summary>
		/// <returns></returns>
		protected override Vector2 GetDirectionVector()
		{
			if (_target == null)
				return Random.insideUnitCircle.normalized;

			Vector2 directionVector = _target.transform.position - transform.position;
			return directionVector.normalized;
		}

		protected override void OnCollisionStay2D(Collision2D collision)
		{
			if (collision.otherRigidbody != null && collision.rigidbody != null)
			{
				Vector2 collisionDirection = collision.otherRigidbody.position - collision.rigidbody.position;
				collisionDirection = collisionDirection.normalized;
				GetComponent<Rigidbody2D>().velocity = collisionDirection * m_HitVelocity;
			}
		}
	}
}
