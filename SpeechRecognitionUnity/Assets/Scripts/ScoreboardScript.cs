using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardScript : MonoBehaviour {

	// Image variables
	public Image scoreboardQ1;
	public Image scoreboardQ2;
	public Image scoreboardQ3;
	public Image scoreboardQ4;
	public Image scoreboardQ5;
	public Image scoreboardQ6;
	public Image scoreboardQ7;
	public Image scoreboardQ8;
	public Image scoreboardQ9;
	public Image scoreboardQ10;
	public Image scoreboardQ11;
	public Image scoreboardQ12;
	public Image scoreboardQ13;
	public Image scoreboardQ14;
	public Image scoreboardQ15;

	void Awake()
	{
		
	}

	// Update is called once per frame
	public IEnumerator showScoreboard(float timeToShow)
	{
		if(LoadQuestions.questionLevel == 0)
		{
			scoreboardQ1.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ1.enabled=false;
		}
		if(LoadQuestions.questionLevel == 1)
		{
			scoreboardQ2.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ2.enabled=false;
		}
		if(LoadQuestions.questionLevel == 2)
		{
			scoreboardQ3.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ3.enabled=false;
		}
		if(LoadQuestions.questionLevel == 3)
		{
			scoreboardQ4.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ4.enabled=false;
		}
		if(LoadQuestions.questionLevel == 4)
		{
			scoreboardQ5.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ5.enabled=false;
		}
		if(LoadQuestions.questionLevel == 5)
		{
			scoreboardQ6.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ6.enabled=false;
		}
		if(LoadQuestions.questionLevel == 6)
		{
			scoreboardQ7.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ7.enabled=false;
		}
		if(LoadQuestions.questionLevel == 7)
		{
			scoreboardQ8.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ8.enabled=false;
		}
		if(LoadQuestions.questionLevel == 8)
		{
			scoreboardQ9.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ9.enabled=false;
		}
		if(LoadQuestions.questionLevel == 9)
		{
			scoreboardQ10.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ10.enabled=false;
		}
		if(LoadQuestions.questionLevel == 10)
		{
			scoreboardQ11.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ11.enabled=false;
		}
		if(LoadQuestions.questionLevel == 11)
		{
			scoreboardQ12.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ12.enabled=false;
		}
		if(LoadQuestions.questionLevel == 12)
		{
			scoreboardQ13.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ13.enabled=false;
		}
		if(LoadQuestions.questionLevel == 13)
		{
			scoreboardQ14.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ14.enabled=false;
		}
		if(LoadQuestions.questionLevel == 14)
		{
			scoreboardQ15.enabled=true;
			yield return new WaitForSeconds(timeToShow);
			scoreboardQ15.enabled=false;
		}
	} 

	
}
