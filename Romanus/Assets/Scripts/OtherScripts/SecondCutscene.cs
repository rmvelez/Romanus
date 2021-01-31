using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCutscene : MonoBehaviour
{
	public Text storyText1; // slots for the text fields that tell the game's story
	public Text storyText2;
	public Text storyText3;

	public Button firstNextButton; // the button that loads the second paragraph
	public Button secondNextButton; // the button that loads the third paragraph
	public Button beginButton; // the button that starts the game

    // Start is called before the first frame update
    void Start()
    {
		storyText1.gameObject.SetActive (true);
		storyText2.gameObject.SetActive (false);
		storyText3.gameObject.SetActive (false);
		firstNextButton.gameObject.SetActive (true);
		secondNextButton.gameObject.SetActive (false);
		beginButton.gameObject.SetActive (false);
    }

	// this fucntion loads the second paragraph of this scene
	public void SecondParagraph()
	{
		storyText1.gameObject.SetActive (false);
		storyText2.gameObject.SetActive (true);
		storyText3.gameObject.SetActive (false);
		firstNextButton.gameObject.SetActive (false);
		secondNextButton.gameObject.SetActive (true);
		beginButton.gameObject.SetActive (false);
	}

	// this function loads the third paragraph, as well as the button that loads the second level
	public void ThirdParagraph()
	{
		storyText1.gameObject.SetActive (false);
		storyText2.gameObject.SetActive (false);
		storyText3.gameObject.SetActive (true);
		firstNextButton.gameObject.SetActive (false);
		secondNextButton.gameObject.SetActive (false);
		beginButton.gameObject.SetActive (true);
	}
}
