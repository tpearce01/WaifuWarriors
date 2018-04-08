using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    
    public GameObject hit;
	public Transform target;
	public float speed;
    private float permanentSpeed;
	public float chaseRange;
    public int health;
    Rigidbody2D rgbd;
 
	
	void Start () {
        permanentSpeed = speed;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
        rgbd = gameObject.GetComponent<Rigidbody2D>();
	}

 
    void FixedUpdate() {
        Move();
        
    }

	void Update () {
        if(Input.touchCount > 0)
        {
            //foreach(Touch touch in Input.touches)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
                if(hit.collider != null && hit.collider.CompareTag("Enemy") && Input.GetTouch(0).phase == TouchPhase.Began)
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
    void Move() {
        rgbd.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime));
    }
}
