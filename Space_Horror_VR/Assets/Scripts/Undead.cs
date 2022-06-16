using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Undead : MonoBehaviour
{
    Animator anim;
    public Transform target;
    Rigidbody rb;
    public float speed, stopingDistance, rotationSpeed;
    bool founded;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        UndeadMovement();
    }
    public void UndeadMovement()
    {
        if (!founded)
        {
            Vector3 rotationPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) * rotationSpeed;
            transform.LookAt(rotationPos);
        }
        if (Vector3.Distance(transform.position, target.position) > stopingDistance)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
        }
        else if(Vector3.Distance(transform.position, target.position) <= stopingDistance && !founded)
        {
            anim.SetTrigger("Dead");
            rb.isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
            speed = 0;
            GetComponentInChildren<AudioSource>().DOFade(0, 0.3f);
            founded = true;
        }
    }
}
