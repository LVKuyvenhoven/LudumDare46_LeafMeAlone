using UnityEngine;
using System.Collections;
using TMPro;

public class sun : MonoBehaviour {
	public float speed;
	float time;
	float Curtime;
	public float hour;

	public Material skybox;
	float Value;

	public bool Twaalf_Snachts;
	public bool Twaalf_SMiddags;

	public bool Zes_Avond;
	public bool Zes_Ochtend;

	public TextMeshProUGUI timetxt;
	

	private void Start()
	{
		if (Twaalf_Snachts)
		{
			transform.position = new Vector3(0,-500,0);
			Curtime = 360;
		}
		else if (Twaalf_SMiddags)
		{
			transform.position = new Vector3(0, 500, 0);
			Curtime = 180;
		}
		else if(Zes_Avond)
		{
			transform.position = new Vector3(0, 0, 500);
			Curtime = 270;
		}
		else if (Zes_Ochtend)
		{
			transform.position = new Vector3(0, 0, -500);
			Curtime = 90;
		}
		else
		{
			transform.position = new Vector3(0, 500, 0);
			Curtime = 180;
		}

		transform.LookAt(Vector3.zero);
	}

	// Update is called once per frame
	void Update () 
	{
		if(Curtime >= 360)
		{
			Curtime = 0;
		}

		if(Curtime <= 360 && Curtime >= 270)
		{
			if(Value < 1)
			{
				Value = Value + 0.0005f;
			}
			skybox.SetFloat("_Blend", Value);
		}

		if (Curtime >= 90 && Curtime <= 270)
		{
			if (Value < 1)
			{
				Value = Value - 0.0005f;
			}
			skybox.SetFloat("_Blend", Value);
		}



		time = speed * Time.deltaTime;
		Curtime = Curtime + time;
		transform.RotateAround(Vector3.zero, Vector3.right, time);
		transform.LookAt(Vector3.zero);
		hour = Curtime / 360.0f * 24.0f;
		int hours = (int)hour;
		timetxt.text = "" + hours;
	}
}
