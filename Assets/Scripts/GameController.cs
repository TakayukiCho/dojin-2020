using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, GameControllable
{
    // Start is called before the first frame update
    int life;
    public UnityEngine.UI.Text lifeLabel;

    void Start()
    {
        life = 20;
        lifeLabel.text = life.ToString();

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
}
