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

            approver.ApproverType = 1;

            approver.ApproverName = "********************************";

            approver.ApproverMobile = "********************************";

            FlowCreateApprover[] approvers = new FlowCreateApprover[] { approver };

            CreatePrepareFlowService service = new CreatePrepareFlowService();
            CreatePrepareFlowResponse resp = service.CreatePrepareFlow(Configs.operatorUserId, flowName, resourceId, approvers);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}