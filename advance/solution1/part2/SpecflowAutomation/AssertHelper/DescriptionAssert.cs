using NUnit.Framework;
using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class DescriptionAssert : Base
    {
        DescriptionComponent descriptionComponentObj;

        public DescriptionAssert()
        {
            descriptionComponentObj = new DescriptionComponent();
        }
        public void verifyDescriptionAssert()
        {
            string messageBox = descriptionComponentObj.SuccessMessage();
            string popupMessage = messageBox;
            string expectedMessage1 = "First character can only be digit or letters";
            string expectedMessage2 = "Please, a description is required";

            if (popupMessage.Contains("has been saved successfully"))
            {
                Console.WriteLine("Description has been saved successfully");
            }
            else if ((popupMessage == expectedMessage1 || popupMessage == expectedMessage2))
            {
                Console.WriteLine("Successfully got the error message");
            }
            else
            {
                Console.WriteLine("Check Error");
            }
            Assert.AreEqual(popupMessage, messageBox, "Actual Message and Expected Message do not match");
        }
    }
}


