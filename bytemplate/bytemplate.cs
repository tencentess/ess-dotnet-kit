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
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            approver.ApproverType = 1;
            // 本环节需要操作人的名字
            approver.ApproverName = name;
            // 本环节需要操作人的手机号
            approver.ApproverMobile = mobile;
            // 合同发起后是否短信通知签署方进行签署: sms--短信，none--不通知
            approver.NotifyType = "sms";

            return approver;
        }


        // 打包企业签署方参与者信息
        public static FlowCreateApprover BuildOrganizationFlowCreateApprover(string name, string mobile, string organizationName)
        {
            // 签署参与者信息
            FlowCreateApprover approver = new FlowCreateApprover();
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
            // 合同发起后是否短信通知签署方进行签署: sms--短信，none--不通知
            approver.NotifyType = "none";

            return approver;
        }

        // 打包企业静默签署方参与者信息
        public static FlowCreateApprover BuildServerSignFlowCreateApprover()
        {
            // 签署参与者信息
            FlowCreateApprover approver = new FlowCreateApprover();
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            // 这里我们设置签署方类型为企业方静默签署3，注意当类型为静默签署时，签署人会默认设置为发起方经办人
            // 静默签署时不用再传入印章信息，印章已经在模板编辑时被指定
            approver.ApproverType = 3;

            return approver;
        }
    }
}