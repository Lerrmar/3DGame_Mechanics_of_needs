using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static ConditionPrimaryNeeds;

public class ConditionSecondaryNeeds : MonoBehaviour
{
    public NPCMovement NPCMovementScript;
    [SerializeField]
    private ConditionPrimaryNeeds _conditionPrimaryNeeds;

    public bool SecondaryNeeds = false;
    public enum NPCSecondaryState
    {
        CalmState,
        NeedBreeding,
        NeedSleep
    }

    [SerializeField]
    private NPCSecondaryState MyNPCSecondarystatus;
    private Coroutine CoroutineSecondaryNeeds;

    [SerializeField] private float _sleep = 100f; //Сон
    [SerializeField] private float _breeding = 100f; //Развлечение
    
    private float _sleepMax;
    private float _breedingMax;

    public float lowThreshold = 30f;

    private void Start()
    {
        _breedingMax = Random.Range(80f, 150f);
        _sleepMax = Random.Range(80f, 150f);
    }
    public float Breeding
    {
        get { return _breeding; }
        set
        {
            if (value > _breedingMax) value = _breedingMax;
            if (value < 0) value = 0;
            _breeding = value;
        }
    }

    public float Sleep
    {
        get { return _sleep; }
        set
        {
            if (value > _sleepMax) value = _sleepMax;
            if (value < 0) value = 0;
            _sleep = value;
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
        Breeding -= 1f;
        Sleep -= 1f;

        if (_conditionPrimaryNeeds.PrimaryNeeds != true)
        {
            DecreaseSleep();
            DecreaseBreeding();
        }
        else TransitionCalmState();


        CheckDisease();
    }

    private void UpdateBehaviour(NPCSecondaryState status)
    {
        MyNPCSecondarystatus = status;
        if (CoroutineSecondaryNeeds != null)
        {
            StopCoroutine(CoroutineSecondaryNeeds);
        }
        switch (MyNPCSecondarystatus)
        {
            case NPCSecondaryState.NeedBreeding:
                CoroutineSecondaryNeeds = StartCoroutine(FeelsBreeding());
                break;

            case NPCSecondaryState.NeedSleep:
                CoroutineSecondaryNeeds = StartCoroutine(FeelsSleep());
                break;

            case NPCSecondaryState.CalmState:
                CoroutineSecondaryNeeds = StartCoroutine(CalmState());
                break;
        }
    }

    private void TransitionCalmState()
    {
        if (MyNPCSecondarystatus != NPCSecondaryState.CalmState)
        {
            UpdateBehaviour(NPCSecondaryState.CalmState);
        }
    }

    private void DecreaseSleep()
    {
        if (Sleep < lowThreshold && MyNPCSecondarystatus == NPCSecondaryState.CalmState && MyNPCSecondarystatus != NPCSecondaryState.NeedSleep) // убрать проверку статуса если будет терять точку
        {
            UpdateBehaviour(NPCSecondaryState.NeedSleep);
            SecondaryNeeds = true;
        }

        if (Sleep > _sleepMax * 0.9f && MyNPCSecondarystatus == NPCSecondaryState.NeedSleep)
        {
            TransitionCalmState();
            SecondaryNeeds = false;
        }
    }

    private void DecreaseBreeding()
    {
        if (Breeding < lowThreshold && MyNPCSecondarystatus == NPCSecondaryState.CalmState && MyNPCSecondarystatus != NPCSecondaryState.NeedBreeding)
        {
            UpdateBehaviour(NPCSecondaryState.NeedBreeding);
            SecondaryNeeds = true;
        }

        if (Breeding > _breedingMax * 0.9f && MyNPCSecondarystatus == NPCSecondaryState.NeedBreeding)
        {
            TransitionCalmState();
            SecondaryNeeds = false;
        }
    }

    private void CheckDisease() //Болезнь от усталости
    {
        if (_breeding <= 0f || _sleep <= 0f)
        {
            Debug.Log(gameObject.name + "Disease заболел! ");
        }
    }
    private IEnumerator FeelsSleep()
    {
        NPCMovementScript.MoveToTarget(4);
        yield return null;
    }

    private IEnumerator FeelsBreeding()
    {
        NPCMovementScript.MoveToTarget(5);
        yield return null;
    }

    private IEnumerator CalmState()
    {
        if (!_conditionPrimaryNeeds.PrimaryNeeds) NPCMovementScript.MoveToTarget(3);
        yield return null;
    }
}
