using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private EnemySO[] allEnemies;
    [SerializeField] private List<Enemy> currentEnemies;

    private const float LEVEL_MODIFIER = 0.5f;

    private void Awake()
    {
        GenerateEnemyByName("Slime",1);
    }

    private void GenerateEnemyByName(string name, int level)
    {
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if (name == allEnemies[i].enemyName)
            {
                AddEnemy(i,1);
            }
        }
    }

    private void AddEnemy(int index,int level)
    {
        Enemy enemy = new Enemy();

        enemy.enemyName = allEnemies[index].enemyName;
        enemy.level = level;
        float modifier = (LEVEL_MODIFIER * enemy.level);
        enemy.maxHealth = Mathf.RoundToInt(allEnemies[index].baseHealth + (allEnemies[index].baseHealth * modifier));
        enemy.currentHealth = enemy.maxHealth;
        enemy.str= Mathf.RoundToInt(allEnemies[index].baseStr + (allEnemies[index].baseStr * modifier));
        enemy.initiative= Mathf.RoundToInt(allEnemies[index].baseIntiative+ (allEnemies[index].baseIntiative * modifier));
        enemy.enemyVisualPrefab = allEnemies[index].enemyVisualPrefab;
        
        currentEnemies.Add(enemy);

    }

    public List<Enemy> GetCurrentEnemies() => currentEnemies;
}

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public int level;
    public int currentHealth;
    public int maxHealth;
    public int str;
    public int initiative;

    public GameObject enemyVisualPrefab;
}
