using UnityEngine;

public class Enemigo_TeMira : MonoBehaviour
{

    [SerializeField] private Transform posJugador;
    [SerializeField] [Range(1f,4f)]public float speed = 2f;

    // Update is called once per frame
    void Update(){
        lookAtPlayer();
    }

    // private void lookAtPlayerQuaternion(){
    //     Quaternion rotar = Quaternion.LookRotation(posJugador.position - transform.position);
    //     transform.rotation = rotar;
    // }

    // private void lookAtPlayer(){
    //     transform.LookAt(posJugador);
    // }

    public void lookAtPlayer(){
        Quaternion newTotation = Quaternion.LookRotation(posJugador.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newTotation,speed*Time.deltaTime);
    }




}
