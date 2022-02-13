using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Dungeon 
{

public class HitWallsSFX : MonoBehaviour
{
    [SerializeField] private MMFeedback hitWallParticlesFeedback;
    [SerializeField] private Animator wallAnim;
    [SerializeField] private Tag triggerTag;



    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.HasTag(triggerTag))
        {
            wallAnim.SetTrigger("trigger");
            //hitWallParticlesFeedback.Play( transform.position, 1);
            
        }
    }
}
}