using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components
{
    public class ShareSkillPage : CommonDriver
    {
        private static IWebElement shareSkill;
        private static IWebElement title;
        private static IWebElement description;
        private static IWebElement category;
        private static IWebElement subcategory;
        private static IWebElement selectSubcategory;
        private static IWebElement tags;
        private static IReadOnlyList<IWebElement> serviceType;
        private static IReadOnlyList<IWebElement> locationType;
        private static IWebElement startDate;
        private static IWebElement endDate;
        private static IReadOnlyList<IWebElement> skillTrade;
        private static IReadOnlyList<IWebElement> active;
        private static IWebElement skillExchange;
        private static IWebElement credit;
        private static IWebElement saveButton;
        string serviceType1 = "Hourly basis service";
        string serviceType2 = "One - off service";
        string locationType1 = "On-site";
        string locationType2 = "Online";
        string SkillTrade1 = "Skill-exchange";
        string SkillTrade2 = "Credit";
        string Active1 = "Active";
        string Active2 = "Hidden";

        public void renderTitleDescComponents()
        {
            try
            {
                title = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
                description = driver.FindElement(By.Name("description"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddShareSkills(ShareSkillModel shareSkillData)
        {
            Thread.Sleep(3000);
            renderShareSkillComponent();
            shareSkill.Click();
            renderTitleDescComponents();
            title.SendKeys(shareSkillData.Title);
            description.SendKeys(shareSkillData.Description);
            renderCategoryComponents();
            category.Click();
            category.SendKeys(shareSkillData.Category);
            category.Click();
            Thread.Sleep(3000);
            renderSubCategoryComponents();
            subcategory.Click();
            subcategory.SendKeys(shareSkillData.SubCategory);
            renderTagsComponent();
            tags.Click();
            tags.SendKeys(shareSkillData.Tags);
            tags.SendKeys("\n");
            renderServLocTypeComponent();
            if (shareSkillData.ServiceType == serviceType1)
            {
                serviceType.ElementAt(0).Click();
            }
            else
            {
                serviceType.ElementAt(1).Click();
            }
            if (shareSkillData.LocationType == locationType1)
            {
                locationType.ElementAt(0).Click();
            }
            else
            {
                locationType.ElementAt(1).Click();
            }
            renderDateComponents();
            startDate.Click();
            startDate.SendKeys(shareSkillData.StartDate);
            endDate.Click();
            endDate.SendKeys(shareSkillData.EndDate);
            renderTradeActiveComponent();
            if (shareSkillData.SkillTrade == SkillTrade1)
            {
                skillTrade.ElementAt(0).Click();
                renderSkillExchangeComponent();
                skillExchange.Click();
                skillExchange.SendKeys(shareSkillData.SkillExchange);
                skillExchange.SendKeys("\n");
            }
            else
            if (shareSkillData.SkillTrade == SkillTrade2)
            {
                skillTrade.ElementAt(1).Click();
                renderSkillTradeCreditComponent();
                credit.Click();
                credit.SendKeys(shareSkillData.Credit);
            }
            renderTradeActiveComponent();
            if (shareSkillData.Active == Active1)
            {
                active.ElementAt(0).Click();
            }
            else
            {
                active.ElementAt(1).Click();
            }
            renderSaveButton();
            saveButton.Click();
            Thread.Sleep(3000);
        }
        public void renderShareSkillComponent()
        {
            try
            {
                shareSkill = driver.FindElement(By.XPath("//a[contains(text(),'Share Skill')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCategoryComponents()
        {
            try
            {
                category = driver.FindElement(By.Name("categoryId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSubCategoryComponents()
        {
            try
            {
                subcategory = driver.FindElement(By.Name("subcategoryId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderTagsComponent()
        {
            try
            {
                tags = driver.FindElement(By.CssSelector("input[placeholder='Add new tag']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderServLocTypeComponent()
        {
            try
            {
                serviceType = driver.FindElements(By.Name("serviceType"));
                locationType = driver.FindElements(By.Name("locationType"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDateComponents()
        {
            try
            {
                startDate = driver.FindElement(By.Name("startDate"));
                endDate = driver.FindElement(By.Name("endDate"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderTradeActiveComponent()
        {
            try
            {
                skillTrade = driver.FindElements(By.Name("skillTrades"));
                active = driver.FindElements(By.Name("isActive"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSkillExchangeComponent()
        {
            try
            {
                skillExchange = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSkillTradeCreditComponent()
        {
            try
            {
                credit = driver.FindElement(By.Name("charge"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSaveButton()
        {
            try
            {
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}


