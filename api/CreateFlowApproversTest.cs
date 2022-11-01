using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowApproversTest
    {
        public static void Main1(string[] args)
        {
            string flowName = "我的第一份模版合同";
            
            // 签署流程编号
            String flowId = "*****************";

            // 补充签署人信息
            FillApproverInfo approverInfo = new FillApproverInfo();
            // 签署人来源
            // WEWORKAPP: 企业微信
            approverInfo.ApproverSource = "WEWORKAPP";
            // 签署人签署Id
            approverInfo.RecipientId = "****************";
            // 企业自定义账号Id
            // WEWORKAPP场景下指企业自有应用获取企微明文的userid
            approverInfo.CustomUserId = "***************";
            FillApproverInfo[] approvers = new FillApproverInfo[]{approverInfo};
            
            
            CreateFlowApproversService service = new CreateFlowApproversService();
            CreateFlowApproversResponse resp = service.CreateFlowApprovers(Configs.operatorUserId, flowName, approvers);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}