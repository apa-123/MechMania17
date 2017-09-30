using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//---------- CHANGE THIS NAME HERE -------
public class TEAM_BLUE_SCRIPT : MonoBehaviour
{
    public ObjectiveScript middleObjective;
    public ObjectiveScript leftObjective;
    public ObjectiveScript rightObjective;
    public float timer = 0;
    //---------- CHANGE THIS NAME HERE -------
    public static TEAM_BLUE_SCRIPT AddYourselfTo(GameObject host) {
        //---------- CHANGE THIS NAME HERE -------
        return host.AddComponent<TEAM_BLUE_SCRIPT>();
    }

    /*vvvv DO NOT MODIFY vvvvv*/
    [SerializeField]
    public CharacterScript character1;
    [SerializeField]
    public CharacterScript character2;
    [SerializeField]
    public CharacterScript character3; 

    void Start()
    {
        // populate the objectives
        middleObjective = GameObject.Find("MiddleObjective").GetComponent<ObjectiveScript>();
        leftObjective = GameObject.Find("LeftObjective").GetComponent<ObjectiveScript>();
        rightObjective = GameObject.Find("RightObjective").GetComponent<ObjectiveScript>();

        character1 = transform.Find("Character1").gameObject.GetComponent<CharacterScript>();
        character2 = transform.Find("Character2").gameObject.GetComponent<CharacterScript>();
        character3 = transform.Find("Character3").gameObject.GetComponent<CharacterScript>();

    }
    /*^^^^ DO NOT MODIFY ^^^^*/

    /* Your code below this line */
    // Update() is called every frame
    void Update()
	{
        basicUpdate(character1);
        basicUpdate(character2);
        basicUpdate(character3);
        Char1();
        Char2();
        Char3();
        

    } 
    void basicUpdate(CharacterScript character)
    {
         //Set caracter loadouts, can only happen when the characters are at base.
        
        // in the first couple of seconds we just scan around
        if (timer < 10)
        {
            character.FaceClosestWaypoint();
        }
        
        
    }
    void Char1()
    {
        //set loadout
        if (character1.getZone() == zone.BlueBase || character1.getZone() == zone.RedBase)
        {
            character1.setLoadout(loadout.SHORT);
        }

        character1.FaceClosestWaypoint();
        if (middleObjective.getControllingTeam() != character1.getTeam())
        {
            character1.MoveChar(leftObjective.transform.position);
            character1.SetFacing(leftObjective.transform.position);
            if(character1.attackedFromLocations.Count>0) 
            {
                character1.FindClosestCover(character1.attackedFromLocations[0]);
            }
        }
        character1.isDoneMoving();
        if (character1.getHP() <= 40) 
        {
            character1.FindClosestItem();
        }
        /*
       // place sniper in position, run to cover if attacked
        if (character1.attackedFromLocations.Capacity == 0)
        {
            character1.MoveChar(new Vector3(-8.8f, 1.5f, 13.5f));
            character1.SetFacing(middleObjective.transform.position);
        }
        else
        {
            character1.MoveChar(character1.FindClosestCover(character1.attackedFromLocations[0]));
        } 
        */
    }
    void Char2()
    {
        //sendToCapture(character2);
        if (rightObjective.getControllingTeam() != character2.getTeam())
        {
            character2.MoveChar(rightObjective.transform.position);
            character2.SetFacing(rightObjective.transform.position);
        }
        if (middleObjective.getControllingTeam() != character2.getTeam())
        {
            character2.MoveChar(middleObjective.transform.position);
            character2.SetFacing(middleObjective.transform.position);
        }
        if ((rightObjective.getControllingTeam() == character2.getTeam()) & (rightObjective.getControllingTeam() == character2.getTeam()));
        {
            if(character2.attackedFromLocations.Count>0) 
            {
                character2.FindClosestCover(character2.attackedFromLocations[0]);
            }
            character2.isDoneMoving();
        }
    }
    //Agresssive attacc Charachter
    void Char3()
    {
        sendToCapture(character3);
    }
    void sendToCapture(CharacterScript character) 
    {
        // send other two to capture
        if (middleObjective.getControllingTeam() != character1.getTeam())
        {
            character.MoveChar(leftObjective.transform.position);
            character.SetFacing(leftObjective.transform.position);
            if (character.attackedFromLocations.Capacity != 0)
            {
                character.FindClosestCover(character.attackedFromLocations[0]);
            }
        }
        else
        {
            // Then left
            if (leftObjective.getControllingTeam() != character1.getTeam())
            {
                character.MoveChar(leftObjective.transform.position);
                character.SetFacing(leftObjective.transform.position);
            }
            // Then RIght
            if (rightObjective.getControllingTeam() != character1.getTeam())
            {
                character.MoveChar(rightObjective.transform.position);
                character.SetFacing(rightObjective.transform.position);
            }
        }
    }
}

/*
if (character1.getZone() == zone.BlueBase || character1.getZone() == zone.RedBase)
        {
            character1.setLoadout(loadout.SHORT);
        }
        character1.FaceClosestWaypoint();
        if (middleObjective.getControllingTeam() != character1.getTeam())
        {
            character1.MoveChar(leftObjective.transform.position);
            character1.SetFacing(leftObjective.transform.position);
            character1.FindClosestCover(character1.attackedFromLocations[0]);
        }
        character1.isDoneMoving();
        if (character1.getHP() <= 40) 
        {
            character1.FindClosestItem();
        }






if (rightObjective.getControllingTeam() != character2.getTeam())
        {
            character2.MoveChar(rightObjective.transform.position);
            character2.SetFacing(rightObjective.transform.position);
        }
        if (middleObjective.getControllingTeam() != character.getTeam())
        {
            character2.MoveChar(middleObjective.transform.position);
            character2.SetFacing(middleObjective.transform.position);
        }
        if ((rightObjective.getControllingTeam() = character2.getTeam()) & (rightObjective.getControllingTeam() = character2.getTeam()));
        {
            character2.FindClosestCover(character2.attackedFromLocations[0]);
            character2.isDoneMoving();
        }
*/