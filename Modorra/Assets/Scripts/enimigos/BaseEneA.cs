using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEneA : MonoBehaviour
{
    public bool atacando , atordoado , PDesquerda , NPodeAndar , Pulando;

    public GameObject DP;

    bool at;

    Rigidbody2D rb;
    Animator animador;

    [SerializeField] GameObject player;
    [SerializeField] float velocidade , TempoAtordoado ;
    [SerializeField] int VidaAdd;

    Color CorInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        CorInicial = GetComponent<SpriteRenderer>().color;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {  
        if(GetComponent<dano>().vida <= 0)
        {
            if(player.GetComponent<dano>().vida < 3 && player.GetComponent<dano>().vida > 0)
            {
            player.GetComponent<dano>().vida =player.GetComponent<dano>().vida + VidaAdd;
            //player.GetComponent<dano>().VidaPlayer = player.GetComponent<dano>().vida;
            }
            
            Destroy(gameObject);
            Destroy(DP);
        }
        

        if(atordoado)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = CorInicial;
        }

        if(player.transform.position.x - 0.1f >= transform.position.x)
        {
            PDesquerda = false;
        }else if(player.transform.position.x + 0.1f <= transform.position.x)
        {
            PDesquerda = true;
        }

        if(atacando && !atordoado && !NPodeAndar && !Pulando)
        {
            
        GetComponent<SpriteRenderer>().flipX = (PDesquerda) ? false : true;
        if(PDesquerda )
        {
        rb.velocity = new Vector2(velocidade * -1 , rb.velocity.y);
        }else
        {
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
        }

        }else if(NPodeAndar)
        {
        rb.velocity = new Vector2(0, rb.velocity.y);
        }else if(Pulando)
        {
        rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y);
        }

        if(atordoado)
        {
            StartCoroutine("AtordoadoT");
        }
    }

  private IEnumerator AtordoadoT()
    {
        if(!at)
        {
            at = true;
            yield return new WaitForSeconds(TempoAtordoado);
            atordoado = false;
            at = false;
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
       if(colisor.gameObject.tag == "PA" && tag == "inimigo")
       {
       atordoado = true;
       atacando = true;
       }
    }
}
