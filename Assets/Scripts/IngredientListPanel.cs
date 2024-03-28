using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientListPanel : MonoBehaviour
{
    [SerializeField] VerticalLayoutGroup _verticalLayoutGroup;
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] float _childHeight;

    private void Start()
    {
        int childCount = transform.childCount;

        if (childCount == 0) { return; }

        int topPadding = _verticalLayoutGroup.padding.top;
        int bottomPadding = _verticalLayoutGroup.padding.bottom;
        float spacing = _verticalLayoutGroup.spacing;

        float finalHeight = 0;

        // calculate spacing with total spacing = `childCount - 1` x `spacing`
        finalHeight += spacing * (childCount - 1);

        // calculate sum height of the children
        finalHeight += _childHeight * childCount;

        // calculate top and bottom padding
        finalHeight += topPadding + bottomPadding;

        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, finalHeight);
    }
}
