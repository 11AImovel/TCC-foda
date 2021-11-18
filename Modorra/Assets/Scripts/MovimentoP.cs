using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoP : MonoBehaviour
{
   Rigidbody2D rb;
   AtaqueP ap;
   AnimacaoP acp;
   SpriteRenderer sr;
   Vector2 direcao;
   [SerializeField] float velocidade , ForçaDash , TempoDash , ForçaPulo , TempoAtordoado , DeleyDash;
   float dd;
   public bool PodeCorrer , PodePular , Atordoado , TDashT_ , Mergulhando , NPodeMergul; 
   bool tum,ta;
   

   void Start()
   {
       rb = GetComponent<Rigidbody2D>();
       ap = GetComponent<AtaqueP>();
       acp = GetComponent<AnimacaoP>();
       sr = GetComponent<SpriteRenderer>();
       dd = DeleyDash;

   }

   void Update()
   { 
     if(DeleyDash != 0)
     {
       StartCoroutine("ddt");
     }

     if(Atordoado)
     {
       StartCoroutine("TAtordoado");
     }

     if(Input.GetKeyDown("z"))
     {
            dash();
      
     }

     if(PodePular && Input.GetKey(KeyCode.Space) && !Atordoado)
     {
       PodePular = false;
       rb.AddForce(transform.up * ForçaPulo ,ForceMode2D.Impulse);
       //rb.velocity = new Vector3(0, 10, 0);
       //_Rigidbody.AddForce(m_NewForce, ForceMode.Acceleration);
     }
   }

   void FixedUpdate()
   {
     if(!Atordoado)
     {
      if(acp.PegarAni(GetComponent<Animator>()) == "PlayerCorrer" && PodeCorrer || acp.PegarAni(GetComponent<Animator>()) == "PlayerParado" && PodeCorrer)
       {
         rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidade , rb.velocity.y);
       }
     }
       
       
   }

   void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "chao")
        {

          PodePular = true;
        } 
        
    }

    private IEnumerator TAtordoado()
    {
      if(!ta)
      {
      ta = true;
      yield return new WaitForSeconds(TempoAtordoado);
      Atordoado = false;
      ta = false;
      }
      
    } 

    private IEnumerator TDash()
    {
      if(!tum)
      {
      tum = true;
      direcao = (sr.flipX) ? Vector2.right : -Vector2.right;
      rb.velocity = new Vector2(0,0);
      rb.AddForce(ForçaDash * direcao , ForceMode2D.Impulse);
      yield return new WaitForSeconds(TempoDash);
      Mergulhando = false;
      tum = false;
      }
      yield return null;
    }

    void dash()
    {
      if(DeleyDash == 0 && !NPodeMergul)
      {
      Mergulhando = true;
      DeleyDash = dd;
      acp.TrocarAni("PlayerMergulho");
      if(FindObjectOfType<AudioManager>() != null){FindObjectOfType<AudioManager>().Play("dash2");}
      StartCoroutine("TDash");
      }
    }

    private IEnumerator ddt()
    {
      if(!TDashT_)
      {
        TDashT_ = true;
        yield return new WaitForSeconds(1);
      DeleyDash--;
        TDashT_ = false;
      }

      yield return null;
      
    }

}
