using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dano : MonoBehaviour
{
    public int vida; 
    public static int VidaPlayer;

    GameObject player;

    [SerializeField] float MinCima , MinLado , ForçaImpulso , TempoImun;

    [SerializeField] bool NPodeDano;

    Rigidbody2D rb;

    public Vector2 direcao;

    bool TTIT;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        
        rb = GetComponent<Rigidbody2D>();

        if(gameObject.tag == "Player")
        {
            VidaPlayer = (VidaPlayer <= 0) ? 3 : VidaPlayer;
            vida = VidaPlayer;
        }
    }   

    void Update()
    {
        if(NPodeDano)
        {
            StartCoroutine("TTEmpoImun");
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "PA" && tag == "inimigo" && !NPodeDano)
       {
           NPodeDano = true;
           vida = vida - collider.GetComponent<projetil>().dano;
           direcao = new Vector2(transform.position.x - collider.transform.position.x , transform.position.y - collider.transform.position.y);
           direcao = direcao.normalized;
           rb.velocity = new Vector2(0,0);
           rb.AddForce(ForçaImpulso * direcao , ForceMode2D.Impulse);
           if(collider.GetComponent<projetil>().Seguir != null)
           {
               collider.GetComponent<projetil>().Seguir.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
           }        
       }

       if(collider.gameObject.tag == "EA" && tag == "Player" && !NPodeDano)
       {
           NPodeDano = true;
           GetComponent<MovimentoP>().Atordoado = true;
           VidaPlayer = VidaPlayer - collider.GetComponent<projetil>().dano;
           vida = vida - collider.GetComponent<projetil>().dano;

           direcao = new Vector2(transform.position.x - collider.transform.position.x , transform.position.y - collider.transform.position.y);
           direcao = direcao.normalized;
           if(direcao.y >= 0 && direcao.y < MinCima){direcao.y = MinCima;}
           if(direcao.x > 0 && direcao.x < MinLado){direcao.x = MinLado;}
           if(direcao.x < 0 && direcao.x > -MinLado){direcao.x = -MinLado;}
           if(direcao.y >= 0 && direcao.y < MinCima){direcao.y = MinCima;}
           direcao = direcao.normalized;
           rb.velocity = new Vector2(0,0);
           rb.AddForce(ForçaImpulso * direcao , ForceMode2D.Impulse);
           collider.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
       }

        if(collider.gameObject.tag == "Player" && tag == "inimigo")
        {
               direcao = new Vector2(transform.position.x - player.transform.position.x , transform.position.y - player.transform.position.y);
               direcao = direcao.normalized;
               player.GetComponent<MovimentoP>().Atordoado = true;
           
            if(player.transform.position.x >= transform.position.x)
            {
               rb.velocity = new Vector2(0,0);
               player.GetComponent<Rigidbody2D>().AddForce(-ForçaImpulso * direcao, ForceMode2D.Impulse);
            }else
            {
                rb.velocity = new Vector2(0,0);
                player.GetComponent<Rigidbody2D>().AddForce(-ForçaImpulso * direcao, ForceMode2D.Impulse);
            }
        }


    }

    private IEnumerator TTEmpoImun()
    {
        if(!TTIT)
        {
            TTIT = true;
            yield return new WaitForSeconds(TempoImun);
            NPodeDano = false;
            TTIT = false;
        }
    }

  
}
