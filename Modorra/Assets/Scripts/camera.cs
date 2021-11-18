using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] float VelCam;
    [SerializeField] Vector2 MaxDis , MinDis;
    public GameObject alvo ;

    void Update()
    {
            //x
            if(MaxDis.x == 0 && MinDis.x == 0 || alvo.transform.position.x < MaxDis.x && alvo.transform.position.x > MinDis.x)
            {
            transform.position = Vector3.Lerp(transform.position,new Vector3(alvo.transform.position.x , transform.position.y , transform.position.z)  , Time.deltaTime * VelCam);
            }else
            {
            transform.position = (alvo.transform.position.x > MaxDis.x) ? Vector3.Lerp(transform.position,new Vector3(MaxDis.x , transform.position.y , transform.position.z)  , Time.deltaTime * VelCam) : transform.position;;
            transform.position = (alvo.transform.position.x < MinDis.x) ? Vector3.Lerp(transform.position,new Vector3( MinDis.x , transform.position.y , transform.position.z)  , Time.deltaTime * VelCam) : transform.position;
            }
            
            //y
            if(MaxDis.y == 0 && MinDis.y == 0 || alvo.transform.position.y < MaxDis.y && alvo.transform.position.y > MinDis.y)
            {
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x , alvo.transform.position.y , transform.position.z)  , Time.deltaTime * VelCam);
            }else
            {
            transform.position = (alvo.transform.position.y > MaxDis.y) ? Vector3.Lerp(transform.position,new Vector3(transform.position.x , MaxDis.y , transform.position.z)  , Time.deltaTime * VelCam) : transform.position;
            transform.position = (alvo.transform.position.y < MinDis.y) ? Vector3.Lerp(transform.position,new Vector3(transform.position.x , MinDis.y , transform.position.z)  , Time.deltaTime * VelCam) : transform.position;
            }  
    }
}
