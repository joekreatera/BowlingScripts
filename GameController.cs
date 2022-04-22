using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BallController ball;
    public DestructableSpaceController world;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")) {
            world.DoDestroy(GetBack);
        }
    }

    public void Shoot() {
        ball.Shoot(Vector3.forward, 10000, 0);
    }


    public void GetBack() {
        Debug.Log("Get back!");
    }
}
