﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class HeartContainer : AbstractMonoBehaviour
	{
		[SerializeField] private Image m_FullHeart;

		[SerializeField] private int m_HealthPerHeart = 4;

		public void SetHeartAmount(int health)
		{
			m_FullHeart.fillAmount = (float)health / m_HealthPerHeart;
		}
	}
}