﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
 *  AUTHOR:     Dylan Murphy
 *              
 *  Script that handles scene switching.
 */

public class Scene : MonoBehaviour {

	public string destination;

	public void playSound() {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}

	public void LoadScene () {
		playSound ();
		Application.LoadLevel (destination);
	}

	public void goLevel2()
	{
		playSound ();
		Application.LoadLevel (destination);
	}

	public void goQuit()
	{
		playSound ();
		Application.Quit();
	}

}
