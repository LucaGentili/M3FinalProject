using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private Player player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    void Update()
    {
        if (player.walking)
        {
            SetAnim();
        }
    }

    void SetAnim()
    { 
        animator.SetFloat("HSpeed", player.direction.x);
        animator.SetFloat("VSpeed", player.direction.y);
    }
}
