using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class StartFlowService
    {
        public StartFlowResponse StartFlow(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            StartFlowRequest req = new StartFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.FlowId = flowId;

            StartFlowResponse resp = client.StartFlowSync(req);
            return resp;
        }

    }
}