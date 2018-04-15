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
			GetComponent<Rigidbody2D>().velocity = GetDirectionVector() * m_Speed * Time.deltaTime;
		}

		/// <summary>
		/// Gets the direction to move this frame.
		/// </summary>
		/// <returns></returns>
		protected abstract Vector2 GetDirectionVector();
	}
}
