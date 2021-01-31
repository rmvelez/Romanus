using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conclusion_DialogTrigger : MonoBehaviour
{
	public Dialog dialog; //connect to Dialog.cs

	public void TriggerDialog(){

		FindObjectOfType <Conclusion_DialogManager>().StartDialog(dialog);
	}
}


