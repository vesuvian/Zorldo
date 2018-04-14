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
	}
}
