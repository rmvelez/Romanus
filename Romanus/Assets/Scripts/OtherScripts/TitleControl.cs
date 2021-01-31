using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControl : MonoBehaviour
{
	public enum GameState {TitleState, LearnState, CreditState};
	public GameState currentGameState;

	public GameObject Title;
	public GameObject Learn;
	public GameObject Credits;

    // Start is called before the first frame update
    void Start()
    {
		currentGameState = GameState.TitleState;
		ShowScreen (Title);
    }

	public void ToTheTitle()
	{
		currentGameState = GameState.TitleState;
		ShowScreen (Title);
	}

	public void HowToPlay()
	{
		currentGameState = GameState.LearnState;
		ShowScreen (Learn);
	}

	public void ShowCredits()
	{
		currentGameState = GameState.CreditState;
		ShowScreen (Credits);
	}

	private void ShowScreen (GameObject gameObjectToShow)
	{
		Title.SetActive (false);
		Learn.SetActive (false);
		Credits.SetActive (false);

		gameObjectToShow.SetActive (true);
	}
}
