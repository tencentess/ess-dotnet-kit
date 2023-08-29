using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 补充签署流程本企业签署人信息样例
namespace api
{
    public class CreateFlowApproversTest
    {
        public static void Main1(string[] args)
        {
            string flowName = "我的第一份模板合同";
            
            String flowId = "*****************";

            FillApproverInfo approverInfo = new FillApproverInfo();

            approverInfo.ApproverSource = "WEWORKAPP";

            approverInfo.RecipientId = "****************";

            approverInfo.CustomUserId = "***************";
            FillApproverInfo[] approvers = new FillApproverInfo[]{approverInfo};
            
            
            CreateFlowApproversService service = new CreateFlowApproversService();
            CreateFlowApproversResponse resp = service.CreateFlowApprovers(Configs.operatorUserId, flowName, approvers);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}