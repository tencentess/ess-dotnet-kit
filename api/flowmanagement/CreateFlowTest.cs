using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 创建签署流程调用样例
namespace api
{
    public class CreateFlowTest
    {
        public static void Main1(string[] args)
        {
            string flowName = "我的第一份模版合同";

            // 签署流程参与者信息
            // 个人签署方
            FlowCreateApprover approver = new FlowCreateApprover();

            approver.ApproverType = 1;

            approver.ApproverName = "********************************";

            approver.ApproverMobile = "********************************";

            FlowCreateApprover[] approvers = new FlowCreateApprover[] { approver };

            CreateFlowService service = new CreateFlowService();
            CreateFlowResponse resp = service.CreateFlow(Configs.operatorUserId, flowName, approvers);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}