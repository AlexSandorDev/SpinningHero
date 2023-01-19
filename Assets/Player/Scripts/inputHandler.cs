using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class InputHandler : MonoBehaviour
{
	protected TopDownCarController movementController;

	public Vector2 inputVector { get; protected set; }
	protected SpringHandler springHandler;
	private void Start()
	{
		springHandler = new SpringHandler(GetComponents<SpringComponent>().Where(x => x.Data.SpringTag != SpringEnum.overrideE).ToList());

		movementController = GetComponent<TopDownCarController>();
	}

	protected void SetYInput(float y)
	{
		inputVector = new Vector2(inputVector.x, y);

		movementController.SetInput(inputVector.x, inputVector.y);
	}

	protected void SetXInput(float x)
	{
		inputVector = new Vector2(x, inputVector.y);

		movementController.SetInput(inputVector.x, inputVector.y);
	}
}