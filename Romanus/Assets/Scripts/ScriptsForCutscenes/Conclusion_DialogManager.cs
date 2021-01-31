using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Conclusion_DialogManager : MonoBehaviour
{
	public Image cutsceneImageOne;
	public Image cutsceneImageTwo;

	public GameObject romanusOne;
	public GameObject romanusTwo;
	public GameObject romanusThree;
	public GameObject romanusFour;
	public GameObject bossFour;
	public GameObject timePortal;
	public GameObject mysteryWoman;
	public GameObject mysteryExplosion;
	public GameObject songOne;
	public GameObject songTwo;
	public GameObject skipButton;

	public Text convoContent;

	private Queue<string> sentences;  //data structure that allow you to only  add items to
	// end and remove from the beginning (first in first out)

	// Use this for initialization
	void Start () 
	{
		sentences = new Queue<string> ();	// create our queue from sentences

		cutsceneImageOne.gameObject.SetActive (true);
		cutsceneImageTwo.gameObject.SetActive (false);

		romanusOne.SetActive (true);
		romanusTwo.SetActive (false);
		romanusThree.SetActive (false);
		romanusFour.SetActive (false);
		bossFour.SetActive (true);
		timePortal.SetActive (false);
		mysteryWoman.SetActive (false);
		mysteryExplosion.SetActive (false);
		songOne.SetActive (true);
		songTwo.SetActive (false);
		skipButton.SetActive (false);
	}

	public void StartDialog(Dialog dialog)
	{  //method called at start of a conversation
		Debug.Log ("talk to " + dialog.name); // check to make sure this works

		// first need to clear out any previous conversation that might linger in sentences array
		sentences.Clear();

		// then loop through the array and line up each sentence currently in it to prepare 
		foreach(string sentence in dialog.sentences)
		{
			sentences.Enqueue (sentence); // put each in the queue
		}
		// then call a method to actually display it

		DisplayNextSentence ();
	}

	public void DisplayNextSentence ()
	{
		// first check to see if we are at the end of convo and if so call end method

		if (sentences.Count == 0) 
		{ // if array is empty
			EndConvo (); // call end method
			return;		// leave the function
		}

		string sentence = sentences.Dequeue ();  // otherwise pull sentence out of the queue
		Debug.Log(sentences.Count);
		convoContent.text = sentence;


        ///Sentences counts down from 19 down to 0
		if (sentences.Count == 19) 
		{
			Debug.Log ("number is even");
		} 

		else if (sentences.Count == 18) 
		{
			Debug.Log ("number is odd");
		}

		else if (sentences.Count == 17)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 16)
		{
			Debug.Log("number is odd");
		}

		else if (sentences.Count == 15)
		{
			Debug.Log("number is even");
			romanusOne.SetActive (false);
			romanusTwo.SetActive (true);
			skipButton.SetActive (true);
		}

		else if (sentences.Count == 14)
		{
			Debug.Log("number is even");
			romanusOne.SetActive (true);
			romanusTwo.SetActive (false);
		}

		else if (sentences.Count == 13)
		{
			Debug.Log("number is odd");
		}

		else if (sentences.Count == 12)
		{
			Debug.Log("number is even");
			romanusOne.SetActive (false);
			romanusThree.SetActive (true);
			timePortal.SetActive (true);
		}

		else if (sentences.Count == 11)
		{
			Debug.Log("number is odd");
			romanusThree.SetActive (false);
			romanusFour.SetActive (true);
		}

		else if (sentences.Count == 10)
		{
			Debug.Log("number is even");
			timePortal.SetActive (false);
			romanusFour.SetActive (false);
		}

		else if (sentences.Count == 9) ///When the sentence count hits 9
		{
			Debug.Log("number is odd");

			cutsceneImageOne.gameObject.SetActive (false);
			cutsceneImageTwo.gameObject.SetActive (true);
			romanusFour.SetActive (true);
			romanusThree.SetActive (false);
			bossFour.SetActive (false);
			songOne.SetActive (false);
			songTwo.SetActive (true);
		}

		else if (sentences.Count == 8)
		{
			Debug.Log("number is odd");
			mysteryWoman.SetActive (true);
		}

		else if (sentences.Count == 7)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 6)
		{
			Debug.Log("number is even");
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
			Debug.Log("number is odd");
		}

		else if (sentences.Count == 2)
		{
			Debug.Log("number is even");
		}

		else if (sentences.Count == 1)
		{
			Debug.Log("number is even");
			mysteryExplosion.SetActive (true);
			mysteryWoman.SetActive (false);
			romanusFour.SetActive (false);
		}

		else if (sentences.Count == 0)
		{
			Debug.Log ("number is odd");
			mysteryExplosion.SetActive (false);
		}

		else
		{
			Debug.Log("number is even");
		}
	}

	public void EndConvo ()
	{
		Debug.Log ("reached end of convo");
		SceneManager.LoadScene("TitleScreen");
	}
}
