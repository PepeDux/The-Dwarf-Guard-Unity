using UnityEngine;

public class ArmorCalculation : MonoBehaviour
{
    public string currentArmor;
    public string currentArmorType;

    //public string currentArmorChest;
    //public string currentArmorHands;
    //public string currentArmorLegs;
    //public string currentArmorFeet;

    public string lastArmor;
    public string lastArmorType;

    //public string lastArmorChest;
    //public string lastArmorHands;
    //public string lastArmorLegs;
    //public string lastArmorFeet;
    private int mod = 1;

    [SerializeField] private ArmorData[] armors;

    void Start()
    {
        armors = Resources.LoadAll<ArmorData>("Armors");

        if(GetComponent<Player>().headArmor != null)
        {
            currentArmor = GetComponent<Player>().headArmor.name;
            ChangeArmor();
        }
       
        if (GetComponent<Player>().chestArmor != null)
        {
            currentArmor = GetComponent<Player>().chestArmor.name;
            ChangeArmor();
        }

        if (GetComponent<Player>().handsArmor != null)
        {
            currentArmor = GetComponent<Player>().handsArmor.name;
            ChangeArmor();
        }

        if (GetComponent<Player>().legsArmor != null)
        {
            currentArmor = GetComponent<Player>().legsArmor.name;
            ChangeArmor();
        }

        if (GetComponent<Player>().feetArmor != null)
        {
            currentArmor = GetComponent<Player>().feetArmor.name;
            ChangeArmor();
        }
    }
    void FixedUpdate()
    {
        ChangeArmor();
    }

    private void ChangeArmor()
    {
        if (currentArmor != null && currentArmor != "")
        {
            Calculation();
            currentArmor = null;
        }
        else if (currentArmor == null || currentArmor == "") 
        {

        }
        
    }

    private void Calculation()
    {
        foreach (ArmorData armor in armors)
        {
            if (armor.name == currentArmor || armor.name == lastArmor)
            {
                if (armor.name == currentArmor)
                {
                    mod = 1;

                    if (armor.type == "headArmor")
                    {
                        GetComponent<Player>().headArmor = armor;
                    }

                    if (armor.type == "chestArmor")
                    {
                        GetComponent<Player>().chestArmor = armor;
                    }

                    if (armor.type == "handsArmor")
                    {
                        GetComponent<Player>().handsArmor = armor;
                    }

                    if (armor.type == "legsArmor")
                    {
                        GetComponent<Player>().legsArmor = armor;
                    }

                    if (armor.type == "feetArmor")
                    {
                        GetComponent<Player>().feetArmor = armor;
                    }

                }
                else if (armor.name == lastArmor)
                {
                    mod = -1;
                }

                GetComponent<MainObject>().strengthBonus += mod * armor.strength;
                GetComponent<MainObject>().agilityBonus += mod * armor.agility;
                GetComponent<MainObject>().intelBonus += mod * armor.intel;
                GetComponent<MainObject>().constitutionBonus += mod * armor.constitution;
                GetComponent<MainObject>().wisdomBonus += mod * armor.wisdom;

                GetComponent<MainObject>().carryingCapacityBonus += mod * armor.carryingCapacity;
                GetComponent<MainObject>().speedBonus += mod * armor.speed;
                GetComponent<MainObject>().attackSpeedBonus += mod * armor.attackSpeed;
                GetComponent<MainObject>().criticalDamageBonus += mod * armor.criticalDamage;
                GetComponent<MainObject>().criticalDamageChanceBonus += mod * armor.CriticalDamageChance;
                GetComponent<MainObject>().precisionBonus += mod * armor.Precision;
                GetComponent<MainObject>().drunkennessBonus += mod * armor.drunkenness;

                GetComponent<MainObject>().prickResistBonus += mod * armor.prickResist;
                GetComponent<MainObject>().slashResistBonus += mod * armor.slashResist;
                GetComponent<MainObject>().crushResistBonus += mod * armor.CrushResist;
                GetComponent<MainObject>().poisonResistBonus += mod * armor.poisonResist;
                GetComponent<MainObject>().fireResistBonus += mod * armor.fireResist;
                GetComponent<MainObject>().frostResistBonus += mod * armor.frostResist;
                GetComponent<MainObject>().curseResistBonus += mod * armor.curseResist;
                GetComponent<MainObject>().electricalResistBonus += mod * armor.electricalResist;
                GetComponent<MainObject>().drunkennessResistBonus += mod * armor.drunkennessResist;

                GetComponent<MainObject>().hammerWayBonus += mod * armor.hammerWay;
                GetComponent<MainObject>().gearWayBonus += mod * armor.gearWay;
                GetComponent<MainObject>().anvilWayBonus += mod * armor.anvilWay;
                GetComponent<MainObject>().beerWayBonus += mod * armor.beerWay;
                GetComponent<MainObject>().runeWayBonus += mod * armor.runeWay;
            }
        }
    }



}
