using UnityEngine;

public class BagStackText : ChangeableText
{
    [SerializeField] private WheatBag _bag;

    protected override void SubscribeOnTargetEvent()
    {
        ChangeValue($"{_bag.WheatBlocks.Count}/{_bag.StackSize}");
        _bag.OnBagChangedEvent.AddListener(() => ChangeValue($"{_bag.WheatBlocks.Count}/{_bag.StackSize}"));
    }
}
