using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnigiriPanel : MonoBehaviour
{
   public GameObject[] icons;

   // おにぎりに応じてスプライトの出し分け
   public void UpdateOnigiri(int onigiri){
       for(int i=0; i<icons.Length;i++){
           if(i<onigiri) icons[i].SetActive(true);
           else icons[i].SetActive(false);
       }
   }
}
