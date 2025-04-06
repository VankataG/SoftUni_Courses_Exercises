using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.TeamMembers
{
    public class TeamLead : TeamMember
    {
        
        public TeamLead(string name, string path) : base(name, path)
        {
            if (path != "Master")
                throw new ArgumentException($"{path} path is not valid.");
        }

        public override string ToString()
        {
            return $"{Name} ({this.GetType().Name}) - Currently working on {this.InProgress.Count} tasks.";
        }
    }
}
