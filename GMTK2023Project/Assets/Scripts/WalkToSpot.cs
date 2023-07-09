using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToSpot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject trigger;
    private bool moving = true;
    public Animator anim;
    public Avatar walkAvatar;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim != null)
        {
            anim.SetBool("moving", moving);
        }
        var targ = target.position;

        if (moving)
        {
            //anim.avatar = walkAvatar;
            transform.position = Vector3.MoveTowards(transform.position, targ, moveSpeed * Time.deltaTime);
        }
        else
        {
            trigger.SetActive(true);
        }
        if (transform.position == targ)
        {
            moving = false;
        }
    }
}
