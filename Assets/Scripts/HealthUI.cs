
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class HealthUI : AbstractMonoBehaviour
	{
		[SerializeField]
		private HeartContainer m_HeartContainer;

		[SerializeField]
		private Protagonist m_Protagonist;

		[SerializeField]
		private int m_HeartsPerRow;

		private List<HeartContainer> m_HeartContainers = new List<HeartContainer>();

		private float m_OffsetX;
		private float m_OffsetY;

		protected override void OnEnable()
		{
			base.OnEnable();

			m_OffsetX = ((RectTransform)m_HeartContainer.transform).rect.width;
			m_OffsetY = ((RectTransform)m_HeartContainer.transform).rect.height;
			Debug.Log(m_OffsetX);
			int heartContainers = m_Protagonist.MaxHealth / m_HeartContainer.HealthPerHeart;
			for (int i = 0; i < heartContainers; i++)
			{
				var newHeart = Instantiate(m_HeartContainer, transform);
				newHeart.gameObject.transform.Translate(new Vector2(m_OffsetX * (i % m_HeartsPerRow), -(i / m_HeartsPerRow) * m_OffsetY));
				m_HeartContainers.Add(newHeart);
			}
		}

		protected override void Update()
		{
			base.Update();

			var health = m_Protagonist.Health;
			var healthPerHeart = m_HeartContainer.HealthPerHeart;
			for (int i = 0; i < m_HeartContainers.Count; i++)
			{
				if (health > healthPerHeart)
				{
					m_HeartContainers[i].SetHeartAmount(healthPerHeart);
					health -= healthPerHeart;
				}
				else
				{
					m_HeartContainers[i].SetHeartAmount(health);
					health = 0;
				}
			}
		}
	}
}
