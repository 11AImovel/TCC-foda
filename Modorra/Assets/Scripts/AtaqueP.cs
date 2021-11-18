using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueP : MonoBehaviour
{
    [SerializeField] GameObject PFCorte;
    [SerializeField] Vector2 diferença;
    [SerializeField] float ForçaDash;

    Rigidbody2D rb;
    SpriteRenderer sr;
    MovimentoP mp;

    Vector2 _diferença , direcao;
    GameObject corte;

    public bool PodeAtacar;
    public bool NaoAtacando = true; 

    bool ta , ea;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mp = GetComponent<MovimentoP>();      
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && PodeAtacar && mp.PodeCorrer && mp.PodePular)
        {
            PodeAtacar = false;
            Ataque();
            StartCoroutine("TerminarAtaque");
            NaoAtacando = false;
            mp.PodeCorrer = false;
        if(FindObjectOfType<AudioManager>() != null){FindObjectOfType<AudioManager>().Play("somEspada");}      
            GetComponent<AnimacaoP>().TrocarAni("PlayerAtacar"); 
        }
        
        if(!PodeAtacar){StartCoroutine("EsperaAtaque");}
    }

    private IEnumerator EsperaAtaque()
    {
        if(!ea)
        {
            ea = true;
            yield return new WaitForSeconds(0.400f);
            PodeAtacar = true;
            ea = false;
        }
    }

    private IEnumerator TerminarAtaque()
    {
        if(!ta)
        {
            ta = true;
            yield return new WaitForSeconds(0.200f);
             NaoAtacando = true;
             mp.PodeCorrer = true;
            if(corte != null){Destroy(corte);}
            rb.velocity = new Vector2(0,0);
            ta = false;
        }

    }

    void Ataque()
    {
        direcao = (sr.flipX) ? Vector2.right : -Vector2.right;
        rb.velocity = new Vector2(0,0);
        rb.AddForce(ForçaDash * direcao , ForceMode2D.Impulse);
        
        _diferença.x = (sr.flipX) ? diferença.x : -diferença.x ;
        corte = Instantiate(PFCorte, new Vector2(transform.position.x + _diferença.x , transform.position.y + diferença.y ), Quaternion.identity);
        corte.GetComponent<SpriteRenderer>().flipX = sr.flipX;
    }
}
