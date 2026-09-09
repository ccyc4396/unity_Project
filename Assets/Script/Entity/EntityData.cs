using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New EntityData",menuName ="GameData/EntityData")]
public class EntityData :ScriptableObject
{
    public int maxHeath;
    
    public int attackPower;

    public int moveSpeed;


}
