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
        // 可选参数传入请参考：https://cloud.tencent.com/document/api/1323/70369#ApproverInfo
        public static ApproverInfo BuildPersonApprover(string name, string mobile)
        {
            // 签署参与者信息
            ApproverInfo approver = new ApproverInfo();
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            // 企业签署方
            approver.ApproverType = 1;
            // 本环节需要操作人的名字
            approver.ApproverName = name;
            // 本环节需要操作人的手机号
            approver.ApproverMobile = mobile;
            // sms--短信，none--不通知
            approver.NotifyType = "sms";

            // 签署人签署控件配置，数组传入，可以设置多个。此处我们为签署方设置一个手写签名控件。
            // 可选参数传入请参考：https://cloud.tencent.com/document/api/1323/70369#Component
            Component component = BuildComponent(146.15625F, 472.78125F, 112, 40, 0, "SIGN_SIGNATURE", 1, "");

            // 本环节操作人签署控件配置，为企业静默签署时，只允许类型为SIGN_SEAL（印章）和SIGN_DATE（日期）控件，并且传入印章编号
            approver.SignComponents = new Component[] { component };

            return approver;
        }

        // 打包企业签署方参与者信息
        public static ApproverInfo BuildOrganizationApprover(string name, string mobile, string organizationName)
        {
            // 签署参与者信息
            ApproverInfo approver = new ApproverInfo();
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            // 企业签署方
            approver.ApproverType = 0;
            // 本环节需要操作人的名字
            approver.ApproverName = name;
            // 本环节需要操作人的手机号
            approver.ApproverMobile = mobile;
            // 本环节需要企业操作人的企业名称
            approver.OrganizationName = organizationName;
            // sms--短信，none--不通知
            approver.NotifyType = "none";
            
            // 签署人对应的签署控件
            Component component = BuildComponent(246.15625F, 472.78125F, 112, 40, 0, "SIGN_SEAL", 1, "");

            // 本环节操作人签署控件配置，为企业静默签署时，只允许类型为SIGN_SEAL（印章）和SIGN_DATE（日期）控件，并且传入印章编号
            approver.SignComponents = new Component[] { component };

            return approver;
        }

        // 打包企业静默签署方参与者信息
        public static ApproverInfo BuildServerSignApprover()
        {
            // 签署参与者信息
            ApproverInfo approver = new ApproverInfo();
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            // 这里我们设置签署方类型为企业方静默签署3，注意当类型为静默签署时，签署人会默认设置为发起方经办人
            approver.ApproverType = 3;

            // 模板控件信息
            // 签署人对应的签署控件
            Component component = BuildComponent(346.15625F, 472.78125F, 112, 40, 0, "SIGN_SEAL", 1, Configs.serverSignSealId);

            // 本环节操作人签署控件配置，为企业静默签署时，只允许类型为SIGN_SEAL（印章）和SIGN_DATE（日期）控件，并且传入印章编号
            approver.SignComponents = new Component[] { component };

            return approver;
        }

        // 构建（签署）控件信息
        public static Component BuildComponent(float componentPosX, float componentPosY, float componentWidth, float componentHeight,
                                long fileIndex, string componentType, long componentPage, string componentValue)
        {
            // 签署人对应的签署控件
            Component component = new Component();
            // 以下4项确定了控件在pdf文件内的坐标位置以及长宽信息
            // 如何确定坐标请参考： https://doc.weixin.qq.com/doc/w3_AKgAhgboACgsf9NKAVqSOKVIkQ0vQ?scode=AJEAIQdfAAoz9916DRAKgAhgboACg
            // 参数控件X位置，单位pt
            component.ComponentPosX = componentPosX;
            // 参数控件Y位置，单位pt
            component.ComponentPosY = componentPosY;
            // 参数控件宽度，单位pt
            component.ComponentWidth = componentWidth;
            // 参数控件高度，单位pt
            component.ComponentHeight = componentHeight;
            // 控件所属文件的序号，目前均为单文件发起，所以我们固定填入序号0
            component.FileIndex = fileIndex;
            // 如果是 Component 控件类型，则可选类型为：
            // TEXT - 单行文本
            // MULTI_LINE_TEXT - 多行文本
            // CHECK_BOX - 勾选框
            // ATTACHMENT - 附件
            // SELECTOR - 选择器
            // 如果是 SignComponent 控件类型，则可选类型为：
            // SIGN_SEAL - 签署印章控件，静默签署时需要传入印章id作为ComponentValue
            // SIGN_DATE - 签署日期控件
            // SIGN_SIGNATURE - 手写签名控件，静默签署时不能使用
            component.ComponentType = componentType;
            // 控件所在的页面数，从1开始取值，请勿超出pdf文件的最大页数
            component.ComponentPage = componentPage;
            // 自动签署所对应的印章Id
            component.ComponentValue = componentValue;

            return component;
        }
    }
}