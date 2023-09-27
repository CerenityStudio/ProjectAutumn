using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CerenityStudio
{
   public class MonsterScanner : MonoBehaviour
   {
      
      [HideInInspector] public bool playerInRange;
      [HideInInspector] public bool playerIsCatched;
      
      [Header("Timer")]
      public float initiateTimer;
      [HideInInspector] public float currentTimer;
      
      [Header("Events")]
      [SerializeField] private UnityEvent PlayerCatchedEvent;

      [SerializeField] private Slider scannerBar;

      private void Start()
      {
         SetTimer(initiateTimer);
      }

      private void Update()
      {
         Scanning();
      }
      
      private void OnTriggerStay2D(Collider2D col)
      {
         if (col.CompareTag("Player"))
         {
            if (!col.GetComponent<PlayerHide>().isHiding)
               playerInRange = true;
            else
            {
               playerInRange = false;
               SetTimer(initiateTimer);
            }
         }
      }

      private void OnTriggerExit2D(Collider2D col)
      {
         if (col.CompareTag("Player"))
         {
            playerInRange = false;
            SetTimer(initiateTimer);
         }
      }
      
      private void Scanning()
      {
         if (playerInRange)
         {
            currentTimer -= Time.deltaTime;
            scannerBar.gameObject.SetActive(true);
            scannerBar.maxValue = initiateTimer;
            scannerBar.value += Time.deltaTime;
         }
         else
         {
            scannerBar.gameObject.SetActive(false);
            scannerBar.value = 0;
         }

         if (currentTimer <= 0)
         {
            PlayerCatched();
            playerIsCatched = true;
            playerInRange = false;
            SetTimer(initiateTimer);
         }
         
      }

      private void PlayerCatched()
      {
         // when player get catched by monster
         PlayerCatchedEvent?.Invoke();
      }

      void SetTimer(float time)
      {
         currentTimer = time;
      }

      
      // debug only
      public void GetPlayer()
      {
         Debug.Log("Get Player");
      }
   }
   
}
