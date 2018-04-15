using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public sealed class EnemySpawner : AbstractMonoBehaviour
{
	[SerializeField] private Protagonist m_Protagonist;

	[SerializeField] private Enemy m_EnemyPrefab;

	[SerializeField] private float m_MinDistanceFromProtag;

	[SerializeField] private float m_MaxDistanceFromProtag;

	[SerializeField] private uint m_MaxEnemies;

	[SerializeField] private float m_SpawnInterval;

	private readonly HashSet<Enemy> m_Enemies;
	private float m_LastSpawnTime;

	/// <summary>
	/// Constructor.
	/// </summary>
	public EnemySpawner()
	{
		m_Enemies = new HashSet<Enemy>();
	}

	/// <summary>
	/// Called when the MonoBehaviour becomes disabled.
	/// </summary>
	protected override void OnDisable()
	{
		base.OnDisable();

		DestroyEnemies();
	}

	/// <summary>
	/// Called when the MonoBehaviour becomes enabled.
	/// </summary>
	protected override void OnEnable()
	{
		base.OnEnable();

		m_LastSpawnTime = Time.time;
	}

	/// <summary>
	/// Called once per frame.
	/// </summary>
	protected override void Update()
	{
		base.Update();

		if (Time.time - m_LastSpawnTime >= m_SpawnInterval && m_Enemies.Count < m_MaxEnemies)
		{
			SpawnEnemy();
			m_LastSpawnTime = Time.time;
		}
	}

	/// <summary>
	/// Creates a new enemy instance and adds it to the collection.
	/// </summary>
	private void SpawnEnemy()
	{
		Vector2 position = Random.insideUnitCircle * (m_MaxDistanceFromProtag - m_MinDistanceFromProtag);
		position += position.normalized * m_MinDistanceFromProtag;

		Enemy enemy = Instantiate(m_EnemyPrefab, position, Quaternion.identity);
		m_Enemies.Add(enemy);
	}

	/// <summary>
	/// Destroys all of the spawned enemies.
	/// </summary>
	private void DestroyEnemies()
	{
		foreach (Enemy enemy in m_Enemies)
			Destroy(enemy);
		m_Enemies.Clear();
	}
}
