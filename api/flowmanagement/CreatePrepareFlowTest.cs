using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 创建快速发起流程调用样例
namespace api
{
    public class CreatePrepareFlowTest
    {
        public static void Main1(string[] args)
        {
            string flowName = "**************";
            string resourceId = "**************";

            // 签署流程参与者信息
            // 个人签署方
            FlowCreateApprover approver = new FlowCreateApprover();
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            approver.ApproverType = 1;
            // 本环节需要操作人的名字
            approver.ApproverName = "********************************";
            // 本环节需要操作人的手机号
            approver.ApproverMobile = "********************************";

            FlowCreateApprover[] approvers = new FlowCreateApprover[] { approver };

            CreatePrepareFlowService service = new CreatePrepareFlowService();
            CreatePrepareFlowResponse resp = service.CreatePrepareFlow(Configs.operatorUserId, flowName, resourceId, approvers);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}