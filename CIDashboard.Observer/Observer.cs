using Akka.Actor;
using CIDashboard.Observer.Actors;
using Conditions.Guards;

namespace CIDashboard.Observer
{
    public class Observer
    {
        private readonly IDataRefresher dataRefresher;
        private ActorSystem actorSystem;

        public Observer(IDataRefresher dataRefresher)
        {
            Check.If(dataRefresher).IsNotNull();

            this.dataRefresher = dataRefresher;
        }

        public void Initialize()
        {
            this.actorSystem = ActorSystem.Create("CIDashboard");
            var projectProviderActor = this.actorSystem.ActorOf(Props.Create<ProjectProviderActor>());
        }
    }
}
