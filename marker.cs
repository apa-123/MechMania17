using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//---------- CHANGE THIS NAME HERE -------
public class marker : MonoBehaviour
{
    public ObjectiveScript middleObjective;
    public ObjectiveScript leftObjective;
    public ObjectiveScript rightObjective;
    public float timer = 0;
    //---------- CHANGE THIS NAME HERE -------
    public static marker AddYourselfTo(GameObject host) {
        //---------- CHANGE THIS NAME HERE -------
        return host.AddComponent<marker>();
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
    bool char1HasMoved = false;
    bool inPosition = false;
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
    /*
    * function for all charachter to run every turn
    */
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

        if(goToNearItem(character1)) {

        }
        else if (leftObjective.getControllingTeam() != character1.getTeam()) //changed from middleObjective to leftObjective
        {
            character1.MoveChar(leftObjective.transform.position);
            character1.SetFacing(leftObjective.transform.position);
            //finds closest cover regardless of whether it is attacked or not
            //if(character1.attackedFromLocations.Count>0) 
            //character1.FindClosestCover(character1.attackedFromLocations[0]);
        }
        else {
            //character1.FindClosestCover(character1.attackedFromLocations[0]);

        }
            /**if(character1.attackedFromLocations.Count>0) 
            {
                character1.FindClosestCover(character1.attackedFromLocations[0]);
            }
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
        /*depending on  how close the enemy is either stops or continues rotating 
        foreach(Vector3 x in character1.visibleEnemyLocations)
        {
                if(Vector3.Distance(character1.getPrefabObject().transform.position, x)<5)
                {

                }
                else {
                    character1.rotateAngle(120.0f);
                    character1.MoveChar(leftObjective.transform.position);
                }

        }
        */
    }
    void Char2()
    {
        //Debug.Log(rightObjective.getControllingTeam());
        //sendToCapture(character2);
        //character2.FaceClosestWaypoint();
        //character2.MoveChar(middleObjective.transform.position);
        if(goToNearItem(character2)) {

        }
        else if (rightObjective.getControllingTeam() != character2.getTeam())
        {
            character2.MoveChar(rightObjective.transform.position);
            character2.SetFacing(rightObjective.transform.position);
        }
        /*
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
        */
    }
    //Agresssive attacc Charachter
    //bool clockwise = false;
    
    void Char3()
    {
        if(!goToNearItem(character3)) {
            if(character3.visibleEnemyLocations.Count>0) {
                character3.MoveChar(character3.FindClosestCover(character3.visibleEnemyLocations[character3.visibleEnemyLocations.Count-1]));
                character3.SetFacing(character3.visibleEnemyLocations[character3.visibleEnemyLocations.Count-1]);
            } else {
                character3.MoveChar(middleObjective.transform.position);
                character3.rotateAngle(80.0f);
            }
        }
        /*
        if(character3.visibleEnemyLocations.Count>0) {
            character3.FindClosestCover(character3.visibleEnemyLocations[character3.visibleEnemyLocations.Count-1]);
        }
        if(character3.visibleEnemyLocations.Count==0 && !inPosition) {
           character3.rotateAngle(80.0f);
        } else {
            if(inPosition) {
                //Vector3 offset = new Vector3(-30.0f,0.0f,10.0f);
                character3.SetFacing(character3.getPrefabObject().transform.position+offset);
            }
            //Debug.Log(character3.visibleEnemyLocations.Count);
            //character3.SetFacing(character3.visibleEnemyLocations[character3.visibleEnemyLocations.Count-1]);
        }
        if(goToNearItem(character3)) {

        }
        else {
            
            Vector3 offset = new Vector3(0.0f,0.0f,20.0f);
            character3.MoveChar(middleObjective.transform.position + offset);
            if(Vector3.Distance(character3.getPrefabObject().transform.position,middleObjective.transform.position + offset)<2) {
                //inPosition=true;
            }

            //character3.SetFacing(middleObjective.transform.position);
        }
        */
    }


    void sendToCapture(CharacterScript character) 
    {
        // send other two to capture
        if (middleObjective.getControllingTeam() != character1.getTeam())
        {
            character.MoveChar(rightObjective.transform.position);
            character.SetFacing(rightObjective.transform.position);
            if (character.attackedFromLocations.Capacity != 0)
            {
                character.FindClosestCover(character.attackedFromLocations[0]);
            }
        }
        else
        {
            // Then RIght
            if (rightObjective.getControllingTeam() != character1.getTeam())
            {
                character.MoveChar(rightObjective.transform.position);
                character.SetFacing(rightObjective.transform.position);
            }
            // Then left
            if (leftObjective.getControllingTeam() != character1.getTeam())
            {
                character.MoveChar(leftObjective.transform.position);
                character.SetFacing(leftObjective.transform.position);
            }
            
            
        }
    }
    bool goToNearItem(CharacterScript character) {
        if(Vector3.Distance(character.getPrefabObject().transform.position, character.FindClosestItem().transform.position)<5) 
        {
            character.MoveChar(character.FindClosestItem().transform.position);
            character.SetFacing(character.FindClosestItem().transform.position);
            return true;   
        }
        return false;
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