using System;
using UnityEngine;

namespace CreateWithCode.Unit3
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int StaticB = Animator.StringToHash("Static_b");
        private static readonly int SpeedF = Animator.StringToHash("Speed_f");
        private static readonly int JumpTrigger = Animator.StringToHash("Jump_trig");

        private bool _isRuning;
        private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");
        private static readonly int DeathB = Animator.StringToHash("Death_b");

        private const float RepositionSpeed = 5f;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_isRuning && transform.position.x > double.Epsilon)
            {
                transform.Translate(Vector3.left * (Time.deltaTime * RepositionSpeed), Space.World);
            }
        }

        public void ChangeToRunAnimation()
        {
            _isRuning = true;
            _animator.SetBool(StaticB, true);
            _animator.SetFloat(SpeedF, 0.6f);
            _animator.Play("Run_Static");
        }

        public void ChangeToJumpAnimation()
        {
            _isRuning = false;
            _animator.SetTrigger(JumpTrigger);
        }

        public void ChangeToDeathAnimation()
        {
            _animator.SetInteger(DeathTypeINT, 1);
            _animator.SetBool(DeathB, true);
        }
    }
}