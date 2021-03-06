using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowroomPlayer  : Agent 
{

	private float currentNumberX;
	private float currentNumberY;

	[SerializeField]
	private Transform objectAgent;
	public bool appearRandom=false;


	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		state.Add(currentNumberX);
		state.Add(currentNumberY);
		return state;
	}

	public override void AgentStep(float[] action)
	{
		currentNumberX = objectAgent.localPosition.x/5;
		currentNumberY = objectAgent.localPosition.y/5;

		switch ((int)action[0])
		{
		case 0:
			currentNumberX += -0.01f;
			break;
		case 1:
			currentNumberX += 0.01f;
			break;
		case 2:
			currentNumberY += -0.01f;
			break;
		case 3:
			currentNumberY += 0.01f;
			break;
		default:
			return;
		}



		 if (currentNumberX < -1.2f || currentNumberX > 1.2f || currentNumberY < -1.2f || currentNumberY > 1.2f) {
			done = true;
			currentNumberX = 0;
			currentNumberY = 0;
		} 
		objectAgent.localPosition = new Vector3 (currentNumberX * 5f, currentNumberY * 5f, 0f);
	}



	public override void AgentReset()
	{
		if (appearRandom) {
			currentNumberX = UnityEngine.Random.Range(-1f, 1f);
			currentNumberY = UnityEngine.Random.Range(-1f, 1f);  
		} else {
			currentNumberX = 0f;
			currentNumberY = 0f;  
		}

	}
}



