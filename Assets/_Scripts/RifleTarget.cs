using UnityEngine;

public class RifleTarget : MonoBehaviour
{
    private int health = 0;
    private int maxHealth = 20;

    [SerializeField] private GameObject _disableEvent;
    [SerializeField] private GameObject _enableEvent;
    [SerializeField] private bool _nextEvent = false;
    public int Health
    {
        get { return health; }
        set
        {
            health += value;

            if (health > maxHealth)
            {
                if (_nextEvent)
                {
                     _disableEvent.SetActive(false);
                     _enableEvent.SetActive(true);
                }

                Destroy(gameObject);
            }
        }
    }
}
