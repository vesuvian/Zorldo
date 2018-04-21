using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// Simple abstraction to expose Unity3D event hooks.
	/// </summary>
	public abstract class AbstractMonoBehaviour : MonoBehaviour
	{
		/// <summary>
		/// Called when the MonoBehaviour becomes enabled.
		/// </summary>
		protected virtual void OnEnable()
		{
		}

		/// <summary>
		/// Called when the MonoBehaviour becomes disabled.
		/// </summary>
		protected virtual void OnDisable()
		{
		}

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

		/// <summary>
		/// Called when this GameObject is touching the given collider.
		/// </summary>
		/// <param name="collision"></param>
		protected virtual void OnCollisionStay2D(Collision2D collision)
		{
		}

		protected virtual void OnTriggerEnter2D(Collider2D collider)
		{
		}
		protected virtual void OnTriggerStay2D(Collider2D collider)
		{
		}
	}
}
