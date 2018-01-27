using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EscapePlanAgent : Agent 
{
	[SerializeField]
	private float currentNumberX;
	[SerializeField]
	private float targetNumberX;
	[SerializeField]
	private float currentNumberY;
	[SerializeField]
	private float targetNumberY;

	[SerializeField]
	private Text text;
	[SerializeField]
	private Transform objectAgent;
	[SerializeField]
	private Transform objectTarget;

	int solved;
	int failed;
	int actionCounter;



	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		state.Add(currentNumberX);
		state.Add(currentNumberY);
		state.Add(targetNumberX);
		state.Add(targetNumberY);
	
		return state;
	}

	public override void AgentStep(float[] action)
	{
		actionCounter++;
		if (text != null) text.text = string.Format("V: {0}    X: {1}", solved, failed);
			//text.text = string.Format("C:{0} \nT:{1} \n[{2}]", (int)(currentNumberX*100), (int)(targetNumberX*100), solved);

		switch ((int)action[0])
		{
		case 0:
			currentNumberX -= 0.01f;
			break;
		case 1:
			currentNumberX += 0.01f;
			break;
		case 2:
			currentNumberY -= 0.01f;
			break;
		case 3:
			currentNumberY += 0.01f;
			break;
		default:
			return;
		}

		objectAgent.localPosition = new Vector3 (currentNumberX * 5f, currentNumberY * 5f, 0f);

		float newDifferenceX = Mathf.Abs(targetNumberX - currentNumberX);
		float newDifferenceY = Mathf.Abs(targetNumberY - currentNumberY);
		if (newDifferenceX <= 0.2f && newDifferenceY <= 0.2f) {//on a atteint le cube
			solved++;
			reward = -1;
			done = true;
			return;
		} else if (currentNumberX < -1.2f || currentNumberX > 1.2f || currentNumberY < -1.2f || currentNumberY > 1.2f) {//on est sortit
			failed++;
			reward = -1;
			done = true;
			return;
		} else {
			//reward = 0.01f;

		}
	}
		

	public override void AgentReset()
	{
		targetNumberX = UnityEngine.Random.Range(-1f, 1f);
		targetNumberY = UnityEngine.Random.Range(-1f, 1f);
		objectTarget.localPosition = new Vector3 (targetNumberX * 5f, targetNumberY * 5f, 0f);
		currentNumberX = 0f;
		currentNumberY = 0f;  
	}
}

