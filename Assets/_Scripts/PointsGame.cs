using UnityEngine;
using UnityEngine.UI;
using YG;

public class PointsGame : MonoBehaviour
{
    [SerializeField] Text _pointText;
    private int _playerPoint;
    [SerializeField] string _nameLB = "score";

    private void OnEnable() => YandexGame.GetDataEvent += GetData;
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetData();
        }
    }

    public void PointUP(int addPoints)
    {
        _playerPoint += addPoints;
        _pointText.text = "Очки: " + _playerPoint;

        YandexGame.savesData.PlayerPointSave = _playerPoint;
        YandexGame.SaveProgress();
        YandexGame.NewLeaderboardScores(_nameLB, _playerPoint);
    }

    public void GetData()
    {
        _playerPoint = YandexGame.savesData.PlayerPointSave;
        _pointText.text = "Очки: " + _playerPoint;
    }
}
