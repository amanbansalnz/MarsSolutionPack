using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Steps
{
    public class ProfileTabPageSteps : BaseSetup

    {
        private ProfilePageTabsComponents profilePageTabsComponents;

        public ProfileTabPageSteps()
        {

            profilePageTabsComponents = new ProfilePageTabsComponents();
        }
        public void clickLangaugesTab()
        {
            profilePageTabsComponents.clickLangaugesTab();
        }

        public void clickSkillsTab()
        {
            profilePageTabsComponents.clickSkillsTab();
        }

        public void clickProfileUserNameButton()

        {
            profilePageTabsComponents.clickUserNameButton();
        }

        public void clickAvailabilityTimePencilIcon()
        {
            profilePageTabsComponents.clickAvailabilityPencilIcon();
        }
        public void clickHoursPenilIcon()
        {
            profilePageTabsComponents.clickHoursWeekPencilIcon();
        }
        public void clickTargetPencilIcon()
        {
            profilePageTabsComponents.clickEarnTargetPencilIcon();
        }
        public void clickShareSkill()
        {
            profilePageTabsComponents.clickShareSkillButton();
        }
        public void clickUpdateShareSkillIcon()
        {
            profilePageTabsComponents.clickupdateShareSkill();
        }

        public void clickSearchSkillIcon()
        {
            profilePageTabsComponents.clickSearchIcon();
        }
        public void clickNotificationmenu()
        {
            profilePageTabsComponents.clickNotificationTab();
        }

        public void clickonDashboard()
        {
            profilePageTabsComponents.clickDashboardTab();

        }

    }
}