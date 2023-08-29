using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CancelFlowService
    {
        public CancelFlowResponse CancelFlow(string operatorUserId, string flowId, string cancelMessage)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CancelFlowRequest req = new CancelFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.FlowId = flowId;
            req.CancelMessage = cancelMessage;

            CancelFlowResponse resp = client.CancelFlowSync(req);

            return resp;
        }
    }
}