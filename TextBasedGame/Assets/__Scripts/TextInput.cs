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

		//Breaks user input into different words by using a space
		char[] delimiterCharacters = { ' ' };
		string[] separatedInputWords = userInput.Split (delimiterCharacters);

		for (int i = 0; i < _controller.inputActions.Length; i++) {
			InputAction inputAction = _controller.inputActions [i];
			if (inputAction.keyWord == separatedInputWords [0]) {
				inputAction.RespondToInput (_controller, separatedInputWords);
			} //action should be first, if it is, pass in array and controller
		}
		InputComplete ();
	}

	void InputComplete()
	{
		_controller.DisplayLoggedText ();
		inputField.ActivateInputField ();
		inputField.text = null;
	}
}
