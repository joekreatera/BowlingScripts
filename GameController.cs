using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public BallController ball;
    public DestructableSpaceController world;
    Vector3 direction;
    public Slider slider;
    public GameObject cameraController;

    public Image leftTorque;
    public Image rightTorque;
    float torque;


    int state = 0;
    int shots = 0;
    public GameObject playAgainPanel;

    public ForceMeterController force;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.forward;

    }
    public void PlayAgain() {
        SceneManager.LoadScene(0);
    }

    public void Rotate(int side) {
        Vector3 rot = cameraController.transform.eulerAngles;
        if (rot.y + side * 3 >= 360 - 30) {
            rot.y = rot.y + side * 3;
        }

        if (rot.y + side * 3 <= 30)
        {
            rot.y = rot.y + side * 3;
        }


        cameraController.transform.eulerAngles = rot;

    }

    public void SetLane() {
        Vector3 p = ball.gameObject.transform.position;
        p.x = slider.value * 2;
        ball.gameObject.transform.position = p;
        cameraController.transform.position = p;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTorque(int torqueDiff) {

        torque = Mathf.Max(Mathf.Min(1, torque + torqueDiff * .1f), -1);
        leftTorque.fillAmount = Mathf.Abs(Mathf.Min(torque, 0));
        rightTorque.fillAmount = (Mathf.Max(torque, 0));
    }

    int hasShot = 0;
    public void BallHasFallen() {
        shots += 1;
        hasShot += 1;
        Debug.Log(hasShot);
        if (shots == 1 && hasShot == 2)
        {
            world.DoDestroy(GetBack);
            hasShot++;
        }
        else {
            if(hasShot == 2 )
             playAgainPanel.SetActive(true);
        }
        Debug.Log("Finished");
    }


    public void Shoot() {

        if (state == 0)
        {
            force.StartTimer();
            state += 1;
        }
        else if (state == 1) {
            force.StopTimer();
            float f = force.GetForce() ;
            Vector3 dir = cameraController.transform.TransformDirection(Vector3.forward);
            ball.Shoot(dir, 5000 + f*10000, -torque*1000);
            state += 1;
            hasShot = 1;
        }


    }

    public void ResetAll() {
        Rigidbody bb = ball.gameObject.GetComponent<Rigidbody>();
        bb.velocity = Vector3.zero;
        bb.angularVelocity = Vector3.zero;
        bb.transform.position = new Vector3(0, 1.176f, -3.133f);

        cameraController.transform.position = new Vector3(0, 0.5f, -3.133f);
        cameraController.transform.rotation = Quaternion.identity;
        state = 0;
        torque = 0;
        force.Reset();
        SetTorque(0);
        slider.value = 0;
        hasShot = 0;
    }

    public void GetBack() {
        Debug.Log("Get back!");

        Invoke("ResetAll", 2);
    }
}
