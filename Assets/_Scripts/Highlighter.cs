using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite HighlightSprite;

    private SpriteRenderer _renderer;
    // Start is called before the first frame update

        //Just for Demo, remove from final version
    private void OnMouseDown()
    {
        SetHighlighted();
    }
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

   public void SetHighlighted()
    {
        _renderer.sprite = HighlightSprite;
    }
    public void UnsetHighlighted()
    {
        _renderer.sprite = NormalSprite;
    }
}
