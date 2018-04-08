using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenpaiAI : MonoBehaviour {

    public GameObject laser;

    public GameObject hit;
    public Transform target;
    public float speed;

    public float temp;
    public float chaseRange;
    public int health;
    Rigidbody2D rgbd;

    
    void Start()
    {
        temp = speed;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rgbd = gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(DistanceAttack());
    }

   
    void FixedUpdate()
    {
        Move();

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(touch.fingerId).position)), Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("Enemy") && Input.GetTouch(touch.fingerId).phase == TouchPhase.Began)
                {
                    HitEnemey();
                    //Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    void HitEnemey()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        health = health - 1;
        Instantiate(hit, transform.position, transform.rotation);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        WrathManager.Killed += 1;
        WrathManager.fillAmountWrath += .02f;
    }

    void Move()
    {
        rgbd.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime));
    }

    

    IEnumerator DistanceAttack()
    {
        int num_lasers = 10;
        
        for (int i = 0; i < num_lasers; i++)
        {
            
            speed = temp;
            yield return new WaitForSeconds(1);
            speed = 0;
            yield return new WaitForSeconds(1);
            Instantiate(laser, this.transform.position, target.rotation);
            yield return new WaitForSeconds(3);
         
        }
    }
}
