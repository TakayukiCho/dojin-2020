using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour, GameControllable
{
    public static GameManager instance = null;

    public Phase phase = Phase.UserWait;
    // Start is called before the first frame update
    public GameObject canvas;
    int life;
    public UnityEngine.UI.Text lifeLabel;
    int handCount;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        this.life = 20;
        this.handCount = 0;
        lifeLabel.text = life.ToString();
        for (int i = 0; i <= 5; i++)
        {
            DrawCard();
        }

    }
    public void LifeChange(int num)
    {
        life = life + num;
    }
    public void Update()
    {
        lifeLabel.text = life.ToString();
    }
    public void CastCard(CardImpl impl)
    {
        impl.Cast(this);
    }

    public void DrawCard()
    {
        this.handCount += 1;
        var interval = handCount * 100;
        GameObject castableCardPrefab = Instantiate((GameObject)Resources.Load("CastableCard"));
        castableCardPrefab.transform.SetParent(canvas.transform, false);
        castableCardPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300 + interval, -205);
    }
}
