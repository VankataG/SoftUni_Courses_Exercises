using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.Resources
{
    public abstract class Resource : IResource
    {
        private string name;

        protected Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator = creator;
            Priority = priority;
            IsTested = false;
            IsApproved = false;
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
        public string Creator { get; }
        public int Priority { get; }
        public bool IsTested { get; private set; }
        public bool IsApproved { get; private set; }
        public void Test()
        {
            IsTested = !IsTested;
        }

        public void Approve()
        {
            IsApproved = true;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}), Created By: {Creator}";
        }
    }
}
