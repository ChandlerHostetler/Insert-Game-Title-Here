using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float speed = 0.1f;
    public float coolDownTime;
    private float nextFiretime;
    public List<GameObject> bullets;
    public bool fired = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
        shoot();
        
        if (fired == true) {
            fire(speed);
            StartCoroutine(waitForReload());

        }

    }
    public IEnumerator waitForReload() {
        yield return new WaitForSeconds(1);
        speed = 0.01f;
        fired = false;
    }

    public void shoot()
    {

        Vector2 playerPos = player.transform.position;
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        Quaternion q = Quaternion.FromToRotation(Vector2.up, screenPos - playerPos);
        if (Input.GetMouseButton(0) && speed <= 10)
        {
            speed += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
            {
                if (transform.localScale.x < 0 && nextFiretime < Time.time)
                {
                    nextFiretime = Time.time + coolDownTime;
                    bullet = Instantiate(bullet, new Vector2(playerPos.x, playerPos.y), q);
                    bullets.Add(bullet);

                }
                else if (nextFiretime < Time.time)
                {
                    nextFiretime = Time.time + coolDownTime;
                    bullet = Instantiate(bullet, new Vector2(playerPos.x, playerPos.y), q);
                    bullets.Add(bullet);

                }
            fired = true;
        }
        
        
    }

    public void fire(float speed)
    {
        //bullet.GetComponent<Rigidbody2D>().AddForce(bullet.GetComponent<Rigidbody2D>().transform.up * speed);
        foreach (GameObject bullet in bullets)
        {
            //bullet.transform.Translate(Vector2.up * Time.deltaTime * speed);//this works?!?!?!?!?!? i feel like i tried it before but it didnt work
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.GetComponent<Rigidbody2D>().transform.up * speed);
            StartCoroutine(waitForReload());
            

        }
    }
}