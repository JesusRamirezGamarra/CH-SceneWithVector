using UnityEngine;

public class Enemigo_TeSigue : MonoBehaviour
{
    [SerializeField] private Transform posJugador;

    [SerializeField] [Range(1f,4f)]private float speed = 2f;
    private float resetSpeed =0f;
    private float MaxDistance =2f;

    // Start is called before the first frame update
    void Start()
    {
        resetSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        lookAtPlayer();
        checkDistance();
        followPlayer();
    }

    void checkDistance(){
        float distance = Vector3.Distance(posJugador.position, transform.position);
        // Debug.Log(distance);
        if  ( distance < MaxDistance) {
            speed = 0;
        }else{
            speed = resetSpeed;
        }
    }
    
    private void lookAtPlayer(){
        Quaternion newRotation = Quaternion.LookRotation(posJugador.position - transform.position );
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation,speed*Time.deltaTime);
    }

    // private void followPlayer()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position,posJugador.position,Time.deltaTime );
    // }
    private void followPlayer(){
        transform.position = Vector3.Lerp(transform.position,posJugador.position, speed * Time.deltaTime);
    }
}
