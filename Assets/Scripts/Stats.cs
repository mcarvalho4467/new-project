using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stats 
{
	[SerializeField]
	private HealthBar hb;
	[SerializeField]
	private float maxV;
	[SerializeField]
	private float currentV;

	public float CurrentV
	{
		get
		{
			return currentV;
		}

		set 
		{
			this.currentV = value;
			hb.Value = currentV;
		}
	}

	public float MaxV
	{
		get
		{
			return maxV;
		}

		set 
		{
			this.maxV = value;
			hb.maxValue = maxV;
		}
	}

	public void  Initialize ()
	{
		this.MaxV = maxV;
		this.CurrentV = currentV;
	}
}
