using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AdvanceTask_Sprint2.Utilities
{
    [Binding]
    public sealed class Hooks : BaseSetup
    {
        [BeforeScenario]
        public void BeforeScenario()
        {

            ExtentReportsSetup();
            SetupActions();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                TearDownActions(); // Perform cleanup actions
            }
            finally
            {
                Close(); // Close WebDriver
            }
        }
    }
}
    
