using UnityEngine;

namespace _Game.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationHandler : MonoBehaviour
    {
        public Animator animator => _animator;
        private Animator _animator => GetComponent<Animator>();
        
        
    }
}
