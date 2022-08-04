using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _growUpTime;
    [SerializeField] private GameObject _wheatPrefab;
    [SerializeField] private Transform _plantedWheatTransform;

    private Vector3 _wheatSize;
    private Vector3 _wheatFieldSize;
    private HashSet<GameObject> _plantedWheat;

    private void Awake()
    {
        _plantedWheat = new HashSet<GameObject>();
        _wheatSize = _wheatPrefab.GetComponent<BoxCollider>().size;
        _wheatFieldSize = GetComponentInChildren<MeshFilter>().transform.localScale;
    }

    private void Start()
    {
        GrowWheat();
    }

    public void GrowWheat()
    {
        var startPosition = new Vector3(-_wheatFieldSize.x + _wheatSize.x, 0, _wheatFieldSize.z - _wheatSize.z) / 2;
        var position = startPosition;

        for (var x = 0; x < (int)(_wheatFieldSize.x / _wheatSize.x); x++)
        {
            for (var z = 0; z < (int)(_wheatFieldSize.z / _wheatSize.z); z++)
            {
                var wheat = Instantiate(_wheatPrefab, _plantedWheatTransform);
                wheat.transform.localPosition = position;
                wheat.GetComponent<Wheat>().OnWheatSlicedEvent.AddListener(() => DeleteWheat(wheat));
                wheat.SetActive(false);

                _plantedWheat.Add(wheat);
                position -= new Vector3(0, 0, _wheatSize.z);
            }
            startPosition += new Vector3(_wheatSize.x, 0, 0);
            position = startPosition;
        }

        StartCoroutine(EndGrowingWheat());
    }

    private void DeleteWheat(GameObject wheat)
    {
        _plantedWheat.Remove(wheat);
        if (_plantedWheat.Count == 0)
            GrowWheat();
    }

    private IEnumerator EndGrowingWheat()
    {
        yield return new WaitForSeconds(_growUpTime);

        foreach (var wheat in _plantedWheat)
            wheat.SetActive(true);
    }
}
