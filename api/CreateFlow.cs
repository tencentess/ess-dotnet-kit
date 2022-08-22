using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowService
    {
        public CreateFlowResponse CreateFlow(string operatorUserId, string flowName, FlowCreateApprover[] approvers)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowRequest req = new CreateFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 签署流程参与者信息
            req.Approvers = approvers;

            // 签署流程名称,最大长度200个字符
            req.FlowName = flowName;

            CreateFlowResponse resp = client.CreateFlowSync(req);

            return resp;
        }

    }
}