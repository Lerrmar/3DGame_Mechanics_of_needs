using UnityEngine;

public class Garbage : MonoBehaviour
{
    public AudioClip GarbageSFX;
    public AudioSource AudioSourceGarbage;
    public ParticleSystem GarbageFlash;

    [SerializeField] private GameObject _disableEvent;
    [SerializeField] private GameObject _enableEvent;
    [SerializeField] private bool _nextEvent = false;

    [SerializeField] private int EventTime = 3;

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("GarbageObject"))
        {
            GarbageObject();
            Invoke("_EventBoolSwitchOffOn", EventTime);
            if (_nextEvent)
            {
                _disableEvent.SetActive(false);
                _enableEvent.SetActive(true);
            }

            Destroy(otherObject.gameObject);
        }
    }


    public void GarbageObject()
    {
        AudioSourceGarbage.PlayOneShot(GarbageSFX);
        GarbageFlash.Play();
    }

}
