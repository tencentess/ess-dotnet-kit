using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowEvidenceReportService
    {
        public CreateFlowEvidenceReportResponse CreateFlowEvidenceReport(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowEvidenceReportRequest req = new CreateFlowEvidenceReportRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 签署流程编号
            req.FlowId = flowId;

            CreateFlowEvidenceReportResponse resp = client.CreateFlowEvidenceReportSync(req);

            return resp;
        }
    }
}