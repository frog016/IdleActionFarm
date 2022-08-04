using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheatBag : MonoBehaviour
{
    [SerializeField] private int _stackSize;
    [SerializeField] private Transform _bagTransform;

    public int StackSize => _stackSize;
    public Stack<GameObject> WheatBlocks { get; private set; }
    public UnityEvent OnBagChangedEvent { get; private set; }

    private void Awake()
    {
        WheatBlocks = new Stack<GameObject>(_stackSize);
        OnBagChangedEvent = new UnityEvent();
    }

    public bool AddWheatBlock(GameObject block)
    {
        if (WheatBlocks.Count == _stackSize)
            return false;

        var lastPosition = WheatBlocks.Count == 0 ? Vector3.zero : WheatBlocks.Peek().transform.localPosition;
        block.transform.parent = _bagTransform;
        block.transform.localPosition = lastPosition + Vector3.Scale(_bagTransform.up, block.transform.localScale);
        WheatBlocks.Push(block);
        OnBagChangedEvent.Invoke();
        return true;
    }

    public GameObject RemoveWheatBlock()
    {
        if (WheatBlocks.Count == 0)
            return null;

        var block = WheatBlocks.Pop();
        block.transform.parent = null;
        OnBagChangedEvent.Invoke();
        return block;
    }
}
