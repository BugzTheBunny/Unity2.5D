using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public int baseHealth;
    public int baseStr;
    public int baseIntiative;

    public GameObject enemyVisualPrefab;
}
