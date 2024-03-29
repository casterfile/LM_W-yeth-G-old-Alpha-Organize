﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public static int PlayerScore = 0;
	public static int Life = 3;
	public GameObject UIControlWin, UIControlLose,Scoremanager;
	private Text Output;
	public string SceneName;
	private GameObject H1,H2,H3;

	private GameObject Popup1,Popup2,Popup3,Popup4;
	// Use this for initialization
	void Start () {
		PlayerScore = 0;
		Life = 3;
		H1 = GameObject.Find("H1");
		H2 = GameObject.Find("H2");
		H3 = GameObject.Find("H3");

		Popup1 = GameObject.Find("Popup1");
		Popup2 = GameObject.Find("Popup2");
		Popup3 = GameObject.Find("Popup3");
		Popup4 = GameObject.Find("Popup4");

		Output = GameObject.Find("Output").GetComponent<Text>();
		Scoremanager = GameObject.Find("Scoremanager");


		Popup1.SetActive (false);
		Popup2.SetActive (false);
		Popup3.SetActive (false);
		Popup4.SetActive (false);

		UIControlWin.SetActive (false);
		UIControlLose.SetActive (false);
		Scoremanager.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		Output.text = PlayerScore+"";//"Score: "+ PlayerScore+ " || Life: "+ Life;

		if(Life == 3){
			H1.SetActive(true);
			H2.SetActive(true);
			H3.SetActive(true);
		}else if(Life == 2){
			H1.SetActive(true);
			H2.SetActive(true);
			H3.SetActive(false);
		}else if(Life == 1){
			H1.SetActive(true);
			H2.SetActive(false);
			H3.SetActive(false);
		}else if(Life == 0){
			H1.SetActive(false);
			H2.SetActive(false);
			H3.SetActive(false);
		}

		if(PlayerScore == 10){
			UIControlWin.SetActive (true);
			Scoremanager.SetActive(false);
		}
		else if(Life == 0){
			UIControlLose.SetActive (true);
			Scoremanager.SetActive(false);
		}
	}

	public void Restart(){
		Application.LoadLevel(SceneName);
	}


	public void OutputPopup(int NumberPopup){
		int number = 1;
		Popup1.SetActive (false);
		Popup2.SetActive (false);
		Popup3.SetActive (false);
		if(NumberPopup == 1){
			number = Random.Range(1,3);
			if(number == 2){
				NumberPopup = 1;
			}else{
				NumberPopup = 2;
			}
		}

		if(NumberPopup == 1){
			Popup1.SetActive (true);
			Popup2.SetActive (false);
			Popup3.SetActive (false);
			Popup4.SetActive (false);
		}else if(NumberPopup == 2){
			Popup1.SetActive (false);
			Popup2.SetActive (true);
			Popup3.SetActive (false);
			Popup4.SetActive (false);
		}else if(NumberPopup == 3){
			Popup1.SetActive (false);
			Popup2.SetActive (false);
			Popup3.SetActive (true);
			Popup4.SetActive (false);
		}else if(NumberPopup == 4){
			Popup1.SetActive (false);
			Popup2.SetActive (false);
			Popup3.SetActive (false);
			Popup4.SetActive (true);
		}
	}
}
