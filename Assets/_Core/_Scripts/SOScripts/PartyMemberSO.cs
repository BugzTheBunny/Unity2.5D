using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Party Member")]
public class PartyMemberSO : ScriptableObject
{
    public string memberName;
    public int initialLevel;
    public int baseHealth;
    public int baseStr;
    public int baseIntitiative;

    public GameObject memberBattleVisualPrefab; // In Battle Scene
    public GameObject memberOverworldVisualPrefab; // In Overworld Scene

}
