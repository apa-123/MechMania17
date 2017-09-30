using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------- CHANGE THIS NAME HERE -------
public class TEAM_BLUE_SCRIPT : MonoBehaviour
{
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
        character1 = transform.Find("Character1").gameObject.GetComponent<CharacterScript>();
        character2 = transform.Find("Character2").gameObject.GetComponent<CharacterScript>();
        character3 = transform.Find("Character3").gameObject.GetComponent<CharacterScript>();
    }
    /*^^^^ DO NOT MODIFY ^^^^*/

    /* Your code below this line */
    // Update() is called every frame
    void Update()
	{
        // Debug.Log(character1.name + " " + character1.);
        //character1.FaceClosestWaypoint();
        character1.SetFacing(character1.FindClosestObjective());
        character2.SetFacing(character2.FindClosestObjective());
        character3.SetFacing(character3.FindClosestObjective());

        //set loadouts for each character
        if (character1.getZone() == zone.BlueBase || character1.getZone() == zone.RedBase)
            character1.setLoadout(loadout.MEDIUM);
        if (character2.getZone() == zone.BlueBase || character2.getZone() == zone.RedBase)
            character2.setLoadout(loadout.LONG);
        if (character2.getZone() == zone.BlueBase || character2.getZone() == zone.RedBase)
            character3.setLoadout(loadout.LONG);

        character2.MoveChar(new Vector3(5.0f, 5.0f, 5.0f));
        character3.MoveChar(new Vector3(5.0f, 5.0f, 5.0f));
        character1.MoveChar(new Vector3(5.0f, 5.0f, 5.0f));
        Debug.Log(character1.FindClosestObjective().magnitude);
        if (character1.FindClosestObjective().magnitude<=0.0f)
        {
            character1.MoveChar(new Vector3(0.0f, 0.0f, 0.0f));
        }

    } 
}
