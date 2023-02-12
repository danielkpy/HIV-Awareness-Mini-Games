using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3f;
    public GameObject happy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Border")
        {
            ScoreText.scoreValue += 1;
            GameObject b = Instantiate(happy) as GameObject;
            b.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(b.gameObject, 0.3f);
        }
    }
}
