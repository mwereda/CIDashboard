using Conditions.Guards;

namespace CIDashboard.Observer.Actors.Messages
{
    internal class ObserveMessage
    {
        internal string ProjectName
        {
            get; private set;
        }

        internal ObserveMessage(string projectName)
        {
            Check.If(projectName).IsNotNullOrEmpty();

            ProjectName = projectName;
        }
    }
}
