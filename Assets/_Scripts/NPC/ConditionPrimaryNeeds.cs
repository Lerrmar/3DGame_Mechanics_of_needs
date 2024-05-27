//using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConditionPrimaryNeeds : MonoBehaviour
{
    public NPCMovement NPCMovementScript;

    public bool PrimaryNeeds = false;
    public enum NPCState
    {
        CalmState,
        FeelsThirst,
        FeelsHunger,
        FeelsPain
    }

    [SerializeField]
    private NPCState MyNPCstatus;
    public Coroutine CoroutinePrimaryNeeds;

    [SerializeField]    private float _pain = 0; //Боль
    [SerializeField]    private float _thirst = 100f; //Жажда
    [SerializeField]    private float _hunger = 100f; //Голод
    
    private float _painMax;
    private float _thirstMax;
    private float _hungerMax;

    //public Image PainIndicator;
    //public Image ThirstIndicator;
    //public Image HungerIndicator;

    public float lowThreshold = 30f;
    public float lowPainThreshold = 30f;

    private void Start()
    {
        _thirstMax = Random.Range(80f, 150f);
        _hungerMax = Random.Range(80f, 150f);
        _painMax = Random.Range(80f, 150f);
    }
    public float Thirst
    {
        get { return _thirst; }
        set
        {
            if (value > _thirstMax) value = _thirstMax;
            if (value < 0) value = 0;
            _thirst = value;
        }
    }

    public float Hunger
    {
        get { return _hunger; }
        set
        {
            if (value > _hungerMax) value = _hungerMax;
            if (value < 0) value = 0;
            _hunger = value;
        }
    }

    public float Pain
    {
        get { return _pain; }
        set
        {
            if (value > _painMax) value = _painMax;
            if (value < 0) value = 0;
            _pain = value;
        }
    }

    private void Awake()
    {
        WorldTimer.OnTimerTick += UpdateCharacteristics;
    }

    private void OnDisable()
    {
        WorldTimer.OnTimerTick -= UpdateCharacteristics;
    }

    private void UpdateCharacteristics()
    {
        DecreasePain(); //Паника
        DecreaseThirst(); //Жажда
        DecreaseHunger(); //Голод

        CheckGameOver();
    }

    private void UpdateBehaviour(NPCState status)
    {
        MyNPCstatus = status;
        if (CoroutinePrimaryNeeds != null)
        {
            StopCoroutine(CoroutinePrimaryNeeds);
        }
        switch (MyNPCstatus)
        {
            case NPCState.FeelsThirst:
                CoroutinePrimaryNeeds = StartCoroutine(FeelsThirst());
                break;

            case NPCState.FeelsHunger:
                CoroutinePrimaryNeeds = StartCoroutine(FeelsHunger());
                break;
            case NPCState.FeelsPain:
                CoroutinePrimaryNeeds = StartCoroutine(FeelsPain());
                break;
            case NPCState.CalmState:
                CoroutinePrimaryNeeds = StartCoroutine(CalmState());
                break;
        }
    }

    private void TransitionCalmState()
    {
        if (MyNPCstatus != NPCState.CalmState)// && PrimaryNeeds != true)
        {
            UpdateBehaviour(NPCState.CalmState);
        }
    }

    private void DecreaseThirst()
    {
        Thirst -= 2f;
        //ThirstIndicator.fillAmount = Thirst / 100f;

        if (Thirst < lowThreshold && MyNPCstatus == NPCState.CalmState && MyNPCstatus != NPCState.FeelsThirst)
        {
            UpdateBehaviour(NPCState.FeelsThirst);
            PrimaryNeeds = true;
        }

        if (Thirst > _thirstMax * 0.9f && MyNPCstatus == NPCState.FeelsThirst)
        {
            TransitionCalmState();
            PrimaryNeeds = false;
        }
    }

    private void DecreaseHunger()
    {
        Hunger -= 1f;
        //HungerIndicator.fillAmount = Hunger / 100f;

        if (Hunger < lowThreshold && MyNPCstatus == NPCState.CalmState && MyNPCstatus != NPCState.FeelsHunger)
        {
            UpdateBehaviour(NPCState.FeelsHunger);
            PrimaryNeeds = true;
        }

        if (Hunger > _hungerMax * 0.9f && MyNPCstatus == NPCState.FeelsHunger)
        {
            TransitionCalmState();
            PrimaryNeeds = false;
        }
    }

    private void DecreasePain()
    {
        if (Pain > 0) Pain -= 3f;
        
        //PainIndicator.fillAmount = Pain / 100f;

        if (Pain > _painMax * 0.5f && MyNPCstatus != NPCState.FeelsPain)
        {
            UpdateBehaviour(NPCState.FeelsPain);
            PrimaryNeeds = true;
        }

        if (Pain < lowThreshold * 0.3f && MyNPCstatus == NPCState.FeelsPain)
        {
            TransitionCalmState();
            PrimaryNeeds = false;
        }
    }

    private void CheckGameOver()
    {
        if (_pain >= _painMax || _thirst <= 0f || _hunger <= 0f)
        {
            Debug.Log("Game Over!");
        }
    }

    private IEnumerator FeelsThirst()
    {
        NPCMovementScript.MoveToTarget(0);
        yield return null;
    }

    private IEnumerator FeelsHunger()
    {
        NPCMovementScript.MoveToTarget(1);
        yield return null;
    }

    private IEnumerator FeelsPain()
    {
        NPCMovementScript.MoveToTarget(2);
        yield return null;
    }

    private IEnumerator CalmState()
    {
        NPCMovementScript.MoveToTarget(3);
        yield return null;
    }
}