using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTwo_DialogTrigger : MonoBehaviour
{
	public Dialog dialog; //connect to Dialog.cs

	public void TriggerDialog(){

		FindObjectOfType <CutsceneTwo_DialogManager>().StartDialog(dialog);
	}
}

