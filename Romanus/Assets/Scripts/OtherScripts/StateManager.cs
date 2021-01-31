using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
	public enum GateState {LevelState, PauseState, LoseState}
	public GateState currentGameState;

	public GameObject Level;
	public GameObject Pause;
	public GameObject Lose;

	public bool isPaused;
	public GameObject player;
	private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
		playerHealth = player.GetComponent<PlayerHealth> ();

        currentGameState = GateState.LevelState;
        ShowScreen(Level);
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.P))
    	{
    		if(isPaused)
    		{
    			isPaused = false;
				currentGameState = GateState.LevelState;
				ShowScreen(Level);
    		} 

			else
    		{
    			isPaused = true;
				currentGameState = GateState.PauseState;
				ShowScreen (Pause);
    		}
    	}

		if (playerHealth.isDead == true) 
		{
			currentGameState = GateState.LoseState;
			ShowScreen (Lose);
		}
    }

    private void ShowScreen (GameObject gameObjectToShow) 
	{
    	Level.SetActive(false);
    	Pause.SetActive(false);
		Lose.SetActive (false);

    	gameObjectToShow.SetActive(true);
    }
}
