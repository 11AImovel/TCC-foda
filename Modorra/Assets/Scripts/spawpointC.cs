using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawpointC : MonoBehaviour
{
    bool TM;

    [SerializeField] string SpawpointAtivo;
    GameObject player;
    dano dano_;

    TrocarCena TC;

    void Start()
    {
        TC = GetComponent<TrocarCena>();
        player = GameObject.FindGameObjectWithTag("Player");
        dano_ = GetComponent<dano>();
    
    }

    void Update()
    {
        if(dano_.vida <= 0)
        {
           StartCoroutine("TimerMorte");
        }
        
    }

    private IEnumerator TimerMorte()
    {
      if(!TM)
      {
            FindObjectOfType<AudioManager>().Play("dead");
            TM = true;
          yield return new WaitForSeconds(1.800f);
          if(dano_.vida <= 0)
          {
          
          SceneManager.LoadScene(SpawpointAtivo);
          
          }
          
          TM = false;
      }
    }
}
