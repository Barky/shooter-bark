using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform _player;
   [SerializeField] private Vector3 offset;

   private void Update()
   {
      transform.DOLocalMove(_player.position + offset, 0.3f);
   }
}
