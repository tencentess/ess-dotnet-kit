using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class VerifyPdfService
    {
        // 合同文件验签
        public VerifyPdfResponse VerifyPdf(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            VerifyPdfRequest req = new VerifyPdfRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 签署流程id
            req.FlowId = flowId;
            
            VerifyPdfResponse resp = client.VerifyPdfSync(req);

            return resp;
        }
    }
}