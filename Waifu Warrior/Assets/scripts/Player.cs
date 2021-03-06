﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {

    public int ID;

    public Boundary boundary;

    [SerializeField]
    private int Health;
    public bool immune = false;
    public GameObject healthbar;
    Rigidbody2D rgbd;
    public SpriteRenderer image;
    

    public bool dragOn = true;

    public GameObject GameOver;

    private int CharacterSelected;

    //Player attributes
    private SpriteRenderer Shape;
    private Animator anim;
    private Transform trans;
    private CircleCollider2D camoshield;


    //Camo sprite
    public SpriteRenderer camo;
    public SpriteRenderer defaultSprite;


    private void Start()
    {
        camoshield = gameObject.GetComponent<CircleCollider2D>();
        trans = gameObject.GetComponent<Transform>();
        Shape = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        
        

        CharacterSelected = PlayerPrefs.GetInt("CharacterSelected");
        
        if(CharacterSelected != ID)
        {
            this.gameObject.SetActive(false);
        }
        healthbar = GameObject.FindWithTag("Health");
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        image = gameObject.GetComponent<SpriteRenderer>();
        camoshield.enabled = false;
    }

    public void CamoShape()
    {
        Shape.sprite = camo.sprite;
        anim.enabled = false;
        if (ID == 4)
        {
           
        }
        else
        {
            trans.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
        immune = true;
        camoshield.enabled = true;
    }

    public void DefaultShape()
    {
        camoshield.enabled = false;
        Shape.sprite = defaultSprite.sprite;
        anim.enabled = true;
        if (ID == 1)
        {
            trans.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            trans.localScale = new Vector3(0.46589f, 0.46589f, 0.46589f);
        }
        immune = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(touch.fingerId).position)), Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    OnDrag();
                }
            }
        }
        if (rgbd.position.y > boundary.yMax || rgbd.position.y < boundary.yMin) { dragOn = false; }
        else { dragOn = true; }
        
        rgbd.position = new Vector2
        (
            Mathf.Clamp(rgbd.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rgbd.position.y, boundary.yMin, boundary.yMax)
        );
    }

    void OnDrag() //OnMouseDrag
    {
        
        if (dragOn)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!immune && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Health -= 1;

            healthbar.GetComponent<HealthBar>().TakeDamage(-1);

            if (Health <= 0)
            {
                Destroy(gameObject);
                GameOver.SetActive(true);
            }
        }
    }

    

}
