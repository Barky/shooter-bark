using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
   [SerializeField] private bool disableOnInteracted;

   private void OnTriggerEnter(Collider other)
   {
      if (other.transform.CompareTag("Player"))
      onInteracted();
      StartCoroutine(DisableIt());

      
   }

   IEnumerator DisableIt()
   {
      yield return new WaitForSeconds(0.5f);
      gameObject.SetActive(false);
   }

   public virtual void onInteracted()
   {
      
   }
}
