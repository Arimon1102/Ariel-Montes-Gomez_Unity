using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Bullet : MonoBehaviour
{
    public float vel;
    public float tiempoVida;
    public GameObject player;
    Transform transformPlayer;
    SpriteRenderer renderPlayer;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        transformPlayer = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(transformPlayer.localScale.x>0)
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            transformPlayer.localScale = new Vector3(1, 1, 1);
        }
        else if (transformPlayer.localScale.x<0)
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            transformPlayer.localScale = new Vector3(-1, 1, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, tiempoVida);
    }
}
