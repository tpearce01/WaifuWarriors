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
    KillCounter KilledText;
 
	
	void Start () {
        KilledText = FindObjectOfType<KillCounter>();
        permanentSpeed = speed;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
        rgbd = gameObject.GetComponent<Rigidbody2D>();
	}

 
    void FixedUpdate() {
        Move();
        
    }

	void Update () {
        
        /*    
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                if (Input.GetTouch(i).phase == TouchPhase.Stationary)
                {
                    test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                    RaycastHit2D hitr = Physics2D.Raycast(test, (Input.GetTouch(i).position));
                
                    if (hitr.collider && hitr.collider.tag == "Enemy" && hit.transform.gameObject)
                    {
                    Debug.Log(hitr.transform.position);
                        HitEnemy();
                    }
                }
            }
        
        
        
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(touch.fingerId).position)), Vector2.zero);
                if(hit.collider != null && hit.collider.CompareTag("Enemy") && Input.GetTouch(touch.fingerId).phase == TouchPhase.Began)
                {
                    if (hit.transform.gameObject)
                    {
                        HitEnemey();
                    }
                    
                }
            }
        }*/
    }
       

    void OnMouseDown()
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
        KilledText.Size();
        WrathManager.fillAmountWrath += .02f;
    }
    void Move() {
        rgbd.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime));
    }
}
