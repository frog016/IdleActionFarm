using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Seller))]
public class Barn : MonoBehaviour
{
    [SerializeField] private float _flyDuration;
    [SerializeField] private float _pickUpDelay;
    [SerializeField] private Transform _salePointTransform;

    private Seller _seller;

    private void Awake()
    {
        _seller = GetComponent<Seller>();
    }

    private IEnumerator PickUpBlocks(WheatBag bag)
    {
        var block = bag.RemoveWheatBlock();
        while (block != null)
        {
            var tweener = block.transform.DOMove(_salePointTransform.position, _flyDuration);
            var deletedBlock = block;
            tweener
                .OnComplete(() =>
                {
                    _seller.ReceiveMoniesInPosition(_salePointTransform.position);
                    deletedBlock.SetActive(false);
                    Destroy(deletedBlock, 0.5f);
                    tweener.Kill();
                });
            yield return new WaitForSeconds(_pickUpDelay);
            block = bag.RemoveWheatBlock();
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        var bag = otherCollider.GetComponent<WheatBag>();
        if (bag == null)
            return;

        StartCoroutine(PickUpBlocks(bag));
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        var bag = otherCollider.GetComponent<WheatBag>();
        if (bag == null)
            return;

        StopAllCoroutines();
    }
}
