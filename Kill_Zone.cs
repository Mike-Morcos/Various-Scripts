using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Zone : MonoBehaviour
{
//  The KillZone class is responsible for continually damaging the player's
//  health when a GameObject, tagged as Player, enters and remains within
//  a Trigger Volume.

//  The Damage variable encodes the reduction of health for the player
//  by adjusting the public static property, Health, which is part of the
//  PlayerControl class. When Health reaches 0, the player will be destroyed.
   
    //--------------------------------
    //Amount to damage player per second
    public int Damage = 100;
    //--------------------------------
    //  The OnTriggerStay2D function is called automatically by Unity, once
    //  per frame, when an object with RigidBody enters and remains within a
    //  Trigger Volume.Thus, when a physics object enters the Kill Zone Trigger,
    //  the OnTriggerStay2D function will be called as frequently as the Update
    //  function.More information on OnTriggerStay2D can be found at the online
    //  Unity documentation at http://docs.unity3d.com/ScriptReference/
    //  MonoBehaviour.OnTriggerStay2D.html.
    void OnTriggerStay2D(Collider2D other)
    {
        // If not player then exit
        if (!other.CompareTag("Player")) return;
        // Damage player by subtracting health and knocking the player back
        if (Player_Movement_2.PlayerInstance != null)
            Player_Movement_2.PlayerInstance._Health -= Damage;
       //Player_Movement_2.Health -= Damage;
            Player_Movement_2.PlayerInstance.KnockBack();
    }
    //--------------------------------
}
