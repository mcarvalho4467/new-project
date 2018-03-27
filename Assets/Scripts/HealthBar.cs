using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public float maxValue { get; set;  }

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;


	public float Value
	{
		set 
		{
			fillAmount = Map (value, 0, maxValue, 0, 1);
		}
	}

	void Update () 
	{
		HandleBar ();
	}

	public void HandleBar ()
	{
		if (fillAmount != content.fillAmount) 
		{
			content.fillAmount = fillAmount;
		}
	}

	public float Map (float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
