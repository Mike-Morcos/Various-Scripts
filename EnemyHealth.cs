using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Health class maintains object health through a private variable,
//_HealthPoints, which is accessed through a C# property, HealthPoints.
//This property features both get and set accessors to return and set the
//Health variable.
//• The _HealthPoints variable is declared as SerializedField, allowing its
//value to be visible in the Inspector.This helps us see the value of the player's
//health during runtime and debug and test the effects of our code. The prefab
//variable was left as public, allowing its value to be both seen in the inspector
//and changeable from elsewhere in code if needed.
//• The Health class is an example of event-driven programming. This is
//because the class could have continually checked the status of object health
//during an Update function; checking to see whether the object had died by
//its health falling below 0. Instead, the check for death is made during the C#
//property set method.This makes sense because set is the only place where
//health will ever change.This means that Unity is saved from a lot of work in
//each frame. That's great performance saving!
//• Health class uses the SendMessage function.This function lets you call any
//other public function on any component attached to the object by specifying
//the function name as a string. In this case, a function called Die will be
//executed on every component attached to the object (if such a function
//exists). If no function of a matching name exists, then nothing happens for
//that component. This is a quick and easy way to run customized behavior
//on an object in a type-agnostic way without using any polymorphism.
//The disadvantage is that SendMessage internally uses a process called
//Reflection, which is slow and performance-prohibitive.For this reason,
//SendMessage should be used infrequently only for death events and similar
//events, but not frequently, such as every frame. More information on
//SendMessage can be found at the online Unity documentation at http://
//docs.unity3d.com/ScriptReference/GameObject.SendMessage.html.
//• When health falls below 0, triggering a death condition, the code will
//instantiate a death particle system to show an effect on death if a particle
//system is specified (more on this shortly).
public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance = null;
    private int HealthPoints = 100;
    public int damage = 25;
    // Offset to move the position of the instantiated particles.
    public Vector3 particleOffset;
    public GameObject deathparticlesprefab;
    private Transform thistransform = null;
    public GameObject Nectar;

    private void Awake()
    {
        instance = this;
        thistransform = GetComponent<Transform>();
    }
    private void Start()
    {
       
    }
    void FixedUpdate()
    {
        if (HealthPoints <= 0)
        {
            Destroy(gameObject);
            particleDeath();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // If not player then exit
        if (other.gameObject.CompareTag("Bullet"))
        {
            HealthPoints -= damage; //* Time.deltaTime;
            Debug.Log("damage");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        // If not player then exit
        if (other.gameObject.CompareTag("Bullet"))
        {
            HealthPoints -= damage; //* Time.deltaTime;
            Debug.Log("damage");
        }
    }
    public void particleDeath()
    {
        Instantiate(deathparticlesprefab, thistransform.position + particleOffset, thistransform.rotation);
        Instantiate(Nectar, thistransform.position + particleOffset, thistransform.rotation);
        
    }
    








    //public GameObject deathparticlesprefab = null;
    //private Transform thistransform = null;

    ////------------------------------
    //void start()
    //{
    //    thistransform = GetComponent<Transform>();
    //}
    ////------------------------------
    //public void FixedUpdate()
    //{
    //        if (HealthPoints <= 0)
    //        {

    //            if (deathparticlesprefab != null)
    //            {
    //                Instantiate(deathparticlesprefab, thistransform.position, thistransform.rotation);
    //                Destroy(gameObject);
    //            }
    //        }

    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // If not player then exit
    //    if (other.CompareTag("Bullet"))
    //    {
    //        HealthPoints -= damage; //* Time.deltaTime;
    //        Debug.Log("x");
    //    }
    //}
}
//------------------------------

