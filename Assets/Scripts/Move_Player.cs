using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    public Joystick joystick;

    public Transform BulletSpawner;

    public GameObject BulletPrefab;

    public float salto;

    public int limiteSaltos = 1;

    private int numeroSaltos = 0;

    public float vel; //Declarar una variable vel de tipo punto flotante

    Rigidbody2D rb; //Declarar una variable rb de tipo Cuerpo Rigido 2D

    bool voltearPlayer = true;

    SpriteRenderer miPlayer;

    Animator animatorPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        miPlayer = GetComponent<SpriteRenderer>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Jump") > 0)
        if (joystick.Vertical> 0.2f)
        {
            if (numeroSaltos < limiteSaltos)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0, salto), ForceMode2D.Impulse);
                numeroSaltos++;
            }
        }
        //float mh = Input.GetAxis("Horizontal");
        float mh = joystick.Horizontal;
        if (mh>0.2f && !voltearPlayer)
        {
            voltear();
        }
        else if (mh<-0.2f && voltearPlayer)

        {
            voltear();
        }
        rb.velocity = new Vector2(mh * vel, rb.velocity.y);
        animatorPlayer.SetFloat("velMov", Mathf.Abs(mh));
        //playerShooting();
    }
    void voltear()
    {
        voltearPlayer = !voltearPlayer;
        transform.localScale = new Vector3(
            -transform.localScale.x,
            transform.localScale.y,
            transform.localScale.z);
        //miPlayer.flipX = !miPlayer.flipX;
    }

    public void playerShooting()
    {
        //if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BulletPrefab, BulletSpawner.position, BulletSpawner.rotation);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            numeroSaltos = 0;
        }
    }
}