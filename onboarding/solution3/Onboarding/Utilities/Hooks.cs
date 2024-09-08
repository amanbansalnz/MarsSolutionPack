using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ProjectMars.Utilities;

namespace ProjectMars.Utilities
{
    [Binding]
    public sealed class hooks : CommonDriver
    {
        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            Initialize();
        }


        [AfterScenario]
        public void AfterSCenario()
        {
            Close();
        }
    }
}
