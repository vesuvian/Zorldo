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

		/// <summary>
		/// Gets the direction to move this frame.
		/// </summary>
		/// <returns></returns>
		protected override Vector2 GetDirectionVector()
		{
			Vector2 directionVector = _target.transform.position - transform.position;
			return directionVector.normalized;
		}
	}
}
