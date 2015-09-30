using System.Collections.Generic;
using System.IO;
using Akka.Actor;
using CIDashboard.Observer.Actors.Messages;
using Conditions;
using Conditions.Guards;
using Newtonsoft.Json;

namespace CIDashboard.Observer.Actors
{
    internal class ProjectProviderActor : UntypedActor
    {
        private readonly ActorSystem actorSystem;

        internal ProjectProviderActor(ActorSystem actorSystem)
        {
            Check.If(actorSystem).IsNotNull();

            this.actorSystem = actorSystem;
        }
        
        protected override void OnReceive(object message)
        {
            var filePath = message as string;
            if (filePath.IsNotNullOrEmpty())
            {
                var fileContent = ReadFile(filePath);
                var projects = JsonConvert.DeserializeObject<List<string>>(fileContent);

                projects.ForEach(x =>
                {
                    var observerActor = this.actorSystem.ActorOf(Props.Create<ObserverActor>());
                    observerActor.Tell(new ObserveMessage(x), Self);
                });
            }
            else
            {
                Unhandled(message);
            }
        }

        private string ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }

            return string.Empty;
        }
    }
}