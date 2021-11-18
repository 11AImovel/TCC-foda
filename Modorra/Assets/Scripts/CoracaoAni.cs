using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoracaoAni : MonoBehaviour
{
    public enum EstadoCoracao {enchendo , esvaziando , cheio , vazio}

    public EstadoCoracao ec , AntAnim;
    bool enc , esv ;

    Animator anim ;

    void Start()
    {
       anim = GetComponent<Animator>();
       
    } 

    void Update()
    {

        switch(ec){
            case EstadoCoracao.cheio:
            cheio();
            break;

            case EstadoCoracao.vazio:
            vazio();
            break;

            case EstadoCoracao.enchendo:
            enchendo();
            break;

            case EstadoCoracao.esvaziando:
            esvaziando();
            break;

        }
    } 

    public void enchendo()
    {
        StartCoroutine("enchendoW");
    }

    public void esvaziando()
    {
        StartCoroutine("esvaziandoW");
    }

    public IEnumerator enchendoW(){

    if(!enc && AntAnim != ec){          
    enc = true;
    anim.Play("encher");
    AntAnim = ec;
    yield return new WaitForSeconds(0.267f);
    ec = EstadoCoracao.cheio;
    enc = false;
    }} 

    public IEnumerator esvaziandoW()
    {
    if(!esv && AntAnim != ec){
    esv = true;
    anim.Play("esvaziar");
    AntAnim = ec;
    yield return new WaitForSeconds(0.333f);
    ec = EstadoCoracao.vazio;
    esv = false;
    }}

    void cheio(){
    if(AntAnim != ec){
    anim.Play("cheio");
    AntAnim = ec;
    }}

    void vazio(){
    if(AntAnim != ec)
    {
    anim.Play("vazio");
    AntAnim = ec;
    }}

}
