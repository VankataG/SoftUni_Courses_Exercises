using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.TeamMembers
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;

        private List<string> inProgress;

        protected TeamMember(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            inProgress = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                name = value;
            }
        }
        public string Path { get; }
        public IReadOnlyCollection<string> InProgress => inProgress.AsReadOnly();

        public void WorkOnTask(string resourceName)
        {
            inProgress.Add(resourceName);
        }

        public void FinishTask(string resourceName)
        {
            inProgress.Remove(resourceName);
        }
    }
}
