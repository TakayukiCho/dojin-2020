using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests
{
    public class TurnMediatorTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NextPhase()
        {
            var mediator = new TurnMediator();
            Assert.AreEqual(mediator.CurrentPhase, Phase.UserWait);
            mediator.MoveNextPhase();
            Assert.AreEqual(mediator.CurrentPhase, Phase.UserAct);
            mediator.MoveNextPhase();
            Assert.AreEqual(mediator.CurrentPhase, Phase.EnemyWait);
            mediator.MoveNextPhase();
            Assert.AreEqual(mediator.CurrentPhase, Phase.EnemyAct);
            mediator.MoveNextPhase();
            Assert.AreEqual(mediator.CurrentPhase, Phase.UserWait);
            mediator.MoveNextPhase();
            Assert.AreEqual(mediator.CurrentPhase, Phase.UserAct);
        }
    }
}
