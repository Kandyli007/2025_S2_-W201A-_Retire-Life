using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimController : MonoBehaviour
{
    Animator anim;
    PlayerMovement2D mover;
    SpriteRenderer sr;

    string current;

    void Awake()
    {
        anim = GetComponent<Animator>();
        mover = GetComponent<PlayerMovement2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 input = mover.GetInput();
        bool moving = input.sqrMagnitude > 0.001f;

        
        Vector2 dir = moving ? input : mover.Facing;

        string state;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
           
            if (dir.x > 0)
            {
                state = moving ? "Walk_Right" : "Idle_Right";
                
                sr.flipX = false; 
            }
            else
            {
                state = moving ? "Walk_Left" : "Idle_Left";
                sr.flipX = false; 
            }
        }
        else
        {
            
            if (dir.y > 0) state = moving ? "Walk_Up" : "Idle_Up";
            else state = moving ? "Walk_Down" : "Idle_Down";
        }

        PlayIfChanged(state);
        anim.speed = moving ? 1f : 1f; 
    }

    void PlayIfChanged(string state)
    {
        if (current == state) return;
        current = state;
        anim.Play(state, 0, 0f);
    }
}
