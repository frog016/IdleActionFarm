using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Wheat : MonoBehaviour
{
    [SerializeField] private GameObject _wheatBlockPrefab;

    public UnityEvent OnWheatSlicedEvent { get; private set; }

    private void Awake()
    {
        OnWheatSlicedEvent = new UnityEvent();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Scythe>() == null)
            return;

        Instantiate(_wheatBlockPrefab, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        OnWheatSlicedEvent.Invoke();
        Destroy(gameObject);
    }
}
