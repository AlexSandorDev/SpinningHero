using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputHandler
{
	private bool leftInput = false;
	private bool rightInput = false;
	private bool mobile = false;
	private bool pc = false;


	private void Update()
	{

		if (Input.touchCount > 0) mobile = true;
		if (Input.anyKeyDown) pc = true;

		if (mobile) MobileInput();
		if (pc) PCInput();

		SetYInput(1);

		if (rightInput && !leftInput)
		{
			SetXInput(1);
			return;
		}

		if (leftInput && !rightInput)
		{
			SetXInput(-1);
			return;
		}

		SetXInput(0);

		if (rightInput && leftInput)
		{
			SetYInput(1);
			return;
		}

		SetYInput(-1);
	}

	void PCInput()
	{
		if (Input.GetKeyDown(KeyCode.A)) leftInput = true;
		if (Input.GetKeyDown(KeyCode.D)) rightInput = true;

		if (Input.GetKeyUp(KeyCode.A)) leftInput = false;
		if (Input.GetKeyUp(KeyCode.D)) rightInput = false;
	}

	void MobileInput()
	{
		var _isLeftTouch = false;
		var _isRightTouch = false;

		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).position.x > Screen.width/2)
				_isRightTouch = true;
			else
				_isLeftTouch = true;
		}

		leftInput = _isLeftTouch;
		rightInput = _isRightTouch;
	}
}
