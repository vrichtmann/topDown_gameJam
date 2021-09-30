using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custozimeCharacter : MonoBehaviour
{
    public int skinNr;
    public Skins[] skins;

    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("animator.runtimeAnimatorController : " + animator.runtimeAnimatorController);
        //skinChoice();
    }

    void skinChoice(){
        //if (spriteRenderer.sprite.name.Contains("link"))
        //{
        //    string spriteName = spriteRenderer.sprite.name;
        //    spriteName = spriteName.Replace("link_", "");
        //    int spriteNr = int.Parse(spriteName);
        //    Debug.Log("spriteNr : " + spriteNr);
        //    Debug.Log("spriteName : " + spriteName);
        //    spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        //}
    }
}

[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}
