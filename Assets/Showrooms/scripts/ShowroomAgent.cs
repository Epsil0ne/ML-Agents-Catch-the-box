using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowroomAgent : Agent 
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

	public bool isTargetMoving =false;
	public bool isInverted =false;
	public bool updateTargetPosition =true;
	public bool appearRandom =false;

	public string text1 = "V: ";
	public string text2 = "    X: ";

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
		if (text != null) text.text = string.Format(text1+solved+text2+ failed);
		//text.text = string.Format("C:{0} \nT:{1} \n[{2}]", (int)(currentNumberX*100), (int)(targetNumberX*100), solved);
		int inversion = 1;
		if(isInverted)inversion = -1;
		switch ((int)action[0])
		{
		case 0:
			currentNumberX += -0.01f*inversion;
			break;
		case 1:
			currentNumberX += 0.01f*inversion;
			break;
		case 2:
			currentNumberY += -0.01f*inversion;
			break;
		case 3:
			currentNumberY += 0.01f*inversion;
			break;
		default:
			return;
		}

		objectAgent.localPosition = new Vector3 (currentNumberX * 5f, currentNumberY * 5f, 0f);

		if ((Mathf.Abs(targetNumberX - currentNumberX) <= 0.2f) && (Mathf.Abs(targetNumberY - currentNumberY) <= 0.2f)) {//on a atteint le cube
			solved++;
			reward = -1;
			done = true;

		} else if (currentNumberX < -1.2f || currentNumberX > 1.2f || currentNumberY < -1.2f || currentNumberY > 1.2f) {//on est sortit
			failed++;
			reward = -1;
			 done = true;

		} else {
			if (isTargetMoving)
				moveTarget ();
			else {
				targetNumberX  = objectTarget.localPosition.x*0.2f;
				targetNumberY  = objectTarget.localPosition.y*0.2f;
			}
		}
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

		if(updateTargetPosition)
		objectTarget.localPosition = new Vector3 (targetNumberX * 5f, targetNumberY * 5f, 0f);

	}

	public override void AgentReset()
	{
		targetNumberX = UnityEngine.Random.Range(-1f, 1f);
		targetNumberY = UnityEngine.Random.Range(-1f, 1f);
		objectTarget.localPosition = new Vector3 (targetNumberX * 5f, targetNumberY * 5f, 0f);
		if (appearRandom) {
			currentNumberX = UnityEngine.Random.Range(-1f, 1f);
			currentNumberY = UnityEngine.Random.Range(-1f, 1f);  
		} else {
			currentNumberX = 0f;
			currentNumberY = 0f;  
		}

	}
}

