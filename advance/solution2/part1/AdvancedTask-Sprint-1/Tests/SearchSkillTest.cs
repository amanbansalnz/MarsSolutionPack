using Advanced_Task_1.Pages;
using Advanced_Task_1.Steps;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Tests
{
    [TestFixture]
    public class SearchSkillTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        SearchSkillSteps SearchSkillStepsObj;
        public SearchSkillTest()
        {
        signInObj = new SignIn();
        loginPageObj = new LoginPage();
        SearchSkillStepsObj = new SearchSkillSteps();
            
        }
        [Test, Order(1), Description("Verify User able to Serach by Skill Name")]
        public void VerifySearchSkill()
        {
        signInObj.ClickSignIn();
        loginPageObj.LoginSteps();
        SearchSkillStepsObj.SearchBySkill();
        }

        [Test, Order(2), Description("Verify User able to Serach by User Name")]
        public void SearchUserTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            SearchSkillStepsObj.SearchByUserName();
        }

        [Test, Order(3), Description("Verify User able to Serach by Category")]
        public void SearchCategoryTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            SearchSkillStepsObj.SearchByCategoryclicked();
        }

        [Test, Order(4), Description("Verify User able to Serach by using Filter option")]
        public void SearchFilterTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            SearchSkillStepsObj.SearchByFilterclicked();
        }

    }
}
