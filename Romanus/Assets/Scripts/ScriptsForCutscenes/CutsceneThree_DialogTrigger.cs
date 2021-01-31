using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneThree_DialogTrigger : MonoBehaviour
{
	public Dialog dialog; //connect to Dialog.cs

	public void TriggerDialog(){

		FindObjectOfType <CutsceneThree_DialogManager>().StartDialog(dialog);
	}
}

