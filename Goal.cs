using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour{
	public bool player2;
	private float score = 0f;
	public float maxScore = 3f;
	public Transform Ball;
	public Transform Spawn;
	public float w = 500f;
	public float h = 100f;
	private Rect words;
	private Rect scoreRect;
	public float fontSize = 20f;

	public GUISkin winMessageGuiSkin;
	public GUISkin goalMessageGuiSkin;
	public GUISkin scoreGuiSkin;
	private bool displayGoalText = false;

	private string winMessage;

	void Start(){
		if(player2){
			winMessage = "Player 2 Wins!!";
		}else{
			winMessage = "Player 1 Wins!!";
		}
 		words = new Rect(
 				(Screen.width-w)/2,
 				(Screen.height-h)/2,
 				w,
 				h);
   		scoreRect = new Rect(
   				(Screen.width * 0.25f) - 75f,
   				15f,
   				150f,
   				50f);
	}

	IEnumerator TextWait (float seconds) {
		if(displayGoalText == true) {
			yield return new WaitForSeconds(seconds);
			displayGoalText = false;
		}
	}

	IEnumerator DisplayGoalText(float seconds){
		displayGoalText = true;
		yield return new WaitForSeconds(seconds);
		displayGoalText = false;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Ball") {
			StartCoroutine(TextWait(1));
			score++;
			// Change this to be a spawner method later
			GameObject instanceBall = Instantiate(
					Ball,
					Spawn.transform.position,
					Spawn.transform.rotation) as GameObject;
			StartCoroutine(DisplayGoalText(3));
			if(score >= maxScore) {
				Application.LoadLevel ("ArenaMap_1");
			}
		}
	}

  	void OnGUI(){
    	GUI.skin = scoreGuiSkin;
   		GUI.Label(scoreRect, "Score:" + score);

    	if(displayGoalText) {
    		GUI.skin = goalMessageGuiSkin;        
			GUI.Label(words, "GOAL!");
    	}

        if(score == maxScore) {
			GUI.skin = winMessageGuiSkin;        
			GUI.Label(words, winMessage);
        }
  	}
}
