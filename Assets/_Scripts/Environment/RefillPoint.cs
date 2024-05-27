using UnityEngine;
using static ConditionPrimaryNeeds;

public class RefillPoint: MonoBehaviour
{
    [SerializeField]
    private DisplayingResourceQuantity _displayingResourceQuantity;
    public enum RefillState
    {
        RefillThirst,
        RefillHunger,
        RefillPain,
        RefillSleep,
        RefillBreeding
    }

    [SerializeField]
    private RefillState MyRefillState;

    public string characterTag = "Player";
    [SerializeField]
    private float IncreaseAmount = 0.1f;
    [SerializeField]
    [Range(0f, 500f)]
    private float _quantityResource = 100;

    public float QuantityResource
    {
        get { return _quantityResource; }
        set
        {
            _quantityResource = value;
            _displayingResourceQuantity.ShowProductVolume();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Rigidbody noSleep = other.GetComponent<Rigidbody>();
        //noSleep.WakeUp();

        if (other.CompareTag(characterTag))
        {
            ConditionPrimaryNeeds _conditionPrimaryNeeds = other.GetComponent<ConditionPrimaryNeeds>();
            ConditionSecondaryNeeds _conditionSecondaryNeeds = other.GetComponent<ConditionSecondaryNeeds>();

            switch (MyRefillState)
            {
                case RefillState.RefillThirst:
                    if (_conditionPrimaryNeeds != null)
                    {
                        _conditionPrimaryNeeds.Thirst += IncreaseAmount;
                        QuantityResource -= IncreaseAmount;
                    }
                    break;

                case RefillState.RefillHunger:
                    if (_conditionPrimaryNeeds != null && QuantityResource > 0)
                    {
                        _conditionPrimaryNeeds.Hunger += IncreaseAmount;
                        QuantityResource -= IncreaseAmount;
                    }
                    break;

                case RefillState.RefillPain:
                    if (_conditionPrimaryNeeds != null)
                    {
                        _conditionPrimaryNeeds.Pain -= IncreaseAmount;
                    }
                    break;

                case RefillState.RefillSleep:
                    if (_conditionSecondaryNeeds != null)
                    {
                        _conditionSecondaryNeeds.Sleep += IncreaseAmount;
                    }
                    break;

                case RefillState.RefillBreeding:
                    if (_conditionSecondaryNeeds != null)
                    {
                        _conditionSecondaryNeeds.Breeding += IncreaseAmount;
                    }
                    break;
            }
        }
    }
}