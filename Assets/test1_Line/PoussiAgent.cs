using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoussiAgent : Agent 
{
	[SerializeField]
	private float currentNumber;
	[SerializeField]
	private float targetNumber;
	[SerializeField]
	private Text text;
	[SerializeField]
	private Transform cube;
	[SerializeField]
	private Transform sphere;

	int solved;

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		state.Add(currentNumber);
		state.Add(targetNumber);
		return state;
	}

	public override void AgentStep(float[] action)
	{
		if (text != null)
			text.text = string.Format("C:{0} \nT:{1} \n[{2}]", (int)(currentNumber*100), (int)(targetNumber*100), solved);

		switch ((int)action[0])
		{
		case 0:
			currentNumber -= 0.01f;
			break;
		case 1:
			currentNumber += 0.01f;
			break;
		default:
			return;
		}

		cube.position = new Vector3 (currentNumber * 5f, 0f, 0f);

		if (currentNumber < -1.2f || currentNumber > 1.2f)
		{
			reward = -1f;
			done = true;
			return;
		}

		float difference = Mathf.Abs(targetNumber - currentNumber);
		if (difference <= 0.01f)
		{
			solved++;
			reward = 1;
			done = true;
			return;
		}
	}

	public override void AgentReset()
	{
		targetNumber = UnityEngine.Random.Range(-1f, 1f);
		sphere.position = new Vector3 (targetNumber * 5f, 0f, 0f);
		currentNumber = 0f;
	}
}