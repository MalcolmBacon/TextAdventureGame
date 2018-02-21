using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {

	public InputField inputField;

	private GameController _controller;

	void Awake()
	{
		_controller = GetComponent<GameController> ();
		inputField.onEndEdit.AddListener (AcceptStringInput);
	}

	void AcceptStringInput(string userInput)
	{
		userInput = userInput.ToLower ();
		_controller.LogStringWithReturn (userInput);
		InputComplete ();
	}

	void InputComplete()
	{
		_controller.DisplayLoggedText ();
		inputField.ActivateInputField ();
		inputField.text = null;
	}
}
