using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Gate_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Text _gateNumberText = null;
    
    [SerializeField] private enum GateType
    {
        positiveGate,
        
        negativeGate
    }

    [SerializeField] private GateType _gateType;

    [SerializeField] private int _gateNumber;

    public int GetGateNumber()
    {
        return _gateNumber;
    }   

    void Start()
    {
        GenerateGateNumber();
    }

    
    private void GenerateGateNumber(){
        switch (_gateType)
        {
            case GateType.positiveGate :
                _gateNumber = Random.Range(1, 10);
                _gateNumberText.text = _gateNumber.ToString();
                                          break;
            
            case GateType.negativeGate :
                _gateNumber = Random.Range(-10, -1);
                _gateNumberText.text = _gateNumber.ToString();
                                          break;
        }
    }
    
}
