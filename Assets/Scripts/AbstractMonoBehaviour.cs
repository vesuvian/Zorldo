using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// Simple abstraction to expose Unity3D event hooks.
	/// </summary>
	public abstract class AbstractMonoBehaviour : MonoBehaviour
	{
		/// <summary>
		/// Called once per frame.
		/// </summary>
		protected virtual void Update()
		{
		}

		/// <summary>
		/// Called when a 2D collision occurs between this GameObject and the given collider.
		/// </summary>
		/// <param name="collision"></param>
		protected virtual void OnCollisionEnter2D(Collision2D collision)
		{
		}
	}
}
