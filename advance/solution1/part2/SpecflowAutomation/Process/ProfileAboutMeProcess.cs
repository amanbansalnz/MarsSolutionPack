using NUnit.Framework;
using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Process
{
    public class ProfileAboutMeProcess:Base
    {
#pragma warning disable
        ProfileAboutMe profileAboutMeObj;
        ProfileMenuTab profileMenuTabObj;
        JsonHelper jsonHelperObj;
        public ProfileAboutMeProcess()
        {
            profileAboutMeObj = new ProfileAboutMe();
            profileMenuTabObj = new ProfileMenuTab();
            jsonHelperObj = new JsonHelper();
        }
        public void updateUsername(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickUserNameIcon();
            profileAboutMeObj.usernameAvailabilityDetails(data);           
        }
        public void updateAvailabilityType(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickAvailabilityEditBtn();
            profileAboutMeObj.addAndUpdateAvailabilityDetails(data);          
        }
        public void updateAvailabilityHours(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickHoursEditBtn();
            profileAboutMeObj.addAndUpdateHoursDetails(data);

        }
        public void updateAvailabilityEarnTarget(ProfileAboutMeTestModel data)
        {
            profileMenuTabObj.clickEarnTargetEditBtn();
            profileAboutMeObj.addAndUpdateEarnTargetDetails(data);
        }
    }
}
