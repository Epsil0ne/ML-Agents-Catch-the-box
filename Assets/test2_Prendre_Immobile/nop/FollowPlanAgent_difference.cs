using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowPlanAgent_difference : Agent
{
	[SerializeField]
	private float differenceX;
	[SerializeField]
	private float differenceY;


	private float currentNumberX;
	private float targetNumberX;
	private float currentNumberY;
	private float targetNumberY;
	[SerializeField]
	private Text text;
	[SerializeField]
	private Transform objectAgent;
	[SerializeField]
	private Transform objectTarget;

	int solved;

	public override List<float> CollectState ()
	{

		List<float> state = new List<float> ();
//		state.Add(currentNumberX);
//		state.Add(currentNumberY);
//		state.Add(targetNumberX);
//		state.Add(targetNumberY);
		state.Add (differenceX);
		state.Add (differenceY);

		return state;
	}

	public override void AgentStep (float[] action)
	{
		
		
		if (text != null)
			text.text = string.Format ("C:{0} \nT:{1} \n[{2}]", (int)(currentNumberX * 100), (int)(targetNumberX * 100), solved);

		switch ((int)action [0]) {
		case 0:
			currentNumberX -= 0.05f;
			break;
		case 1:
			currentNumberX += 0.05f;
			break;
		case 2:
			currentNumberY -= 0.05f;
			break;
		case 3:
			currentNumberY += 0.05f;
			break;
		default:
			return;
		}

		objectAgent.position = new Vector3 (currentNumberX * 5f, currentNumberY * 5f, 0f);

		float newDifferenceX = Mathf.Abs (targetNumberX - currentNumberX);
		float newDifferenceY = Mathf.Abs (targetNumberY - currentNumberY);

		float newDistance = Mathf.Pow (newDifferenceX, 2) + Mathf.Pow (newDifferenceY, 2);
		newDistance = Mathf.Round(newDistance*100)/100;
		float distance = Mathf.Pow (differenceX, 2) + Mathf.Pow (differenceY, 2);
		distance = Mathf.Round(distance*100)/100;

		if (newDifferenceX <= 0.2f && newDifferenceY <= 0.2f) {
			solved++;
			reward = 1;
			done = true;
			//return;
		} else if (currentNumberX < -1.2f || currentNumberX > 1.2f || currentNumberY < -1.2f || currentNumberY > 1.2f) {
			reward = -1f;
			done = true;
			//return;
		} else {
			if (distance > newDistance) {
			}//			reward = 0.001f;
			else 				reward = -0.0001f;
			//else if (differenceY <  newDifferenceY)	reward -= 0.0001f;

			//if      (differenceX >  newDifferenceX)	reward += 0.0001f;
			//else if (differenceX <  newDifferenceX)	reward -= 0.0001f;
		}
//		print(reward);
		//print(distance +"   "+newDistance +"   "+reward);
		differenceX = newDifferenceX;
		differenceY = newDifferenceY;

	}





	public override void AgentReset ()
	{
		
		//targetNumberX = UnityEngine.Random.Range (-1f, 1f);
		targetNumberX = Mathf.Round(UnityEngine.Random.Range (-1f, 1f)*100)/100;
		targetNumberY = Mathf.Round(UnityEngine.Random.Range (-1f, 1f)*100)/100;
		//targetNumberY = UnityEngine.Random.Range (-1f, 1f);
		objectTarget.position = new Vector3 (targetNumberX * 5f, targetNumberY * 5f, 0f);
		currentNumberX = 0f;
		currentNumberY = 0f;
		differenceX = Mathf.Abs (targetNumberX - currentNumberX);
		differenceY = Mathf.Abs (targetNumberY - currentNumberY);
	}
}

