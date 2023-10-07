using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject monsterObject;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            monsterObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        monsterObject.SetActive(false);
    }
}
