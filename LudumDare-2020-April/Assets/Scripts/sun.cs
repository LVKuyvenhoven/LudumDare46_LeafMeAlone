using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour {
	public float speed;
	float time;
	float Curtime;
	public float hour;
	
	// Update is called once per frame
	void Update () 
	{
		if(Curtime >= 360)
		{
			Curtime = 0;
		}

		time = speed * Time.deltaTime;
		Curtime = Curtime + time;
		transform.RotateAround(Vector3.zero, Vector3.right, time);
		transform.LookAt(Vector3.zero);
		hour = Curtime / 360.0f * 24.0f;
	}
}
