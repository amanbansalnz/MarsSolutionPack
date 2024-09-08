using AdvanceTaskPart1.AssertHelpers;
using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class UserDetailSteps
    {
        ProfileUserDetails userDetail;
        UserDetailAssert userDetailAssertObj;
        public UserDetailSteps()
        {
            userDetail = new ProfileUserDetails();
            userDetailAssertObj = new UserDetailAssert();
        }

        public void EnterUserDetails()
        {
            string addUserFile = "AddUserData.json";
            List<UserDetailModel> AddUserData = JsonUtil.ReadJsonData<UserDetailModel>(addUserFile);
            foreach (var item in AddUserData)
            {
                string atime = item.availableTime;
                string ahours = item.availableHours;
                string etarget = item.earnTarget;
                userDetail.editAvailableTime(atime);
                UserDetailAssert.EditUserDetailAssert();
                userDetail.editAvailableHours(ahours);
                UserDetailAssert.EditUserDetailAssert();
                userDetail.editeTarget(etarget);
                UserDetailAssert.EditUserDetailAssert();
            }
        }
    }
}
