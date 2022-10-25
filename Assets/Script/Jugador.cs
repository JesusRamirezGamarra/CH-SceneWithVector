using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    
	public float speed = 3f;
	public GameObject player;

    // public GameObjet 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveAxis();
    }

	private void moveAxis(){
		// float axisHorizontal = Input.GetAxis("Horizontal");
		// float axisVertical = Input.GetAxis("Vertical");
		float axisHorizontal = Input.GetAxisRaw("Horizontal");  // Round
		float axisVertical = Input.GetAxisRaw("Vertical");		// Round
		Vector3 direction = new Vector3(axisHorizontal,0,axisVertical);
		Vector3 translateDirection = direction * speed * Time.deltaTime;
		transform.Translate(translateDirection);

		if ( Input.GetKey(KeyCode.Q)){
			transform.Rotate(0,-1f,0);
		}
		if( Input.GetKey(KeyCode.E)){
			transform.Rotate(0,1f,0);
		}

        // player.setAnimator(true);

		// if (audioSourceMovePlayer.isPlaying && translateDirection == Vector3.zero){
		// 	audioSourceMovePlayer.Stop();
		// }
		// else {
		// 	while (!audioSourceMovePlayer.isPlaying )
		// 	{
		// 		audioSourceMovePlayer.Play();
		// 	}
		// }
	}

  

}
