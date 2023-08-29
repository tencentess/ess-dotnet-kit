using TencentCloud.Ess.V20201111.Models;

namespace byfile
{
    public class ByFileService
    {
        // 构造签署人 - 以B2B2C为例, 实际请根据自己的场景构造签署方、控件
        public static ApproverInfo[] BuildApprovers()
        {
            // 个人签署方构造参数
            string personName = "********************";
            string personMobile = "********************";

            // 企业签署方构造参数
            string organizationName = "********************";
            string organizationUserName = "********************";
            string organizationUserMobile = "********************";

            ApproverInfo[] approvers = new ApproverInfo[]{BuildServerSignApprover(), // 发起方企业静默签署，此处需要在config.cs中设置一个持有的印章值serverSignSealId
                BuildOrganizationApprover(organizationUserName, organizationUserMobile, organizationName), // 另一家企业签署方
                BuildPersonApprover(personName, personMobile) // 个人签署方
            };
            return approvers;
        }

        // 打包个人签署方参与者信息
        public static ApproverInfo BuildPersonApprover(string name, string mobile)
        {
            // 签署参与者信息
            ApproverInfo approver = new ApproverInfo();
            approver.ApproverType = 1;

            approver.ApproverName = name;

            approver.ApproverMobile = mobile;

            approver.NotifyType = "sms";

            // 签署人签署控件配置，数组传入，可以设置多个。此处我们为签署方设置一个手写签名控件。
            Component component = BuildComponent(146.15625F, 472.78125F, 112, 40, 0, "SIGN_SIGNATURE", 1, "");

            approver.SignComponents = new Component[] { component };

            return approver;
        }

        // 打包企业签署方参与者信息
        public static ApproverInfo BuildOrganizationApprover(string name, string mobile, string organizationName)
        {
            // 签署参与者信息
            ApproverInfo approver = new ApproverInfo();

            approver.ApproverType = 0;

            approver.ApproverName = name;

            approver.ApproverMobile = mobile;

            approver.OrganizationName = organizationName;

            approver.NotifyType = "none";
            
            // 签署人对应的签署控件
            Component component = BuildComponent(246.15625F, 472.78125F, 112, 40, 0, "SIGN_SEAL", 1, "");

            approver.SignComponents = new Component[] { component };

            return approver;
        }

        // 打包企业静默签署方参与者信息
        public static ApproverInfo BuildServerSignApprover()
        {
            // 签署参与者信息
            ApproverInfo approver = new ApproverInfo();

            approver.ApproverType = 3;

            // 模板控件信息
            // 签署人对应的签署控件
            Component component = BuildComponent(346.15625F, 472.78125F, 112, 40, 0, "SIGN_SEAL", 1, Configs.serverSignSealId);

            approver.SignComponents = new Component[] { component };

            return approver;
        }

        // 构建（签署）控件信息
        public static Component BuildComponent(float componentPosX, float componentPosY, float componentWidth, float componentHeight,
                                long fileIndex, string componentType, long componentPage, string componentValue)
        {
            // 签署人对应的签署控件
            Component component = new Component();

            component.ComponentPosX = componentPosX;

            component.ComponentPosY = componentPosY;

            component.ComponentWidth = componentWidth;

            component.ComponentHeight = componentHeight;

            component.FileIndex = fileIndex;

            component.ComponentType = componentType;

            component.ComponentPage = componentPage;

            component.ComponentValue = componentValue;

            return component;
        }
    }
}