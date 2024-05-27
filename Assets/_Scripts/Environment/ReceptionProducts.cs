using UnityEngine;

public class ReceptionProducts : MonoBehaviour
{
    [SerializeField]
    private RefillPoint _refillPoint;

    private string _water = "Water";
    private string _food = "Food";

    private string _teg;

    private enum RefillTeg
    {
        Water,
        Food
    }

    [SerializeField]
    private RefillTeg _addTeg;

    private void Start()
    {
        switch (_addTeg)
        {
            case RefillTeg.Water:
                _teg = _water;
                break;

            case RefillTeg.Food:
                _teg = _food;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_teg))
        {
            ProductValue _productValue = other.GetComponent<ProductValue>();
            _refillPoint.QuantityResource += _productValue.ValueOfTheProduct;
            Destroy(other.gameObject, 1);
        }
    }
}
