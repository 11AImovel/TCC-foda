using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{
    public int dano;
    [SerializeField] bool SeguirP;
    public GameObject Seguir;
    Vector2 Vec2Dif;

    void Start()
    {
        if(SeguirP)
        {
        Seguir = GameObject.FindGameObjectWithTag("Player");
        //Vec2Dif = new Vector2(Seguir.transform.position.x - Vec2Dif.x , Seguir.transform.position.y - Vec2Dif.y);
        }
    
    }

    void Update()
    {
        if(SeguirP)
        {
            transform.position = new Vector2 (Seguir.transform.position.x - Vec2Dif.x , transform.position.y - Vec2Dif.y );

            //Vec2Dif = new Vector2(Seguir.transform.position.x - Vec2Dif.x , Seguir.transform.position.y - Vec2Dif.y);
            
        }

    }

}
