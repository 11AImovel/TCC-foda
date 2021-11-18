using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoracaoConjunto : CoracaoAni
{
    public GameObject [] coracoes ;
    public bool [] CoracoesB;
    GameObject player;
    CoracaoAni CorAni;
    public int x;
    dano SDano;

    void Start()
    {  
    coracoes = GameObject.FindGameObjectsWithTag("coracao");
    player = GameObject.FindGameObjectWithTag("Player");
    CoracoesB = new bool [coracoes.Length];
    SDano = player.GetComponent<dano>();
    //CorAni = GetComponent<CoracaoAni>();
    }

    void Update()
    {
    int x = 0;
    while(coracoes.Length > x)
    {
    CoracoesB [x] = (x < SDano.vida) ? true : false ; 
    

    if(PegarCorAniEC(coracoes[x]) == EstadoCoracao.cheio && CoracoesB[x] == false)
    {
        coracoes[x].GetComponent<CoracaoAni>().esvaziando();
        coracoes[x].GetComponent<CoracaoAni>().ec =  EstadoCoracao.esvaziando;
        
    }

    if(PegarCorAniEC(coracoes[x]) == EstadoCoracao.vazio && CoracoesB[x] == true)
    {
        coracoes[x].GetComponent<CoracaoAni>().enchendo();
        coracoes[x].GetComponent<CoracaoAni>().ec = EstadoCoracao.enchendo;
    }
    x++;

    }   
    }

    EstadoCoracao PegarCorAniEC(GameObject go)
    {
    return go.GetComponent<CoracaoAni>().ec;
    }

}
