using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized; //to ensure fixed movement
        Attack();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if(Input.GetKeyDown("space"))
        {
            if(canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);

            }

        }
    }
}
