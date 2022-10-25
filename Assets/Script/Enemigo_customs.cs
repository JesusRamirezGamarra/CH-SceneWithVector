using UnityEngine;

public class Enemigo_customs : MonoBehaviour
{

    [SerializeField] private Transform posJugador;
    [SerializeField] [Range(1f,4f)]private float speed = 2f;
    
    [SerializeField] private enum Behaviour{
        lookAt,
        followAt
    }

    [SerializeField] private  Behaviour behaviour ;
    [SerializeField] private Animator anim;
// Animation anim;

    private float resetSpeed =0f;
    private float MaxDistance =2f;    
    private const float plusSepateDistance = 1.75f;

    Enemigo_TeMira oEnemigo_TeMira ;

    // Start is called before the first frame update
    void Start()
    {
        resetSpeed = speed;
        anim.SetBool("Run", false);
        //anim.SetActive(false);
        // anim = GetComponent<Animation>();
        // if (anim.isPlaying)
        // {
        //     anim.Stop();
        // }        

    }

    // Update is called once per frame
    void Update()
    {
        // oEnemigo_TeMira = new Enemigo_TeMira();
        // oEnemigo_TeMira.posJugador = posJugador;
        // oEnemigo_TeMira.speed = speed;        
        // oEnemigo_TeMira.lookAtPlayer();
        switch (behaviour){
            case Behaviour.lookAt:
                lookAtPlayer();
                break;
            case Behaviour.followAt:
                lookAtPlayer();
                checkDistance();
                followPlayer();            
                break;
            default:
                lookAtPlayer();
                checkDistance();
                followPlayer();   
                break;                                
        }
    }
    public void lookAtPlayer(){
        Quaternion newRotation = Quaternion.LookRotation(posJugador.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation,speed*Time.deltaTime);
    }

    private void followPlayer(){
        Vector3 newposJugador= new Vector3(	posJugador.position.x-plusSepateDistance, 
                                            posJugador.position.y,
                                            posJugador.position.z );
        
        transform.position = Vector3.Lerp(transform.position,newposJugador, speed * Time.deltaTime);
    }    

    void checkDistance(){
        float distance = Vector3.Distance(posJugador.position, transform.position);
        if  ( distance < MaxDistance) {
            speed = 0;
        }else{
            speed = resetSpeed;
        }
    }

}
