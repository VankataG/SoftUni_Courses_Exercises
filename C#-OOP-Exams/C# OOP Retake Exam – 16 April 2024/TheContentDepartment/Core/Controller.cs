using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Models.Resources;
using TheContentDepartment.Models.TeamMembers;
using TheContentDepartment.Repositories;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private ResourceRepository resources = new ResourceRepository();
        private MemberRepository members = new MemberRepository();
        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
                return $"{memberType} is not a valid member type.";

            if (members.Models.Any(m => m.Path == path))
                return $"Position is occupied.";

            if (members.Models.Any(m => m.Name == memberName))
                return $"{memberName} has already joined the team.";

            ITeamMember newMember = CreateNewMember(memberType, memberName, path);
            members.Add(newMember);
            return $"{memberName} has joined the team. Welcome!";
        }


        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != nameof(Exam) && resourceType != nameof(Presentation) &&
                resourceType != nameof(Workshop))
                return $"{resourceType} type is not handled by Content Department.";

            ITeamMember member = members.FirstOrDefault(m => m.Path == path);
            if (member == null)
                return $"No content member is able to create the {resourceName} resource.";

            if (member.InProgress.Contains(resourceName))
                return $"The {resourceName} resource is being created.";

            IResource resource = CreateNewResource(resourceType, resourceName, member.Name);
            member.WorkOnTask(resourceName);
            resources.Add(resource);
            return $"{member.Name} created {resourceType} - {resourceName}.";
        }

        public string LogTesting(string memberName)
        {
            ITeamMember member = members.TakeOne(memberName);
            if (member == null)
                return $"Provide the correct member name.";

            IResource resource = (IResource)resources.Models
                .Where(r => !r.IsTested && r.Creator == memberName)
                .OrderBy(r => r.Priority)
                .FirstOrDefault();

            if (resource == null) 
                return $"{memberName} has no resources for testing.";

            ITeamMember lead = members.First(m => m.Path == "Master");
            member.FinishTask(resource.Name);
            lead.WorkOnTask(resource.Name);

            resource.Test();
            return $"{resource.Name} is tested and ready for approval.";

        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.First(r => r.Name == resourceName);
            if (!resource.IsTested)
                return $"{resourceName} cannot be approved without being tested.";

            ITeamMember lead = members.First(m => m.Path == "Master");

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                lead.FinishTask(resourceName);
                return $"{lead.Name} approved {resourceName}.";
            }

            resource.Test();
            return $"{lead.Name} returned {resourceName} for a re-test.";
        }

        public string DepartmentReport()  
        {
            ITeamMember lead = members.First(m => m.Path == "Master");
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Finished Tasks:");
            foreach (IResource resource in resources.Where(r => r.IsApproved))
            {
                sb.AppendLine($"--{resource}");
            }

            sb.AppendLine("Team Report:");
            sb.AppendLine($"--{lead}");
            foreach (ITeamMember teamMember in members.Where(m => m.GetType().Name != nameof(TeamLead)))
            {
                sb.AppendLine(teamMember.ToString());
            }

            return sb.ToString().Trim();
        }

        private static ITeamMember CreateNewMember(string memberType, string memberName, string path)
        {
            return memberType switch
            {
                "TeamLead" => new TeamLead(memberName, path),
                "ContentMember" => new ContentMember(memberName, path),
                _ => throw new ArgumentException("Invalid member type.")
            };
        }

        private static IResource CreateNewResource(string resourceType, string resourceName, string creator)
        {
            return resourceType switch
            {
                "Exam" => new Exam(resourceName, creator),
                "Workshop" => new Workshop(resourceName, creator),
                "Presentation" => new Presentation(resourceName, creator),
                _ => throw new ArgumentException("Invalid resource type.")
            };
        }
    }
}

