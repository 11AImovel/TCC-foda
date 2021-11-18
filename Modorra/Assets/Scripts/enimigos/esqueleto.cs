using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esqueleto : MonoBehaviour
{
    bool ator , atac;
    Animator ani ;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        
     ator = GetComponent<BaseEneA>().atordoado;
     atac = GetComponent<BaseEneA>().atacando;
     
     if(!ator && atac)
     {
        ani.Play("EsqueletoCorrer");
     }else
     {
        ani.Play("EsqueletoParado");
     }

    }
}
