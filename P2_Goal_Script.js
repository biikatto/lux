#pragma strict

//var labelPos : Rect =  Rect(250,10,50,20);
var score : float = 0f;
var maxScore : float = 3f;
var Ball : Transform;
var Spawn : Transform;
var w : float = 150f;
var h : float = 50f;
private var words = Rect((Screen.width-w)/2, (Screen.height-h)/2, w, h);
var fontSize : float = 20f;

var GuiSkin1 : GUISkin;
var GuiSkin2 : GUISkin;
var GuiSkin3 : GUISkin;
var goalText : boolean = false;

function TextWait () {
	if(goalText == true) {
		yield WaitForSeconds(1);
		goalText = false;
	}
}


function OnTriggerEnter (other : Collider) {
	if(other.tag == "Ball") {
		TextWait();
		score = score + 1;
		var instanceBall = Instantiate(Ball, Spawn.transform.position, transform.rotation);
		goalText = true;
		yield WaitForSeconds(3);
		goalText = false;
		if(score == maxScore) {
			
			Application.LoadLevel ("ArenaMap_1");
}
}
}

  function OnGUI(){
    	GUI.skin = GuiSkin3;
//   		GUI.Label(labelPos, "P2:" + score); 
   		GUI.Label(Rect((Screen.width * 0.75) - 75,15,150,50), "Score:" + score);
    
    	if(goalText == true) {
    		GUI.skin = GuiSkin2;        
			GUI.Label(Rect((Screen.width-w)/2, (Screen.height-h)/2, w, h), "GOAL!");
    	}
        if(score == maxScore) {
			GUI.skin = GuiSkin1;        
			GUI.Label(Rect((Screen.width-w)/2, (Screen.height-h)/2, w, h), "Player 2 Wins!!");
         }
  }