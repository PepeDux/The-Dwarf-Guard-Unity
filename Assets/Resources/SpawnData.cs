using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnData", menuName = "SpawnData", order = 51)]
public class SpawnData : ScriptableObject
{
    [Header("Юниты на уровне")]

    [SerializeField] public int melee;
    public int Melee { get => melee; }

    [SerializeField] public int range;
    public int Range { get => range; }

    [SerializeField] public int captain;
    public int Captain { get => captain; }

    [SerializeField] public int wizard;
    public int Wizard { get => wizard; }



    [Header("Статичные объекты")]

    [SerializeField] public int wall;
    public int Wall { get => wall; }

    [SerializeField] public int pit;
    public int Pit { get => pit; }



    [Header("Функциональные объекты")]

    [SerializeField] public int trap;
    public int Trap { get => trap; }

    [SerializeField] public int food;
    public int Food { get => food; }

    [SerializeField] public int money;
    public int Money { get => money; }

    [SerializeField] public int crystal;
    public int Crystal { get => crystal; }

}
