var Celldooropensound : AudioClip;
var door : GameObject; //this is your game object that you want to move on trigger.
private var closed = true; // door initially closed

		function OnTriggerEnter(){ 
   		if (closed){ // only do it if door closed 
		closed = false; // door now is open
		GetComponent.<AudioSource>().PlayOneShot(Celldooropensound);
	}
}