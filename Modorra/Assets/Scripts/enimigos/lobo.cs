using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobo : MonoBehaviour
{
    public enum ISML {Parado , Correndo , Atacando , Bote , Estunado , Pulo}

    [SerializeField] float DisMinBote , DisMaxBote , TBote , TMPulo;
    [SerializeField] Vector2 ForçaPulo;

    public ISML ISMlobo ;
    bool ator , atac , ctb , CT_TMPulo;
    float CDV ,_TMPulo;

    GameObject player;
    Rigidbody2D rb;

    Animator ani ;
    BaseEneA BEA;

    void Start()
    {
        _TMPulo = TMPulo;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        BEA = GetComponent<BaseEneA>();

        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if(TMPulo != 0)
        {
            StartCoroutine("T_TMPulo");
        }

    switch(ISMlobo)
    {
      case ISML.Parado :
      parado();
      break;

      case ISML.Correndo :
      correndo();
      break;

      case ISML.Estunado :
      estunado();
      break;
    }
        
     ator = GetComponent<BaseEneA>().atordoado;
     atac = GetComponent<BaseEneA>().atacando;

    }

    void parado()
    {
        ISMlobo = ISML.Parado;
        ani.Play("LoboParado");
        if(BEA.atordoado)
        {
           estunado();
           return;
        }else if(atac)
        {
           correndo();
           return;
        }

        
    }

    void correndo()
    {
        BEA.Pulando = false;
        BEA.NPodeAndar = false;
        ISMlobo = ISML.Correndo;
        ani.Play("LoboCorrer");
        

        if(CalcDisLoboPla() > DisMinBote && CalcDisLoboPla() < DisMaxBote)
        {
            bote();
        }

        if(BEA.atordoado)
        {
        estunado();
        return;
        }
    }

    void bote()
    {
        BEA.NPodeAndar = true;
        BEA.Pulando = false;
        ISMlobo = ISML.Bote;
        ani.Play("LoboBote");

        

        if(BEA.atordoado)
        {
            BEA.NPodeAndar = false;
            estunado();
        }else
        {
            StartCoroutine("BoteT");
        }
    }

    void estunado()
    {
        BEA.NPodeAndar = true;
        BEA.Pulando = false; 

        ISMlobo = ISML.Estunado;
        ani.Play("LoboParado");
        ISMlobo = ISML.Estunado;
        if(!BEA.atordoado)
        {
          if(atac)
          {
              correndo();
              return;
          }

        }
        
    }

    void pulo()
    {
        BEA.Pulando = true;
        BEA.NPodeAndar = false; 
        
        if(ISMlobo != ISML.Pulo)
        {
            TMPulo = 1; 
            PuloDash();
        }
        ISMlobo = ISML.Pulo;
        ani.Play("LoboPulando");
        

    } 

    private IEnumerator BoteT()
    {
        BEA.Pulando = false;
        BEA.NPodeAndar = true; 

        if(!ctb)
        {
            ctb = true;
            yield return new WaitForSeconds(TBote);
            if(ISMlobo == ISML.Bote && !BEA.atordoado)
            {
                pulo();
            }else
            {
                estunado();
            }
            ctb = false;
        }

    }

    float CalcDisLoboPla()
    {
        CDV = transform.position.x - player.transform.position.x;
        CDV = (CDV < 0) ? CDV * -1 : CDV ;
        return CDV;
    }

    void PuloDash()
    {   
        if(BEA.PDesquerda)
        {
            rb.velocity = new Vector2(ForçaPulo.x , ForçaPulo.y);
        } else
        {
            rb.velocity = new Vector2(-ForçaPulo.x , -ForçaPulo.y);
        }

    }

    private IEnumerator T_TMPulo()
    {
         if(!CT_TMPulo)
         {
             CT_TMPulo = true;
             yield return new WaitForSeconds(_TMPulo);
             TMPulo = 0;
             CT_TMPulo = false;
         }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "chao" && ISMlobo == ISML.Pulo)
        {
            correndo();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "chao" && ISMlobo == ISML.Pulo && TMPulo == 0)
        {
            correndo();
        }
    }
}
