using System.Collections;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private GameObject _scythe;

    private Animator _animator;

    public bool CanUse { get; private set; }

    private void Awake()
    {
        _scythe ??= GetComponentInChildren<Scythe>(true).transform.parent.gameObject;
        _animator = GetComponentInChildren<Animator>();
        CanUse = true;
    }

    public void HarvestWheat()
    {
        CanUse = false;
        _scythe.SetActive(true);
        _animator.SetBool("Harvest", true);
        StartCoroutine(EndHarvest());
    }

    private IEnumerator EndHarvest()
    {
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).IsName("Harvest"));
        var currentAnimation = _animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(currentAnimation.length / currentAnimation.speed);
        _animator.SetBool("Harvest", false);
        _scythe.SetActive(false);
        CanUse = true;
    }
}
