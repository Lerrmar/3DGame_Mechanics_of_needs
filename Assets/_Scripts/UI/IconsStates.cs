using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static RefillPoint;

public class IconsStates : MonoBehaviour
{
    [SerializeField]
    private Image _img;
    [SerializeField]
    private ConditionPrimaryNeeds _ConditionPrimaryNeeds;
    [SerializeField]
    private ConditionSecondaryNeeds _ConditionSecondaryNeeds;

    public enum ImgState
    {
        ImgThirst,
        ImgHunger,
        ImgPain,
        ImgCalmState,
        ImgSleep,
        ImgBreeding
    }

    [SerializeField]
    private ImgState SelectedImgState;

    private void Awake()
    {
        WorldTimer.OnTimerTick += UpdateTimeTick;
    }

    private void OnDisable()
    {
        WorldTimer.OnTimerTick -= UpdateTimeTick;
    }

    private void UpdateTimeTick()
    {
        switch (SelectedImgState)
        {
            case ImgState.ImgThirst:
                if (_ConditionPrimaryNeeds.Thirst < 30)
                {
                    _img.color = Color.red;
                }
                else _img.color = Color.green;
                break;

            case ImgState.ImgHunger:
                if (_ConditionPrimaryNeeds.Hunger < 30)
                {
                    _img.color = Color.red;
                }
                else _img.color = Color.green;
                break;

            case ImgState.ImgPain:
                if (_ConditionPrimaryNeeds.Pain > 80)
                {
                    _img.color = Color.red;
                }
                else _img.color = Color.green; break;

            case ImgState.ImgCalmState:
                if (_ConditionPrimaryNeeds.PrimaryNeeds)
                {
                    _img.color = Color.gray;
                }
                else _img.color = Color.blue;
                break;

            case ImgState.ImgSleep:
                if (_ConditionSecondaryNeeds.Sleep < 30)
                {
                    _img.color = Color.red;
                }
                else _img.color = Color.green;
                break;

            case ImgState.ImgBreeding:
                if (_ConditionSecondaryNeeds.Breeding < 30)
                {
                    _img.color = Color.red;
                }
                else _img.color = Color.green;
                break;
        }
    }
}
