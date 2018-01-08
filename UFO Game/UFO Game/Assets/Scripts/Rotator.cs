using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Dylan Murphy
/// Date: 25/09/2017
/// Rotates sprites
/// </summary>

public class Rotator : MonoBehaviour {
	
	public int speed;

	void Update () 
	{
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime * speed);
	}
}
