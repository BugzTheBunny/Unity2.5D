using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [Header("  Spawn Points  ")]
    [SerializeField] private Transform[] partySpawnPoints;
    [SerializeField] private Transform[] enemySpawnPoints;

    [Header("  Battlers  ")]
    [SerializeField] private List<BattleEntitie> battlers = new List<BattleEntitie>();
    [SerializeField] private List<BattleEntitie> enemyBattlers = new List<BattleEntitie>();
    [SerializeField] private List<BattleEntitie> playerBattlers = new List<BattleEntitie>();

    private PartyManager partyManager;
    private EnemyManager enemyManager;

    void Start()
    {
        partyManager = FindFirstObjectByType<PartyManager>();   
        enemyManager = FindFirstObjectByType<EnemyManager>();

        CreatePartyEntities();
        CreateEnemyEntities(); 
    }

    private void CreatePartyEntities()
    {
        List<PartyMember> currentParty = new List<PartyMember>();
        currentParty = partyManager.GetCurrentMembers();

        foreach(PartyMember m in currentParty)
        {
            BattleEntitie entity = new BattleEntitie(m.memberName,m.currentHealth,m.maxHealth,m.initiative,m.str,m.level,true);
            battlers.Add(entity);
            playerBattlers.Add(entity);
        }
    }

    private void CreateEnemyEntities()
    {
        List<Enemy> currentEnemies = new List<Enemy>();
        currentEnemies = enemyManager.GetCurrentEnemies();

        foreach(Enemy e in currentEnemies)
        {
            BattleEntitie entity = new BattleEntitie(e.enemyName, e.currentHealth, e.maxHealth, e.initiative, e.str, e.level, false);
            battlers.Add(entity);
            enemyBattlers.Add((entity));
        }
    }
}


[System.Serializable]
public class BattleEntitie
{
    public string _name;
    public int currentHealth;
    public int maxHealth;
    public int initiative;
    public int str;
    public int level;
    public bool isPlayer;

    public BattleEntitie(string name, int currentHealth, int maxHealth, int initiative, int str, int level, bool isPlayer)
    {
        _name = name;
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.initiative = initiative;
        this.str = str;
        this.level = level;
        this.isPlayer = isPlayer;
    }
}
