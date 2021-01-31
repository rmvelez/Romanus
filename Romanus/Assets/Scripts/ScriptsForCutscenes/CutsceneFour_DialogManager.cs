using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneFour_DialogManager : MonoBehaviour
{
	public GameObject hospitalVictor;

	public GameObject finalVictor;

	public GameObject doctorXerox;

	public GameObject guardOne;

	public GameObject guardTwo;

	public GameObject changingBooth;

	public GameObject skipButton;

	public Text convoContent;


	private Queue<string> sentences;  //data structure that allow you to only  add items to
	// end and remove from the beginning (first in first out)

	// Use this for initialization
	void Start () 
	{
		sentences = new Queue<string> ();	// create our queue from sentences
		hospitalVictor.SetActive(true);
		finalVictor.SetActive(false);
		doctorXerox.SetActive(false);
		guardOne.SetActive(false);
		guardTwo.SetActive(false);
		changingBooth.SetActive(false);
		skipButton.SetActive (false);
	}

	public void StartDialog(Dialog dialog){  //method called at start of a conversation
		Debug.Log ("talk to " + dialog.name); // check to make sure this works


		// first need to clear out any previous conversation that might linger in sentences array
		sentences.Clear();

		// then loop through the array and line up each sentence currently in it to prepare 
		foreach(string sentence in dialog.sentences){

			sentences.Enqueue (sentence); // put each in the queue
		}
		// then call a method to actually display it

		DisplayNextSentence ();
	}

	public void DisplayNextSentence (){

		// first check to see if we are at the end of convo and if so call end method

		if (sentences.Count == 0) { // if array is empty
			EndConvo (); // call end method
			return;		// leave the function
		}
		string sentence = sentences.Dequeue ();  // otherwise pull sentence out of the queue
		Debug.Log(sentences.Count);
		convoContent.text = sentence;

		if (sentences.Count == 38) 
		{
			Debug.Log ("number is even");
		}

		else if (sentences.Count == 37)
		{
			Debug.Log("number is odd");
		}

		else if (sentences.Count == 36)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 35)
		{
			Debug.Log("number is odd");
			doctorXerox.SetActive (true);
		}

		else if (sentences.Count == 34)
		{
			Debug.Log("number is even");
			skipButton.SetActive (true);
		}

		else if (sentences.Count == 33)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 32)
		{
			Debug.Log("number is odd");
		}

		else if (sentences.Count == 31)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 30)
		{
			Debug.Log("number is odd");
			guardOne.SetActive (true);
		}
		else if (sentences.Count == 29)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 28)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 27)
		{
			Debug.Log("number is even");
		}
		else if (sentences.Count == 26)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 25)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 24)
		{
			Debug.Log("number is even");
			guardOne.SetActive (false);
		}

		else if (sentences.Count == 23)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 22)
		{
			Debug.Log("number is even");
		}
		else if (sentences.Count == 21)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 20)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 19)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 18)
		{
			Debug.Log("number is even");
		}
		else if (sentences.Count == 17)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 16)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 15)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 14)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 13)
		{
			Debug.Log("number is even");
		}
		else if (sentences.Count == 12)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 11)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 10)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 9)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 8)
		{
			Debug.Log("number is even");
			guardOne.SetActive (true);
			guardTwo.SetActive (true);
		}
		else if (sentences.Count == 7)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 6)
		{
			Debug.Log("number is even");
			changingBooth.SetActive (true);
			guardOne.SetActive (false);
			guardTwo.SetActive (false);
		}

		else if (sentences.Count == 5)
		{
			Debug.Log("number is even");
			changingBooth.SetActive (false);
			hospitalVictor.SetActive (false);
			finalVictor.SetActive (true);
		}

		else if (sentences.Count == 4)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 3)
		{
			Debug.Log("number is even");
		}
		else if (sentences.Count == 2)
		{
			Debug.Log("number is odd");
		}
		else if (sentences.Count == 1)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 0)
		{
			Debug.Log("number is even");
		}
		else 
		{
			Debug.Log ("number is odd");
		}
	}

	public void EndConvo (){
		Debug.Log ("reached end of convo");
		SceneManager.LoadScene("LevelThree");
	}
}