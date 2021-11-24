using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class EnemyData : ScriptableObject
{
	[SerializeField] public float enemySpeed;
	[SerializeField] public float attackCooldownSpeed;
	[SerializeField] public float bulletSpeed;
	[SerializeField] public int bulletDamage;

    
}