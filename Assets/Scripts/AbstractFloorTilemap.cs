using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
	public class AbstractFloorTilemap : AbstractMonoBehaviour
	{
		[SerializeField]
		private Tile m_FloorTile;

		private Tilemap m_Tilemap;

		protected override void OnEnable()
		{
			m_Tilemap = GetComponent<Tilemap>();
			var bounds = m_Tilemap.cellBounds;
			for (int i = bounds.xMin; i < bounds.xMax; i++)
				for (int j = bounds.yMin; j < bounds.yMax; j++)
					m_Tilemap.SetTile(new Vector3Int(i, j, 0), m_FloorTile);
		}
	}
}
