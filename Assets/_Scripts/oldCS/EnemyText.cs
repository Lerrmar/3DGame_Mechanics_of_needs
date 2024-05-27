using UnityEngine;

public class EnemyText : MonoBehaviour
{
    public DynamicTextData textData;
    [SerializeField] private string _hitTeg = "GarbageObject";
    [SerializeField] private int _damage = 10;
    [SerializeField] private PointsGame _pointsGame;

    public static DynamicTextData defaultData;
    public static GameObject canvasPrefab;
    public static Transform mainCamera;

    [SerializeField] private DynamicTextData _defaultData;
    [SerializeField] private GameObject _canvasPrefab;
    [SerializeField] private ObjectPickup _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<ObjectPickup>();
        defaultData = _defaultData;
        mainCamera = _mainCamera.transform;
        canvasPrefab = _canvasPrefab;
        _pointsGame = FindObjectOfType<PointsGame>();
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag(_hitTeg))
        {
            Vector3 destination = otherObject.transform.position;
            destination.x += (Random.value - 0.5f);
            destination.y += Random.value;
            destination.z += (Random.value - 0.5f);

            int RandDamage = Random.Range(10, 30) + _damage;
            _pointsGame.PointUP(RandDamage);
            CreateText(destination, RandDamage.ToString(), textData);
        }
    }

    public static void CreateText(Vector3 position, string text, DynamicTextData data)
    {
        GameObject newText = Instantiate(canvasPrefab, position, Quaternion.identity);
        newText.transform.GetComponent<DynamicText>().Initialise(text, data);
    }
}
