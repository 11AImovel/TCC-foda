using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoP : MonoBehaviour
{
    SpriteRenderer sr;

    Animator animador;
    AtaqueP ap;
    Color CorInicial;
    dano dano_;
    MovimentoP mp;

    void Start()
    {
        ap = GetComponent<AtaqueP>();
        sr = GetComponent<SpriteRenderer>();
        dano_ = GetComponent<dano>();
        mp = GetComponent<MovimentoP>();

        animador = GetComponent<Animator>();

        CorInicial = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {

        if(GetComponent<MovimentoP>().Atordoado)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = CorInicial;
        }

        if(PegarAni(animador) == "PlayerMorrer")
        {
            ap.PodeAtacar = false;
            mp.NPodeMergul = true;
            
        }

    if(dano_.vida > 0 && !mp.Mergulhando)
    {
        if(ap.NaoAtacando)
        {

         if(Input.GetAxisRaw("Horizontal") != 0)
        {
            TrocarAni("PlayerCorrer");        
        }

        if(Input.GetAxisRaw("Horizontal") == 0) 
        { 
            TrocarAni("PlayerParado");
        }      
        
        if(Input.GetAxisRaw("Horizontal") != 0 && PegarAni(animador) != "PlayerAtacar" && PegarAni(animador) != "PlayerMergulho")
        {
           sr.flipX = (Input.GetAxisRaw("Horizontal") == 1) ? true : false;
        }

        }
    }else if(dano_.vida <= 0)
    {
        TrocarAni("PlayerMorrer");
        }
        

         
    }

    public  void TrocarAni(string ani)
    {
        if(ani != PegarAni(animador))
        {
          animador.Play(ani);
        }

    }

    public string PegarAni(Animator animat)
    {
        return(animat.GetCurrentAnimatorClipInfo(0)[0].clip.name + "");
    }


}
