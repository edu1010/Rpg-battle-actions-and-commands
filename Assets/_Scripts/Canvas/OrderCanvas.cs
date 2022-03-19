using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject[] ReferencePointsNoS;

    [SerializeField]
    static GameObject[] ReferencePoints;
    static GameObject Blue;
    static GameObject Red;
    static GameObject Purple;
    static GameObject Yellow;
    static GameObject Green;
    static GameObject Pink; 

    [SerializeField]
    GameObject BlueNoS;
     [SerializeField]
    GameObject RedNoS;
     [SerializeField]
    GameObject PurpleNoS;
     [SerializeField]
    GameObject YellowNoS;
     [SerializeField]
    GameObject GreenNoS;
     [SerializeField]
    GameObject PinkNoS;
    private void Awake()
    {
        ReferencePoints = ReferencePointsNoS;
        Blue = BlueNoS;
        Red = RedNoS;
        Pink = PinkNoS;
        Purple = PurpleNoS;
        Green = GreenNoS;
        Yellow = YellowNoS;
    }
    public static void Order()
    {
        for(int i=0; i< TurnManager.EntitiesOrder.Length; i++)
        {
            AnimalToMove(i).transform.position = ReferencePoints[i].transform.position;
        }
    }
    public static void next()
    {

    }
    public static void animalDie(EnumEntities animal)
    {
        switch (animal)
        {
            case (EnumEntities.DinosaurRed):
                Red.SetActive(false);
                break;
            case (EnumEntities.DinousaurBlue):
                Blue.SetActive(false);
                break;
            case (EnumEntities.DinousaurPink):
                Pink.SetActive(false);
                break;
            case (EnumEntities.DinousaurGreen):
                Green.SetActive(false);
                break;
            case (EnumEntities.DinousaurYellow):
                Yellow.SetActive(false);
                break;
            case (EnumEntities.DinousaurPurple):
                Purple.SetActive(false);
                break;
        }
    }
    public static void animalRevive(EnumEntities animal)
    {
        switch (animal)
        {
            case (EnumEntities.DinosaurRed):
                Red.SetActive(true);
                break;
            case (EnumEntities.DinousaurBlue):
                Blue.SetActive(true);
                break;
            case (EnumEntities.DinousaurPink):
                Pink.SetActive(true);
                break;
            case (EnumEntities.DinousaurGreen):
                Green.SetActive(true);
                break;
            case (EnumEntities.DinousaurYellow):
                Yellow.SetActive(true);
                break;
            case (EnumEntities.DinousaurPurple):
                Purple.SetActive(true);
                break;
        }
    }


    private static GameObject AnimalToMove(int pos)
    {
        if (TurnManager.EntitiesOrder[pos].animal == EnumEntities.DinosaurRed)
        {
            return Red;
        }
        else if (TurnManager.EntitiesOrder[pos].animal == EnumEntities.DinousaurBlue)
        {
            return Blue;
        }
        else if (TurnManager.EntitiesOrder[pos].animal == EnumEntities.DinousaurPink)
        {
            return Pink;
        }else if (TurnManager.EntitiesOrder[pos].animal == EnumEntities.DinousaurGreen)
        {
            return Green;
        }else if (TurnManager.EntitiesOrder[pos].animal == EnumEntities.DinousaurYellow)
        {
            return Yellow;
        }else 
        {
            return Purple;
        }


    }
}
