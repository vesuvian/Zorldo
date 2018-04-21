using UnityEngine;

namespace Assets.Scripts
{
	public abstract class AbstractCharacter : AbstractMonoBehaviour
	{
		[SerializeField] protected int m_Speed;

		[SerializeField]
		protected int m_MaxHealth;

		[SerializeField]
		protected int m_HitVelocity;

		public int Health { get; protected set; }

		public int MaxHealth
		{
			get { return m_MaxHealth; }
			protected set { m_MaxHealth = value; }
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Health = m_MaxHealth;
		}

		/// <summary>
		/// Called once per frame.
		/// </summary>
		protected override void Update()
		{
			if (Health <= 0)
				Die();

			Vector2 directionVector = GetDirectionVector();
			bool right = directionVector.x >= 0;
			bool up = directionVector.y >= 0;
			var currentScale = transform.localScale;
			transform.localScale = Mathf.Abs(currentScale.x) * (right ? Vector2.right : Vector2.left) + Mathf.Abs(currentScale.y) * Vector2.up;
			GetComponent<Rigidbody2D>().velocity += directionVector * m_Speed * Time.deltaTime;
		}

		/// <summary>
		/// Gets the direction to move this frame.
		/// </summary>
		/// <returns></returns>
		protected abstract Vector2 GetDirectionVector();

		protected abstract void Die();

		public void Knockback(Vector2 knockbackDirection)
		{
			knockbackDirection = knockbackDirection.normalized;
			GetComponent<Rigidbody2D>().velocity = knockbackDirection * m_HitVelocity;
		}

		public void TakeDamage(int damage)
		{
			Health -= damage;
		}
	}
}
