﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneFour_StartConvo : MonoBehaviour
{
	CutsceneFour_DialogTrigger dialogTrigger;

	public Button StartButton;

	public Button continueButton;

	// Use this for initialization
	void Start () {
		dialogTrigger = GetComponent<CutsceneFour_DialogTrigger> ();
		continueButton.gameObject.SetActive(false);
	}


	public void StartConverse () {
		dialogTrigger.TriggerDialog ();
		StartButton.gameObject.SetActive(false);
		continueButton.gameObject.SetActive(true);
	}
}