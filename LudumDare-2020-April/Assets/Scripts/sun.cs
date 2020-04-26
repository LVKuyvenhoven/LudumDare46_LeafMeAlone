using UnityEngine;
using System.Collections;
using TMPro;

public class sun : MonoBehaviour {
	public float speed;
	float time;
	float Curtime;
	public static float hour;

	public Material skybox;
	public float Value;

	public bool Twaalf_Snachts;
	public bool Twaalf_SMiddags;

	public bool Zes_Avond;
	public bool Zes_Ochtend;

	public GameObject test;

	public GameObject outside1;
	public GameObject outside2;
	public GameObject outside3;
	public GameObject outside4;
	public GameObject outside5;
	public GameObject outside6;
	public GameObject outside7;
	public GameObject outside8;
	public GameObject outside9;

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

	void Update () 
	{
		updateLight();

		if (Curtime >= 360)
		{
			Curtime = 0;
		}

		if(Curtime <= 360 && Curtime >= 270)
		{
			if(Value < 1)
			{
				Value = Value + 0.05f * Time.deltaTime;
			}
			skybox.SetFloat("_Blend", Value);
		}

		if (Curtime >= 90 && Curtime <= 270)
		{
			if (Value > 0)
			{
				Value = Value - 0.05f * Time.deltaTime;
			}
			skybox.SetFloat("_Blend", Value);
		}

		if (Curtime >= 75 && Curtime <= 240)
		{
			if (this.gameObject.GetComponent<Light>().intensity < 1.5f)
			{
				this.gameObject.GetComponent<Light>().intensity = this.gameObject.GetComponent<Light>().intensity + 0.05f * Time.deltaTime;
				
			}

			if (outside1.GetComponent<Light>().intensity > 0)
			{
				outside1.GetComponent<Light>().intensity = outside1.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside2.GetComponent<Light>().intensity = outside2.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside3.GetComponent<Light>().intensity = outside3.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside4.GetComponent<Light>().intensity = outside4.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside5.GetComponent<Light>().intensity = outside5.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside6.GetComponent<Light>().intensity = outside6.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside7.GetComponent<Light>().intensity = outside7.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside8.GetComponent<Light>().intensity = outside8.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
				outside9.GetComponent<Light>().intensity = outside9.GetComponent<Light>().intensity - 0.05f * Time.deltaTime;
			}
		}
		else if (Curtime >= 240 || Curtime <= 75)
		{
			if (this.gameObject.GetComponent<Light>().intensity > 0)
			{
				this.gameObject.GetComponent<Light>().intensity = this.gameObject.GetComponent<Light>().intensity - 0.125f * Time.deltaTime;
				
			}

			if (outside1.GetComponent<Light>().intensity < 1)
			{
				outside1.GetComponent<Light>().intensity = outside1.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside2.GetComponent<Light>().intensity = outside2.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside3.GetComponent<Light>().intensity = outside3.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside4.GetComponent<Light>().intensity = outside4.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside5.GetComponent<Light>().intensity = outside5.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside6.GetComponent<Light>().intensity = outside6.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside7.GetComponent<Light>().intensity = outside7.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside8.GetComponent<Light>().intensity = outside8.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
				outside9.GetComponent<Light>().intensity = outside9.GetComponent<Light>().intensity + 0.15f * Time.deltaTime;
			}
		}

		time = speed * Time.deltaTime;
		Curtime = Curtime + time;
		transform.RotateAround(Vector3.zero, Vector3.right, time);
		transform.LookAt(Vector3.zero);
		hour = Curtime / 360.0f * 24.0f;
		int hours = (int)hour;
		timetxt.text = hours + ":00";
	}

	void updateLight()
	{
		if(hour > 18 && hour < 4)
		{
			test.transform.GetChild(1).gameObject.GetComponent<Light>().intensity = 5;
		}
	}
}
