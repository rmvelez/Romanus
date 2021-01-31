using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFive_DialogTrigger : MonoBehaviour
{
	public Dialog dialog; //connect to Dialog.cs

	public void TriggerDialog(){

		FindObjectOfType <CutsceneFive_DialogManager>().StartDialog(dialog);
	}
}

