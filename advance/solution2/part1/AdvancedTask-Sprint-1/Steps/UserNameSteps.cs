using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Task_1.AssertHelpers;
using AventStack.ExtentReports;

namespace Advanced_Task_1.Steps
{
    public class UserNameSteps : BaseSetup
    {
        ProfileUserNameComponent ProfileUserNameComponentObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        Assertions AssertionsObj;
        public UserNameSteps()
        {
            ProfileUserNameComponentObj = new ProfileUserNameComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            AssertionsObj = new Assertions();   
        }
        public void addUserName()
        {
           
            List<UserNameModel> UserNameModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UserfirstLastName.json");
            foreach (UserNameModel username in UserNameModelList)
            {
                profileTabPageStepsObj.clickProfileUserNameButton();
                ProfileUserNameComponentObj.AddFirstLastName(username);
                AssertionsObj.AssertFirstName(username);
            }
        }
        public void AddAvailabilityTime()
        {
            List<UserNameModel> AvailabilityModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AvailabilityTime.json");
            foreach (UserNameModel availability in AvailabilityModelList)
            {
                profileTabPageStepsObj.clickAvailabilityTimePencilIcon();
                ProfileUserNameComponentObj.AddAvailability(availability);
                string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
        public void AddHoursWeek()
        {
            List<UserNameModel> HoursModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddHours.json");
            foreach (UserNameModel hours in HoursModelList)
            {
                profileTabPageStepsObj.clickHoursPenilIcon();
                ProfileUserNameComponentObj.AddHours(hours);
                string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
        public void AddEarnTarget()
        {
            List<UserNameModel> TargetModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddTarget.json");
            foreach (UserNameModel target in TargetModelList)
            {
                profileTabPageStepsObj.clickTargetPencilIcon();
                ProfileUserNameComponentObj.AddTarget(target);
                string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }

        }
    }

 }

