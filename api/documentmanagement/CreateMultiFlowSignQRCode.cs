using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateMultiFlowSignQRCodeService
    {
        public CreateMultiFlowSignQRCodeResponse CreateMultiFlowSignQRCode(string operatorUserId, string templateId, string flowName)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateMultiFlowSignQRCodeRequest req = new CreateMultiFlowSignQRCodeRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.TemplateId = templateId;

            req.FlowName = flowName;

            CreateMultiFlowSignQRCodeResponse resp = client.CreateMultiFlowSignQRCodeSync(req);
            return resp;
        }

    }
}