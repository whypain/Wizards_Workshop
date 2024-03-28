using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientContainer : MonoBehaviour
{
    [SerializeField] GameObject _ingredientPrefab;
    [SerializeField] Image _ingredientImage;
    [SerializeField] TextMeshProUGUI _ingredientText;

    private SpriteRenderer ingredientSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ingredientSpriteRenderer = _ingredientPrefab.GetComponent<SpriteRenderer>();
        _ingredientImage.sprite = ingredientSpriteRenderer.sprite;

        _ingredientText.text = _ingredientPrefab.GetComponent<TetrisBlock>().displayName;
    }

    public void SpawnIngredientTetris()
    {

        GameObject spawnedIngredientTetris = Instantiate(_ingredientPrefab, Cursor.worldMousePos, Quaternion.identity);
        spawnedIngredientTetris.GetComponent<TetrisBlock>().moveable = true;

    }
}
