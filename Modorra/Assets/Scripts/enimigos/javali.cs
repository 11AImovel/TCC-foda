using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseEneA))]
public class javali : MonoBehaviour
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
        ani.Play("JavaliCorrer");
     }else
     {
        ani.Play("JavaliParado");
     }

    }

}
