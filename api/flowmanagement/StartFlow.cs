using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// StartFlow 此接口用于发起流程
//
// 官网文档：https://cloud.tencent.com/document/product/1323/70357
//
// 适用场景：见创建签署流程接口。
// 注：该接口是“创建电子文档”接口的后置接口，用于激活包含完整合同信息（模板及内容信息）的流程。激活后的流程就是一份待签署的电子合同。
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

            // 签署流程编号，由CreateFlow接口返回
            req.FlowId = flowId;

            StartFlowResponse resp = client.StartFlowSync(req);
            return resp;
        }

    }
}