using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bolt : MonoBehaviour
{


    public bool Locked;
    private void Start() {
        if(Locked){
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void Select(){
         Vector3 DesireRotation=new Vector3(35,0,0);
        transform.Rotate(DesireRotation);
    }

    public void Deselect(){
        transform.rotation= Quaternion.identity;
    }

    public void Unlock(){
        Locked=false;
         transform.GetChild(1).gameObject.SetActive(false);
    }
}
