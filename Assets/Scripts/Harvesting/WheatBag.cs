using System.Collections.Generic;
using UnityEngine;

public class WheatBag : MonoBehaviour
{
    [SerializeField] private int _stackSize;
    [SerializeField] private Transform _bagTransform;

    private Stack<GameObject> _wheatBlocks;

    private void Awake()
    {
        _wheatBlocks = new Stack<GameObject>(_stackSize);
    }

    public bool AddWheatBlock(GameObject block)
    {
        if (_wheatBlocks.Count == _stackSize)
            return false;

        var lastPosition = _wheatBlocks.Count == 0 ? Vector3.zero : _wheatBlocks.Peek().transform.localPosition;
        block.transform.parent = _bagTransform;
        block.transform.localPosition = lastPosition + Vector3.Scale(_bagTransform.up, block.transform.localScale);
        _wheatBlocks.Push(block);
        return true;
    }

    public GameObject RemoveWheatBlock()
    {
        if (_wheatBlocks.Count == 0)
            return null;

        var block = _wheatBlocks.Pop();
        block.transform.parent = null;
        return block;
    }
}
