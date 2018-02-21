using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

	public Room currentRoom;

	private GameController _controller;

	void Awake()
	{
		_controller = GetComponent<GameController> ();
	}

	public void UnpackedExitsInRoom() //go over array of exits and pass over to game controller to display on screen
	{
		for (int i = 0; i < currentRoom.exits.Length; i++) {
			_controller.interactionDescripitionsInRoom.Add (currentRoom.exits [i].exitDescription);
		}
	
	}

}
