using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator animator;

    

    public float flappy = 7;
    public float g = -9.8f;
    public AudioClip fly ;
    private AudioSource audioSource;
    private Transform trans;
    private float jumpVelocity = 0;
    private float t;
    [SerializeField]
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
        audioSource.clip = fly;
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instances.B_GamePause)
            return;

        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            audioSource.Play();
            jumpVelocity = flappy;
        }

        if (isDead && trans.position.y < -2.5f)
        {
            if(!GameManager.instances.B_GamePause)
                GameManager.instances.B_GamePause = true;
            return;
        }


        t = Time.deltaTime;
        trans.position = trans.position + Vector3.up * (jumpVelocity * t + g * t * t / 2);
        jumpVelocity = jumpVelocity + g * t;

        if(jumpVelocity > 0) 
        {
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isDead = true;
            animator.SetTrigger("Dead");
            ViewManager.instances.OnSwitchView(ViewIndex.EndView);
        }
        if (collision.CompareTag("AddPointPlace"))
        {
            GameManager.instances.AddPoint();
        }
    }

    public void Restart()
    {
        trans.position = new Vector3(trans.position.x, 0, 0);
        animator.SetTrigger("Restart");
        isDead = false;
        jumpVelocity = 0;
        t = 0;
    }
        
}
