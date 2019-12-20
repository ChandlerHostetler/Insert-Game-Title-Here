using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public BoxCollider2D playerCollider;
    public Rigidbody2D playerRigid;
    public float speed;
    public float jumpHeight;
    public int i = 0;
    public static Vector2 playerpos;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerpos = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 playerHorizontal = new Vector2(moveHorizontal, 0);
        Vector2 playerVertical = new Vector2(0, 5);
        Vector2 internalPlayerpos = player.transform.position;

        player.transform.Translate(playerHorizontal * speed*Time.deltaTime); //Movmement left to right

        jump(playerVertical);


    }

    public void jump(Vector2 playerVertical) {

        if (Input.GetKeyDown(KeyCode.Space) && i < 1)
        {
            i += 1;
            playerRigid.AddForceAtPosition(playerVertical * jumpHeight, player.transform.position);


        }
        if (playerCollider.IsTouching(ground.GetComponentInParent<BoxCollider2D>()))
        {
            Debug.Log(playerCollider.IsTouching(ground.GetComponentInParent<BoxCollider2D>()));
            i = 0;
        }
    }
}
