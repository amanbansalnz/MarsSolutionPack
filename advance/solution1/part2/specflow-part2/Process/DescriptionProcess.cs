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
    public class DescriptionProcess:Base
    {
#pragma warning disable
        DescriptionComponent descriptionComponentObj;
        ProfileMenuTab profileMenuTabObj;

        public DescriptionProcess()
        {
            descriptionComponentObj = new DescriptionComponent();
            profileMenuTabObj = new ProfileMenuTab();
        }
        public void AddedDescription(DescriptionTestModel data)
        {
            profileMenuTabObj.clickDescriptionEditIcon();
            descriptionComponentObj.addAndUpdateDescriptionDetails(data);
        }
        public void UpdatedDescription(DescriptionTestModel data)
        {
            profileMenuTabObj.clickDescriptionEditIcon();
            descriptionComponentObj.addAndUpdateDescriptionDetails(data);
        }

        public void NegativeDescri(DescriptionTestModel data)
        {
            profileMenuTabObj.clickDescriptionEditIcon();
            descriptionComponentObj.addNegativedes(data);
        }
        public void deleteDescription(DescriptionTestModel data)
        {
            profileMenuTabObj.clickDescriptionEditIcon();
            descriptionComponentObj.deleteDesc(data);
        }

    }
}
    

