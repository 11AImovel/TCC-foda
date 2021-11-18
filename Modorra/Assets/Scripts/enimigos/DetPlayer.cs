using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetPlayer : MonoBehaviour
{
    [SerializeField] GameObject InimigoVer;

    void Start()
    {
        InimigoVer.GetComponent<BaseEneA>().DP = gameObject;
    }

    void Update()
    {
        transform.position = InimigoVer.transform.position;
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if(colisor.gameObject.tag == "Player")
        {
        if(InimigoVer.GetComponent<SpriteRenderer>().flipX == true && colisor.transform.position.x > InimigoVer.transform.position.x || InimigoVer.GetComponent<SpriteRenderer>().flipX == false && colisor.transform.position.x < InimigoVer.transform.position.x)
        {
        InimigoVer.GetComponent<BaseEneA>().atacando = true;
         
        }}
    }
}
