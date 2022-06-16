using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Undead : MonoBehaviour
{
    Animator anim;
    public Transform target;
    Rigidbody rb;
    public float speed, stopingDistance, rotationSpeed;
    public static bool founded;
    public GameObject fade;
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
    private void Update()
    {
        if (founded)
        {
            StartCoroutine(GoBack());
        }
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
    IEnumerator GoBack()
    {
        GameManager.Fade(fade, 1, 1f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
        yield break;
    }
}
