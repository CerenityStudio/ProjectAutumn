using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScanner : MonoBehaviour
{
   private void OnTriggerStay2D(Collider2D col)
   {
      if (col.CompareTag("Player"))
      {
         Debug.Log("Get Player");
      }
   }
}
