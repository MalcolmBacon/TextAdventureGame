using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Seriablizable attribute lets you embed a class with sub properties in the inspector
//want to be able to display the exit inside inspector
//for room scriptable object
//room holds an array, display variables inside variable class

public class Exit
{

	public string keyString;
	public string exitDescription;
	public Room valueRoom;

}
