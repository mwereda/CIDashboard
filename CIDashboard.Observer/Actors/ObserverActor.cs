using Akka.Actor;
using CIDashboard.Observer.Actors.Messages;

namespace CIDashboard.Observer.Actors
{
    internal class ObserverActor : ReceiveActor
    {
        private string projectObserved;
        private bool stopActor;

        internal ObserverActor()
        {
            this.stopActor = false;
            Receive<ObserveMessage>(msg =>
            {
                if (string.IsNullOrEmpty(this.projectObserved))
                {
                    this.projectObserved = msg.ProjectName;
                    while (!this.stopActor)
                    {
                    }
                }
            });

            Receive<StopObservingMessage>(msg =>
            {
                if (this.projectObserved == msg.ProjectName)
                {
                    this.stopActor = true;
                }
            });
        }
    }
}
