
using UnityEngine;
public class LightningBolt : CardImpl
{
    // spriteの情報と呪文の実装

    public string ImagePath()
    {
        return "Lightningbolt";
    }
    public void Cast(GameControllable gameController)
    {
        gameController.LifeChange(-3);
    }
}