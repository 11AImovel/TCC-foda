using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public static string CenarioVaria ;
    public static int Pato;

    AtaqueP ap;
    MovimentoP mp;

    public GameObject pato;

    [SerializeField] GameObject ObjTransicao;
    [SerializeField] string ProxCena , ProxCenaInfo;

    GameObject player;

    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        pato = GameObject.FindGameObjectWithTag("Pato");

        if(pato != null)
        {
          if(pato.active)
        {
        pato.SetActive(false);
        }  
        }
        
        

        switch(CenarioVaria)
        {
            case "PrimeiraC2" : 
            player.transform.position = new Vector2(3.83f , -1.031662f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            Pato++;
            if(Pato >= 5)
            {
                pato.SetActive(true);
            }
            break;
        }

    }

    void Start()
    {
           
           mp = player.GetComponent<MovimentoP>();
           ap = player.GetComponent<AtaqueP>();   
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(player.GetComponent<dano>().vida > 0)
        {
    ap.PodeAtacar = false;
    mp.PodeCorrer = false;
    mp.NPodeMergul = true;
    StartCoroutine("TempoDesaparecer");
        }
    }

    private IEnumerator TempoDesaparecer()
    {
        ObjTransicao.GetComponent<Animator>().Play("aparecimento");

        yield return new WaitForSeconds(0.5f);
        CenarioVaria = ProxCenaInfo;
        SceneManager.LoadScene(ProxCena);
    }
}
