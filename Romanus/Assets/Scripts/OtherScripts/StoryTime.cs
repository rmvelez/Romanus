using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTime : MonoBehaviour {

    public Text storyText1; // functions that load the story text
    public Text storyText2;

    public Button nextButton; // the button that loads the fourth paragraph
    public Button beginButton; // the button that starts the game

	// Use this for initialization
	void Start () 
	{
		// the following block of code displays the first paragraph 
		storyText1.gameObject.SetActive (true); 
		storyText2.gameObject.SetActive (false);
        nextButton.gameObject.SetActive(true);
        beginButton.gameObject.SetActive (false);
	}

    // this last function loads final paragraph and
    // the begin button, which will allow players to play the foruth level
    public void ParagraphFour()
    {
		storyText1.gameObject.SetActive (false); 
		storyText2.gameObject.SetActive (true);
		nextButton.gameObject.SetActive (false);
		beginButton.gameObject.SetActive (true);
    }
}
