using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// VerifyPdf 合同文件验签
//
// 官网文档：https://cloud.tencent.com/document/product/1323/80797
//
// 验证合同文件
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