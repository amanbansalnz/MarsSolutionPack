using AdvanceTask_Sprint2.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.AssertHelpers
{
    public class SkillAssertion : BaseSetup
    {
        public void AddSkillAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
        public void UpdatedSkillAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
        public void DeletedSkillAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
    }

}
