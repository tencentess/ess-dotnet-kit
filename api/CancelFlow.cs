using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CancelFlowService
    {
        // 用于撤销签署流程
        // 适用场景：如果某个合同流程当前至少还有一方没有签署，则可通过该接口取消该合同流程。常用于合同发错、内容填错，需要及时撤销的场景。
        // 注：如果合同流程中的参与方均已签署完毕，则无法通过该接口撤销合同。
        public CancelFlowResponse CancelFlow(string operatorUserId, string flowId, string cancelMessage)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CancelFlowRequest req = new CancelFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 签署流程id
            req.FlowId = flowId;
            // 撤销原因，最长200个字符
            req.CancelMessage = cancelMessage;

            CancelFlowResponse resp = client.CancelFlowSync(req);

            return resp;
        }
    }
}