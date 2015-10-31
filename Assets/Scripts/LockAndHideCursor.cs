using UnityEngine;
using System.Collections;

public class LockAndHideCursor : MonoBehaviour {


	bool isLocked;

	// Use this for initialization
	void Start () {
		LockHideCursor (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("e")) {
			LockHideCursor(!isLocked);
		}
	
	}



	public void LockHideCursor(bool mode)
	{

		this.isLocked = mode;


		if (mode)
		{
			UnityClipCursor.StartClipping();
			//Default Unity Method:
			//UnityEngine.Cursor.visible = false;
			//UnityEngine.Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			UnityClipCursor.StopClipping();
			//Default Unity Method:
			//UnityEngine.Cursor.visible = true;
			//UnityEngine.Cursor.lockState = CursorLockMode.None;
		}
	}

}
