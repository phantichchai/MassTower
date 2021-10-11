using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TowerScriptableObject")]
public class TestScriptableObject : ScriptableObject
{
    public string towerName;
    public Tower tower;
    public Debuff debuff;
    public Bullet projectile;
    public GameObject towerSprite;
}
