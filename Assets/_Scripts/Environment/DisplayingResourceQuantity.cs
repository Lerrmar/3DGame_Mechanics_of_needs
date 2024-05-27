using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayingResourceQuantity : MonoBehaviour
{
    [SerializeField]
    private RefillPoint _refillPoint;

    [SerializeField]
    private GameObject _fewProduct;
    [SerializeField]
    private GameObject _averageProduct;
    [SerializeField]
    private GameObject _lotProduct;

    public void ShowProductVolume()
    {
        float _qantRes = _refillPoint.QuantityResource;

        if (_qantRes >= 400) 
        {
            _fewProduct.SetActive(true);
            _averageProduct.SetActive(true);
            _lotProduct.SetActive(true);
            return;
        }
        if (_qantRes >= 200)
        {
            _fewProduct.SetActive(true);
            _averageProduct.SetActive(true);
            _lotProduct.SetActive(false);
            return;
        }
        if (_qantRes >= 100)
        {
            _fewProduct.SetActive(true);
            _averageProduct.SetActive(false);
            _lotProduct.SetActive(false);
            return;
        }
        else
        {
            DeactModels();
        }
    }

    public void DeactModels()
    {
        _fewProduct.SetActive(false);
        _averageProduct.SetActive(false);
        _lotProduct.SetActive(false);
    }
}
