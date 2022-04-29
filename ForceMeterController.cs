using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForceMeterController : MonoBehaviour
{
    public enum STATE {
        IDLE,
        RUNNING,
        STOPPED
    }

    public STATE state;
    Image image;
    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
    }

    public void StartTimer() {
        state = STATE.RUNNING;
    }

    public void StopTimer() {
        state = STATE.STOPPED;
    }

    public float GetForce() {
        return image.fillAmount;
    }

    public void Reset()
    {
        state = STATE.IDLE;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == STATE.IDLE) {
            counter = 0;
            image.fillAmount = Mathf.PingPong(counter, 1);
        }

        if (state == STATE.RUNNING) {

            counter += Time.deltaTime;
            image.fillAmount = Mathf.PingPong(counter, 1);
        }

        if (state == STATE.STOPPED) {

        }
    }
}
