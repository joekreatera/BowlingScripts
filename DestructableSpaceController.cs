using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestructableSpaceController : MonoBehaviour
{
    public GameObject topRock;
    public GameObject debris;
    public UnityEvent destroyTerminated;
    public ParticleSystem particles;
    public float timer = 0;

    public enum STATE {
        NORMAL_SHOT,
        DESTROY_PHASE_1,
        DESTROY_PHASE_2,
        DESTROY_PHASE_3,
        DESTROY_PHASE_4,
        FINISHED
    };

    public STATE state;

    // Start is called before the first frame update
    void Start()
    {
        state = STATE.NORMAL_SHOT;
        debris.SetActive(false);
    }

    public void DoDestroy(UnityAction callback) {
        destroyTerminated.AddListener(callback);
        state = STATE.DESTROY_PHASE_1;
    }

    public void DoPhase3() {
        /// unleash particles!
        debris.SetActive(true);
        Camera.main.SendMessage("DoShake");
        // tell camera to shake
        state = STATE.DESTROY_PHASE_3;
        particles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == STATE.DESTROY_PHASE_1) {
            topRock.GetComponent<Rigidbody>().isKinematic = false;
            state = STATE.DESTROY_PHASE_2;
        }

        if (state == STATE.DESTROY_PHASE_2)
        {
            
        }

        if (state == STATE.DESTROY_PHASE_3) {
              
            destroyTerminated.Invoke();
            destroyTerminated.RemoveAllListeners();
            state = STATE.FINISHED;
        }
    }
}
