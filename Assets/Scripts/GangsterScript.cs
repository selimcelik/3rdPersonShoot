using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangsterScript : MonoBehaviour
{
    private Animator animator;
    private float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            speed = 0;
            animator.SetBool("Death", true);

        }   
    }
}
