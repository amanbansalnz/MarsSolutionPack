
using AdvanceTaskPart1.Steps;
using AdvanceTaskPart1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Tests
{
    [TestFixture]
    public class ShareSkillTest : CommonDriver
    {
        ShareSkillSteps shareSkillStepsObj;
        public ShareSkillTest()
        {
            shareSkillStepsObj = new ShareSkillSteps();
        }
        [Test, Order(1), Description("This test adds a new entry in Share Skill")]
        public void TestAddShareSkill()
        {
            shareSkillStepsObj.AddShareSkillsSteps();
        }
    }
}
