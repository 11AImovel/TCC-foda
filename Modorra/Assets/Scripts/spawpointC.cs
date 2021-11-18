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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(dano.VidaPlayer <= 0)
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
          SceneManager.LoadScene(SpawpointAtivo);
          TM = false;
      }
    }
}
