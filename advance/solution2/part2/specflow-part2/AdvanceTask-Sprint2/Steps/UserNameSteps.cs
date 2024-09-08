using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_Sprint2.AssertHelpers;
using MongoDB.Bson.Serialization.IdGenerators;

namespace AdvanceTask_Sprint2.Steps
{
    public class UserNameSteps : BaseSetup
    {
        ProfileUserNameComponent ProfileUserNameComponentObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        UserNameAssertion UserNameAssertionObj;
        public UserNameSteps()
        {
            ProfileUserNameComponentObj = new ProfileUserNameComponent();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            UserNameAssertionObj = new UserNameAssertion();
        }
        public void addUserName(string UserFirtLastNameJsonPath)
        {
            List<UserNameModel> UserNameModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>(UserFirtLastNameJsonPath);
            foreach (UserNameModel username in UserNameModelList)
            {
                profileTabPageStepsObj.clickProfileUserNameButton();
                ProfileUserNameComponentObj.AddFirstLastName(username);
                UserNameAssertionObj.AssertFirstName(username);
            }
        }
        public void AddAvailabilityTime(string AvailabilityJsonPath)
        {
            List<UserNameModel> AvailabilityModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>(AvailabilityJsonPath);
            foreach (UserNameModel availability in AvailabilityModelList)
            {
                profileTabPageStepsObj.clickAvailabilityTimePencilIcon();
                ProfileUserNameComponentObj.AddAvailability(availability);
                string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
        public void AddHoursWeek(string AddHoursJsonPath)
        {
            List<UserNameModel> HoursModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>(AddHoursJsonPath);
            foreach (UserNameModel hours in HoursModelList)
            {
                profileTabPageStepsObj.clickHoursPenilIcon();
                ProfileUserNameComponentObj.AddHours(hours);
                string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
        public void AddEarnTarget(string AddTargetJsonPath)
        {
            List<UserNameModel> TargetModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>(AddTargetJsonPath);
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

