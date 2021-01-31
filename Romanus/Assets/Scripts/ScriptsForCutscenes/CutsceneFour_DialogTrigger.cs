using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFour_DialogTrigger : MonoBehaviour
{
	public Dialog dialog; //connect to Dialog.cs

	public void TriggerDialog(){

		FindObjectOfType <CutsceneFour_DialogManager>().StartDialog(dialog);
	}
}

