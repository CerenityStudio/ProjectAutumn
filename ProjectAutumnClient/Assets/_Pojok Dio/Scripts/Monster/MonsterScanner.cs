using UnityEngine;
using UnityEngine.Events;

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

      private void Start()
      {
         SetTimer(initiateTimer);
      }

      private void Update()
      {
         Scanning();
      }
      
      private void OnTriggerEnter2D(Collider2D col)
      {
         if (col.CompareTag("Player"))
         {
            playerInRange = true;
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
            currentTimer -= Time.deltaTime;

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
