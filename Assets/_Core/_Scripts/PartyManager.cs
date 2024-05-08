using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{

    [SerializeField] private PartyMemberSO[] allMembers;
    [SerializeField] private List<PartyMember> currentParty;
    [SerializeField] private PartyMemberSO defaultMember;

    private void Awake()
    {
        AddPartyMemberByName(defaultMember.memberName);
    }

    public void AddPartyMemberByName(string name)
    {
        Debug.Log("Test!");
        for (int i = 0; i < allMembers.Length; i++)
        {
            if (allMembers[i].memberName == name)
            {
                AddMember(i);
            }
        }        
    }

    private void AddMember(int index)
    {
        PartyMember member = new PartyMember();

        member.memberName = allMembers[index].memberName;
        member.level = allMembers[index].initialLevel;
        member.currentHealth = allMembers[index].baseHealth;
        member.maxHealth = member.currentHealth;
        member.str = allMembers[index].baseStr;
        member.initiative = allMembers[index].baseIntitiative;
        member.memberBattleVisualPrefab = allMembers[index].memberBattleVisualPrefab;
        member.memberOverworldVisualPrefab = allMembers[index].memberOverworldVisualPrefab;

        currentParty.Add(member);
        Debug.Log("Added!");
    }

    public List<PartyMember> GetCurrentMembers() => currentParty;
}

[System.Serializable]
public class PartyMember
{
    public string memberName;
    public int level;
    public int currentHealth;
    public int maxHealth;
    public int str;
    public int initiative;
    public int currentExp;
    public int maxExp;
    public GameObject memberBattleVisualPrefab;
    public GameObject memberOverworldVisualPrefab;

}
