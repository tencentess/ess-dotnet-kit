using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreatePrepareFlowService
    {
        public CreatePrepareFlowResponse CreatePrepareFlow(string operatorUserId, string flowName, string resourceId, FlowCreateApprover[] approvers)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreatePrepareFlowRequest req = new CreatePrepareFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 签署流程参与者信息
            req.Approvers = approvers;

            req.FlowName = flowName;
            
            req.ResourceId = resourceId;

            CreatePrepareFlowResponse resp = client.CreatePrepareFlowSync(req);

            return resp;
        }

    }
}