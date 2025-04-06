using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models.TeamMembers
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path) : base(name, path)
        {
            if (path != "CSharp" && path != "JavaScript" && path != "Python" && path != "Java")
                throw new ArgumentException($"{path} path is not valid.");
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {this.InProgress.Count} tasks.";
        }
    }
}
