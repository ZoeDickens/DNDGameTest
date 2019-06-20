using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject PlayerProgetilePF;
    [SerializeField] float projectileSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject progetile = Instantiate(PlayerProgetilePF, transform.position, Quaternion.identity) as GameObject;
            progetile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        }
    }

}
