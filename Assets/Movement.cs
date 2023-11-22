using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;
    private float horizontal;
    [SerializeField]int moveSpeed = 1;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(horizontal * moveSpeed * 10 * Time.deltaTime, playerRB.velocity.y);
        Flip();
    }

    void Flip()
    {
        if (isFacingRight && horizontal < 0/*facing right, movement is negative*/ || !isFacingRight && horizontal > 0)
        {
            //swaps the facing right variable to match the oreintation of the character
            isFacingRight = !isFacingRight;
            //establishing localScale and setting it to the transforms position
            Vector3 localScale = transform.localScale;
            //will flip the localScale variable
            localScale.x *= -1;
            //setting the position of the transform to the recently flipped localScale
            transform.localScale = localScale;
        }
    }
}
