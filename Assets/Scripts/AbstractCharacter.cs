using UnityEngine;

namespace Assets.Scripts
{
	public abstract class AbstractCharacter : AbstractMonoBehaviour
	{
		[SerializeField] private int m_Speed;

		/// <summary>
		/// Called once per frame.
		/// </summary>
		protected override void Update()
		{
			Vector2 directionVector = GetDirectionVector();
			bool right = directionVector.x >= 0;

			transform.localScale = new Vector2(0, 1) + (right ? Vector2.right : Vector2.left);
			GetComponent<Rigidbody2D>().velocity += directionVector * m_Speed * Time.deltaTime;
		}

		/// <summary>
		/// Gets the direction to move this frame.
		/// </summary>
		/// <returns></returns>
		protected abstract Vector2 GetDirectionVector();
	}
}
