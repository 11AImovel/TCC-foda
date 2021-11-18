using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject camera , player;
    [SerializeField] float multiplicador;
    [SerializeField] bool SeguirY;
    float dis , inicialX , inicialY , inicialCY;
    

    
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        inicialX = transform.position.x;
        inicialY = transform.position.y;
        inicialCY = camera.transform.position.y;
    }

    void Update()
    {
    if(SeguirY)
    {
        transform.position = new Vector3(transform.position.x ,inicialY - (inicialCY - camera.transform.position.y) , transform.position.z);
    }
    dis = camera.transform.position.x * multiplicador/20 ;
    transform.position = Vector2.Lerp(transform.position , new Vector2(dis + inicialX + camera.transform.position.x * multiplicador/20 , transform.position.y ), Time.deltaTime * 10) ;   
    }
}
