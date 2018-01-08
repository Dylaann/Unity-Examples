using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Dylan Murphy
/// Date: 25/09/2017
/// Camera Moves with the player
/// </summary>

public class Camera_Movement : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;       

	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
		
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
	}
}
