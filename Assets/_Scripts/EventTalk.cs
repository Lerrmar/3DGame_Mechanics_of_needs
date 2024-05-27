using UnityEngine;
using System.Collections;

public class EventTalk : MonoBehaviour
{
    [SerializeField]
    private AudioClip EventTalkSFX;
    [SerializeField]
    private AudioSource AudioSourceEventTalk;
    [SerializeField]
    private ParticleSystem EventTalkFlash;
    [SerializeField] private bool EventBoolColl = false;
    //[SerializeField] private bool EventBoolAudio = false;
    //[SerializeField] private bool EventBoolFX = false;
    [SerializeField] private bool EventBoolSwitchOffOn = false;
    [SerializeField] private GameObject EventSwitchOn;
    [SerializeField] private GameObject EventSwitchOff;
    private bool triggerCompleted = false;

    [SerializeField]
    private int EventTime;
    [SerializeField]
    private string EventTalkTag = "Player";

    private void Start()
    {
        if (!EventBoolColl)
        {
            GarbageObject();
        }
    }
    private void OnTriggerEnter(Collider otherObject)
    {
        if (EventBoolColl && !triggerCompleted)
        {
            if (otherObject.CompareTag(EventTalkTag))
            {
                GarbageObject();
                _EventTimer();
                triggerCompleted = true;
            }
        }
    }


    public void GarbageObject()
    {
        AudioSourceEventTalk.PlayOneShot(EventTalkSFX);
        //EventTalkFlash.Play();
    }

    private void _EventTimer()
    {
        Invoke("_EventBoolSwitchOffOn", EventTime);
    }

    private void _EventBoolSwitchOffOn()
    {

        if (EventBoolSwitchOffOn)
        {
            EventSwitchOn.SetActive(true);
            EventSwitchOff.SetActive(false);
        }
    }
}