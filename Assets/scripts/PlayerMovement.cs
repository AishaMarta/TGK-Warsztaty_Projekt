using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    [SerializeField] private float speed;
    private float hor, vert;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        if (rb)
        {
            rb.linearVelocity = new Vector2(hor * speed * Time.deltaTime, vert * speed * Time.deltaTime);
        }

        if (hor < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    
    }

}
