using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace UnityEngine.Tilemaps
{
	[Serializable]
	public class WeightedRandomTile : Tile
	{
		[SerializeField]
		public Sprite[] m_Sprites;
		public float[] m_Weights;

		public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
		{
			base.GetTileData(location, tileMap, ref tileData);
			if ((m_Sprites != null) && (m_Sprites.Length > 0))
			{
				long hash = location.x;
				hash = (hash + 0xabcd1234) + (hash << 15);
				hash = (hash + 0x0987efab) ^ (hash >> 11);
				hash ^= location.y;
				hash = (hash + 0x46ac12fd) + (hash << 7);
				hash = (hash + 0xbe9730af) ^ (hash << 11);
				Random.InitState((int)hash);

				float[] weights = GetCumulativeWeightArray();
				// get random value between 0 and the total weight
				float randomValue = Random.value* weights[weights.Length - 1];

				// binary search to find index in weight array
				int index = Array.BinarySearch(weights, randomValue);
				// if the binary search didn't find the value exactly, it will return the two's complement of the index
				// of the first value that is greater, or the two's complement of the array's length if all greater
				// so basically, if it's negative, take the two's complement
				if(index < 0)
					index = ~index;

				tileData.sprite = m_Sprites[index];
			}
		}

		private float[] GetCumulativeWeightArray()
		{
			if (m_Weights == null || m_Weights.Length <= 0)
				throw new InvalidOperationException("No weights for sprites");

			float[] cdfArray = new float[m_Weights.Length];

			// calculate cumulative weights
			cdfArray[0] = m_Weights[0];
			for (int i = 1; i < m_Weights.Length; i++)
				cdfArray[i] = cdfArray[i - 1] + m_Weights[i];

			return cdfArray;
		}

#if UNITY_EDITOR
		[MenuItem("Assets/Create/Weighted Random Tile")]
		public static void CreateRandomTile()
		{
			string path = EditorUtility.SaveFilePanelInProject("Save Weighted Random Tile", "New Weighted Random Tile", "asset", "Save Weighted Random Tile", "Assets");

			if (path == "")
				return;

			AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WeightedRandomTile>(), path);
		}
#endif
	}

#if UNITY_EDITOR
	[CustomEditor(typeof(WeightedRandomTile))]
	public class WeightedRandomTileEditor : Editor
	{
		private WeightedRandomTile tile { get { return (target as WeightedRandomTile); } }

		public override void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck();
			int count = EditorGUILayout.DelayedIntField("Number of Sprites", tile.m_Sprites != null ? tile.m_Sprites.Length : 0);
			if (count < 0)
				count = 0;
			if (tile.m_Sprites == null || tile.m_Sprites.Length != count)
			{
				Array.Resize<Sprite>(ref tile.m_Sprites, count);
			}
			if (tile.m_Weights == null || tile.m_Weights.Length != count)
			{
				Array.Resize<float>(ref tile.m_Weights, count);
			}

			if (count == 0)
				return;

			EditorGUILayout.LabelField("Place random sprites.");
			EditorGUILayout.Space();

			for (int i = 0; i < count; i++)
			{
				tile.m_Sprites[i] = (Sprite)EditorGUILayout.ObjectField("Sprite " + (i + 1), tile.m_Sprites[i], typeof(Sprite), false, null);
				tile.m_Weights[i] = EditorGUILayout.FloatField("Weight", tile.m_Weights[i]);
				EditorGUILayout.Space();
			}
			if (EditorGUI.EndChangeCheck())
				EditorUtility.SetDirty(tile);
		}
	}
#endif
}
