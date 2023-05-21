using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   [SerializeField] private player player;
   [SerializeField] private Animator anim;

    void start(){
        anim = GetComponent<Animator>();
        player = GetComponentInParent<player>();
    }
    void Update()
    {
        anim.SetBool("IsWalking",player.GetIsWalking());
    }
}
