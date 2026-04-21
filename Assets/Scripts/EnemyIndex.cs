using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyIndex : ScriptableObject
{
    public string enemyName;
    public Sprite loadEnemy;


    [Header("Attacks")]
    public int attack1, attack2, attack3, attack4;

    [Header("Defends")]
    public int defend1, defend2, defend3, defend4;

    [Header("Health")]
    public int health;
}
