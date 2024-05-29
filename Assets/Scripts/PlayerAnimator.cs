using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    public const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        SpriteDirectionChecker();
        animator.SetBool(IS_WALKING, player.IsWalking());
        animator.SetFloat(HORIZONTAL, player.MoveVector().x);
        animator.SetFloat(VERTICAL, player.MoveVector().y);
    }

    private void SpriteDirectionChecker()
    {
        if (player.GetLastXVector() < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
