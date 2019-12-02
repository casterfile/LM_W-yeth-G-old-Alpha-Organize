using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalFunction : MonoBehaviour {

	private GameObject WallTobeDelete, Balls,CanObject,CanManager, Caption1, Confetti;
	public bool isDeleteTopWall = false, isFallObject = false, isGameEnd = false,isGameLose = false, isPlayOnceOpen = false, isPlayOnceEnd = false, isTimerStart;
	public int countShaking = 0;
	public Animator Anim_Can;
	private  GameObject[] AnimationBalls;
	private Text TimerCounter;
	private float timeLeft = 60;
	// Use this for initialization
	void Start () {
		countShaking = 0;
		isDeleteTopWall = false;

		AnimationBalls = GameObject.FindGameObjectsWithTag ("AnimationBalls");
		WallTobeDelete = GameObject.Find("WallTobeDelete");
		Balls = GameObject.Find("Balls");
		CanObject = GameObject.Find("CanObject");
		CanManager = GameObject.Find("CanManager");
		Caption1 = GameObject.Find("Caption1");
		TimerCounter = GameObject.Find("TimerCounter").GetComponent<Text>();
		TimerCounter.text = "";
		Confetti = GameObject.Find("Confetti");

		Balls.SetActive(false);
		CanManager.SetActive(false);
		Caption1.SetActive(false);
		Confetti.SetActive(false);

		DeleteTopWall();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDeleteTopWall == true && isPlayOnceOpen == false){
			isPlayOnceOpen = true;
			CanManager.SetActive(true);
			CanObject.SetActive(false);
			CanObject.GetComponent<Collider>().enabled = false;
			CanObject.transform.localPosition = new Vector3(0f, -1.806f, -2.648594f);
			CanObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
			StartCoroutine(PlayAnimationCaption(6.0f));
			StartCoroutine(PlayAnimation(4.0f));
		}

		// if(countShaking >= 200){
		// 	DeleteTopWall();
		// }
		if(isFallObject == true){
			if(GameObject.FindGameObjectsWithTag("fry").Length == 0) {
				if(isPlayOnceEnd == false){
					isPlayOnceEnd = true;
					StartCoroutine(PlayAnimationEnd(2.0f));
				}
		 	}
		}

		if(isTimerStart == true){
			 timeLeft -= Time.deltaTime;
			 int secInt = (int)timeLeft;
			 TimerCounter.text = "Timer: "+secInt;
		     if ( timeLeft < 0 )
		     {
		     	TimerCounter.text = "";
		     	isGameLose = true;
		     	isTimerStart = false;
		        print("End game");
		     }
		}
		
	}


	public void DeleteTopWall(){
		
		isDeleteTopWall = true;
		
	}

	IEnumerator PlayAnimation(float Delay)
    {
        Anim_Can.SetInteger("AnimationNum", 1);
        yield return new WaitForSeconds(Delay);
        
		for(var i = 0 ; i < AnimationBalls.Length ; i ++)
		{
		 	AnimationBalls[i].SetActive(false);
		}

        Balls.SetActive(true);
		
		WallTobeDelete.SetActive(false);
		isFallObject = true;
		

    }

    IEnumerator PlayAnimationEnd(float Delay)
    {
    	isTimerStart = false;
    	TimerCounter.text = "";
		Anim_Can.SetInteger("AnimationNum", 2);
		yield return new WaitForSeconds(1.0f);
		// for(var i = 0 ; i < AnimationBalls.Length ; i ++)
		// {
		//  	AnimationBalls[i].SetActive(true);
		// }

        
        yield return new WaitForSeconds(5.0f);
        isGameEnd = true;
    }

    IEnumerator PlayAnimationCaption(float Delay)
    {
    	
		Caption1.SetActive(true);
		yield return new WaitForSeconds(Delay);
        Caption1.SetActive(false);
        isTimerStart = true;
    }

    public void PlayConfetti(){
    	StartCoroutine(PlayAnimationPlayConfetti(2.0f));
    }

    IEnumerator PlayAnimationPlayConfetti(float Delay)
    {
    	
		Confetti.SetActive(true);
		yield return new WaitForSeconds(Delay);
        Confetti.SetActive(false);
    }

}
