using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{
    public float GrowFactor = 0.1f;
    public Sprite[] SunSprites;
    public int ChangeSpriteModulo = 2;
    public AudioClip Hit, GrowSnd;

    private int spriteSelector = 0;
    private long hitCounter = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Function.Play2DSound(Hit);
        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
            Grow();
        }
        if (other.gameObject.layer == 11)
        {
            var player = other.GetComponent<PlayerControl>();
            if (player.Dead) return;
            StartCoroutine(DoDeath(player));
        }
    }
    
    IEnumerator DoDeath(PlayerControl player)
    {
        Game.Stopwatch.Stop();
        player.OnDeath();
        Destroy(player.gameObject);
        yield return new WaitForSeconds(3.1f);
        var rules = Function.GetClassFromScene<GameRules>();
        rules.GameOver();
    }

    void ChangeSprite()
    {
        spriteSelector++;
        GetComponent<SpriteRenderer>().sprite = SunSprites[spriteSelector];
    }

    void Grow()
    {
        Function.Play2DSound(GrowSnd);
        hitCounter++;
        if (hitCounter % ChangeSpriteModulo == 0 && spriteSelector < 3) ChangeSprite();
        transform.localScale += new Vector3(GrowFactor, GrowFactor);
    }
}