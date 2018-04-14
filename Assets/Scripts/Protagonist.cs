using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// The manliest of men.
	/// </summary>
	public sealed class Protagonist : AbstractMonoBehaviour
	{
		[SerializeField]
		private int m_Speed;

		/// <summary>
		/// Called once per frame.
		/// </summary>
		protected override void Update()
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

			inputVector = inputVector.normalized;

			Vector2 moveVector = inputVector * m_Speed * Time.deltaTime;

			transform.Translate(moveVector);
		}
	}
}
