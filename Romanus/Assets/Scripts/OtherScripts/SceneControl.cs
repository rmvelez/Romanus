using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour 
{
	// the following lines of code are used to load the various scenes within the game

	public void PlayGame() // function that loads the fourth level
	{
		SceneManager.LoadScene ("GameScene");
	}

	public void FirstLevel() // function that loads the first level
	{
		SceneManager.LoadScene ("LevelOne");
	}

	public void SecondLevel() // function that loads the second level
	{
		SceneManager.LoadScene ("LevelTwo");
	}

	public void ThirdLevel()
	{
		SceneManager.LoadScene ("LevelThree");
	}

	public void FirstCutscene() // function that loads the first cutscene
	{
		SceneManager.LoadScene ("CutsceneOne");
	}

	public void ThirdCutscene() // function that skips to the next cutscene
	{
		SceneManager.LoadScene ("CutsceneThree");
	}

	public void GameTitle()
	{
		SceneManager.LoadScene ("TitleScreen");
	}
}
