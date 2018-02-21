using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text displayText; 
	public InputAction[] inputActions;

	[HideInInspector] public RoomNavigation roomNavigation;
	[HideInInspector] public List<string> interactionDescripitionsInRoom = new List<string> ();

	List<string> actionLog = new List<string> ();
	// Use this for initialization
	void Awake () {
		roomNavigation = GetComponent<RoomNavigation> ();

	}
	void Start()
	{
		DisplayRoomText();
		DisplayLoggedText();
	}

	public void DisplayLoggedText()
	{
		string logAsText = string.Join ("\n", actionLog.ToArray ());
		displayText.text = logAsText;
	}

	public void DisplayRoomText()
	{
		ClearCollectionsForNewRoom ();

		UnpackRoom ();

		string joinedInteractionDescriptions = string.Join ("\n", interactionDescripitionsInRoom.ToArray ());
		string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;
		LogStringWithReturn (combinedText);
	}

	public void LogStringWithReturn(string stringToAdd)
	{
		actionLog.Add (stringToAdd + "\n");
	}
	// Update is called once per frame
	void Update () {
		
	}
	void UnpackRoom()
	{
		roomNavigation.UnpackedExitsInRoom ();
	}

	void ClearCollectionsForNewRoom()
	{
		interactionDescripitionsInRoom.Clear ();
		roomNavigation.ClearExits ();
	}

}
