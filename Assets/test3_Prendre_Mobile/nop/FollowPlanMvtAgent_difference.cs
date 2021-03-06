using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FollowPlanMvtAgent_difference : Agent 
{
	[SerializeField]
	float differenceX ;
	[SerializeField]
	float differenceY;

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
	int actionCounter;



	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		//state.Add(currentNumberX);
		//state.Add(currentNumberY);
		//state.Add(targetNumberX);
		//state.Add(targetNumberY);
		state.Add(differenceX);
		state.Add(differenceY);
		return state;
	}

	public override void AgentStep(float[] action)
	{
		actionCounter++;
		if (text != null)
			text.text = string.Format("C:{0} \nT:{1} \n[{2}]", (int)(currentNumberX*100), (int)(targetNumberX*100), solved);

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

		objectAgent.position = new Vector3 (currentNumberX * 5f, currentNumberY * 5f, 0f);

		float newDifferenceX = Mathf.Abs(targetNumberX - currentNumberX);
		float newDifferenceY = Mathf.Abs(targetNumberY - currentNumberY);
		if (newDifferenceX <= 0.2f && newDifferenceY <= 0.2f) {//on a atteint le cube
			solved++;
			reward = 10;
			done = true;
			return;
		} else if (currentNumberX < -1.2f || currentNumberX > 1.2f || currentNumberY < -1.2f || currentNumberY > 1.2f) {//on est sortit
			reward = -1;
			done = true;
			return;
		} //else {
			if (differenceY-newDifferenceY>0)				reward = 0.001f;
			else if (differenceY-newDifferenceY<=0)			reward = -0.001f;

			if (differenceX-newDifferenceX>0)				reward += 0.001f;
			else if (differenceX-newDifferenceX<=0)			reward += -0.001f;
			//moveTarget ();
		//}
		differenceX = newDifferenceX;
		differenceY = newDifferenceY;
	}

	void moveTarget (){
		if (actionCounter % 50 != 0)
			return;
		
		if (targetNumberX>0.8)
			targetNumberX += UnityEngine.Random.Range(-0.5f, 0.1f);
		else if (targetNumberX<-0.8)
			targetNumberX += UnityEngine.Random.Range(-0.1f, 0.5f);
		else
			targetNumberX += UnityEngine.Random.Range(-0.5f, 0.5f);

		if (targetNumberY>0.8)
			targetNumberY += UnityEngine.Random.Range(-0.5f, 0.1f);
		else if (targetNumberY<-0.8)
			targetNumberY += UnityEngine.Random.Range(-0.1f, 0.5f);
		else
			targetNumberY += UnityEngine.Random.Range(-0.5f, 0.5f);
		
		objectTarget.position = new Vector3 (targetNumberX * 5f, targetNumberY * 5f, 0f);
	}

	public override void AgentReset()
	{
		targetNumberX = UnityEngine.Random.Range(-1f, 1f);
		targetNumberY = UnityEngine.Random.Range(-1f, 1f);
		objectTarget.position = new Vector3 (targetNumberX * 5f, targetNumberY * 5f, 0f);
		currentNumberX = 0f;
		currentNumberY = 0f;
		differenceX = Mathf.Abs(targetNumberX - currentNumberX);
		differenceY = Mathf.Abs(targetNumberY - currentNumberY);
	}
}

