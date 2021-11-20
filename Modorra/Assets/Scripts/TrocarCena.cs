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

            case "FL22" :
            player.transform.position = new Vector2(24.50372f , -0.9867788f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            Destroy(GameObject.FindGameObjectWithTag("dele"));
            break;

            case "Fl1-2b":
            player.transform.position = new Vector2(20.01391f,-0.01855975f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;

            case "Fl1-3b":
            player.transform.position = new Vector2(33.71237f , -2.017968f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;

            case "Fl1-4b":
            player.transform.position = new Vector2(36.03097f,1.000282f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;

            case "Fl1-5b":
            player.transform.position = new Vector2(36.89645f,1.975439f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;

            case "C2-1b":
            player.transform.position = new Vector2(34.79776f,-0.01546675f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;

            case "C2-2b":
            player.transform.position = new Vector2(35.17736f,1.935107f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;
            
            case "C2-3b":
            player.transform.position = new Vector2(38.66639f,-1.008f);
            player.GetComponent<SpriteRenderer>().flipX = false;
            break;
     
            
            
            
            
            
            
        }

    }

    void Start()
    {
           
           mp = player.GetComponent<MovimentoP>();
           ap = player.GetComponent<AtaqueP>();   

           //ProxCenaInfo = null;
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
