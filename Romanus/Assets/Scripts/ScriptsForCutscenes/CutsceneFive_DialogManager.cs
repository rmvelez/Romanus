using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneFive_DialogManager : MonoBehaviour
{
	public Image cutsceneImageOne; // references to the backgroudn images
	public Image cutsceneImageTwo;
	public Image cutsceneImageThree;

	public GameObject romanusOne;
	public GameObject romanusTwo;
	public GameObject bossThree;
	public GameObject catOne;
	public GameObject catTwo;
	public GameObject romanusPounce;
	public GameObject timePortal;
	public GameObject skipButton;

	public GameObject songOne;
	public GameObject songTwo;

	public Text convoContent;

	private Queue<string> sentences;  //data structure that allow you to only  add items to
	// end and remove from the beginning (first in first out)

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();	// create our queue from sentences

		cutsceneImageOne.gameObject.SetActive(true); // the first image appears
		cutsceneImageTwo.gameObject.SetActive(false);
		cutsceneImageThree.gameObject.SetActive(false);

		romanusOne.SetActive (true);
		romanusTwo.SetActive (false);
		catOne.SetActive (false);
		catTwo.SetActive (false);
		romanusPounce.SetActive (false);
		bossThree.SetActive (true);
		timePortal.SetActive (false);
		songOne.SetActive (true);
		songTwo.SetActive (false);
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

		if (sentences.Count == 17) 
		{
			Debug.Log ("number is even");
		}

		else if (sentences.Count == 16)
		{
			Debug.Log("number is odd");
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
			romanusPounce.SetActive (true);
			romanusOne.SetActive (false);
			skipButton.SetActive (true);
		}

		else if (sentences.Count == 12)
		{
			Debug.Log("number is even");
			romanusPounce.SetActive (false);
			romanusOne.SetActive (true);
			timePortal.SetActive (true);
		}

		else if (sentences.Count == 11)
		{
			Debug.Log("number is odd");
			romanusOne.SetActive (false);
			romanusTwo.SetActive (true);
		}

		else if (sentences.Count == 10)
		{
			Debug.Log("number is even");

			cutsceneImageOne.gameObject.SetActive(false);
			cutsceneImageTwo.gameObject.SetActive(true);
			cutsceneImageThree.gameObject.SetActive(false);

			timePortal.SetActive (false);
			bossThree.SetActive (false);
			songOne.SetActive (false);
		}

		else if (sentences.Count == 9)
		{
			Debug.Log("number is odd");
			cutsceneImageOne.gameObject.SetActive(false);
			cutsceneImageTwo.gameObject.SetActive(false);
			cutsceneImageThree.gameObject.SetActive(true);

			romanusTwo.SetActive (false);
			songTwo.SetActive (true);
		}

		else if (sentences.Count == 8)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 7)
		{
			Debug.Log("number is odd");

			cutsceneImageOne.gameObject.SetActive(false);
			cutsceneImageTwo.gameObject.SetActive(true);
			cutsceneImageThree.gameObject.SetActive(false);

			romanusTwo.SetActive (true);
			catOne.SetActive (true);
		}
			
		else if (sentences.Count == 6)
		{
			Debug.Log("number is even");

			romanusTwo.SetActive (false);
			catOne.SetActive (false);
			romanusPounce.SetActive (true);
			catTwo.SetActive (true);
		}

		else if (sentences.Count == 5)
		{
			Debug.Log("number is odd");
		}

		else if (sentences.Count == 4)
		{
			Debug.Log("number is even");
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

			romanusTwo.SetActive (true);
			catOne.SetActive (false);
			romanusPounce.SetActive (false);
			catTwo.SetActive (false);
		}

		else 
		{
			Debug.Log ("number is odd");
		}
	}

	public void EndConvo (){
		Debug.Log ("reached end of convo");
		SceneManager.LoadScene("GameScene");
	}
}
