using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// The most beastly of enemies
	/// </summary>
	public class Enemy : AbstractMonoBehaviour
	{

		[SerializeField]
		private int m_Speed;

		/// <summary>
		/// Called once per frame.
		/// </summary>
		protected override void Update()
		{
			Vector2 directionVector = new Vector2(Random.value * 2 - 1, Random.value * 2 - 1);
			directionVector = directionVector.normalized;

			Vector2 moveVector = directionVector * m_Speed * Time.deltaTime;

			transform.Translate(moveVector);
		}
	}
}
