using TencentCloud.Ess.V20201111.Models;

namespace bytemplate
{
    public class ByTemplateService
    {
        // 构造签署人 - 以B2B2C为例, 实际请根据自己的场景构造签署方
        public static FlowCreateApprover[] BuildFlowCreateApprovers()
        {
            // 个人签署方构造参数
            string personName = "********************";
            string personMobile = "********************";

            // 企业签署方构造参数
            string organizationName = "********************";
            string organizationUserName = "********************";
            string organizationUserMobile = "********************";

            FlowCreateApprover[] approvers = new FlowCreateApprover[]{BuildServerSignFlowCreateApprover(), // 发起方企业静默签署
                BuildOrganizationFlowCreateApprover(organizationUserName, organizationUserMobile, organizationName), // 另一家企业签署方
                BuildPersonFlowCreateApprover(personName,personMobile) // 个人签署方
            };

            return approvers;
        }


        // 打包个人签署方参与者信息
        public static FlowCreateApprover BuildPersonFlowCreateApprover(string name, string mobile)
        {
            // 签署参与者信息
            // 个人签署方
            FlowCreateApprover approver = new FlowCreateApprover();

            approver.ApproverType = 1;

            approver.ApproverName = name;

            approver.ApproverMobile = mobile;

            approver.NotifyType = "sms";

            return approver;
        }


        // 打包企业签署方参与者信息
        public static FlowCreateApprover BuildOrganizationFlowCreateApprover(string name, string mobile, string organizationName)
        {
            // 签署参与者信息
            FlowCreateApprover approver = new FlowCreateApprover();

            approver.ApproverType = 0;

            approver.ApproverName = name;

            approver.ApproverMobile = mobile;

            approver.OrganizationName = organizationName;

            approver.NotifyType = "none";

            return approver;
        }

        // 打包企业静默签署方参与者信息
        public static FlowCreateApprover BuildServerSignFlowCreateApprover()
        {
            // 签署参与者信息
            FlowCreateApprover approver = new FlowCreateApprover();

            approver.ApproverType = 3;

            return approver;
        }
    }
}