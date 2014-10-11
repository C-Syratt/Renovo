using UnityEngine;
using System.Collections;

public class DialPuzzle : MonoBehaviour 
{
	public GameObject[] dialList;
	public GameObject selectedDial;
	public float rotSpeed;
	public int dialNum = 0;

	public Color selectedColor;
	public Color originalColor;

	public void Start()
	{
		selectedDial = dialList[0];
		originalColor = dialList[1].renderer.material.color;
	}

	public void Update()
	{
		if (Input.GetKey (KeyCode.LeftArrow))
		{RotateLeft ();}

		if (Input.GetKey (KeyCode.RightArrow))
		{RotateRight ();}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{ChangeUp ();}

		if (Input.GetKeyDown (KeyCode.DownArrow))
		{ChangeDown ();}

		selectedDial.renderer.material.color = selectedColor;

		for (int i = 0; i < dialList.Length; i++) 
		{
			if (i != dialNum)
			{
				dialList[i].renderer.material.color = originalColor;
			}
		}
	}

	void RotateLeft()
	{
		selectedDial.gameObject.transform.Rotate (new Vector3 (0, -1, 0) * rotSpeed);
	}

	void RotateRight()
	{
		selectedDial.gameObject.transform.Rotate (new Vector3 (0, 1, 0) * rotSpeed);
	}

	void ChangeUp()
	{
		if (selectedDial == dialList[2])
		{
			selectedDial = dialList [0];	
			dialNum = 0;
		}
		else
		{
			selectedDial = dialList [dialNum + 1];
			dialNum++;
		}
	}

	void ChangeDown()
	{
		if (selectedDial == dialList[0])
		{
			selectedDial = dialList [2];	
			dialNum = 2;
		}
		else
		{
			selectedDial = dialList [dialNum - 1];
			dialNum--;
		}
	}

}
