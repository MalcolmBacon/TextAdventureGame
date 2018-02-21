using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

	public Room currentRoom;

	private GameController _controller;

	Dictionary<string,Room> exitDictionary = new Dictionary<string,Room>();


	void Awake()
	{
		_controller = GetComponent<GameController> ();
	}

	public void UnpackedExitsInRoom() //go over array of exits and pass over to game controller to display on screen
	{
		for (int i = 0; i < currentRoom.exits.Length; i++) {
			exitDictionary.Add (currentRoom.exits [i].keyString, currentRoom.exits [i].valueRoom);
			_controller.interactionDescripitionsInRoom.Add (currentRoom.exits [i].exitDescription);
		}
	
	}

	public void AttemptToChangeRooms(string directionNoun)
	{
		if (exitDictionary.ContainsKey (directionNoun)) {
			currentRoom = exitDictionary [directionNoun];
			_controller.LogStringWithReturn ("You head off to the " + directionNoun);
			_controller.DisplayRoomText ();
		} else {
			_controller.LogStringWithReturn ("There is no path to the " + directionNoun);

		}
	}
	public void ClearExits()
	{
		exitDictionary.Clear ();
	}
}
