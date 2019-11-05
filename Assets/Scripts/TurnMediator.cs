public enum Phase
{
    UserWait,
    UserAct,
    EnemyWait,
    EnemyAct,
}

public class TurnMediator
{
    static Phase[] phaseCart = {
        Phase.UserWait,
        Phase.UserAct,
        Phase.EnemyWait,
        Phase.EnemyAct
    };
    private int currentPhaseIndex;
    // ゲーム開始時の引数をコンストラクタで処理する
    public TurnMediator()
    {
        currentPhaseIndex = 0;
    }
    public void NextPhase()
    {
        if (currentPhaseIndex == phaseCart.Length - 1)
        {
            currentPhaseIndex = 0;
            return;
        }
        currentPhaseIndex += 1;
    }

    public Phase CurrentPhase
    {
        get { return phaseCart[currentPhaseIndex]; }
    }
}
