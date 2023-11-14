using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Units/Unit")]
public class Unit : ScriptableObject
{
    public string characterName;
    public Sprite portrait;

    public int health;
    public int strength;
    public int magic;
    public int skill;
    public int speed;
    public int luck;
    public int defense;
    public int resistance;
    public int movement;

}
