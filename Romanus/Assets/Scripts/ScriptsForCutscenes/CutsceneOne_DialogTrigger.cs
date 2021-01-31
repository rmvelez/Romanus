using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOne_DialogTrigger : MonoBehaviour
{
	public Dialog dialog; //connect to Dialog.cs

	public void TriggerDialog(){

		FindObjectOfType <CutsceneOne_DialogManager>().StartDialog(dialog);
	}
}
