using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// CreateFlowEvidenceReport 创建并返回出证报告
//
// 官网文档：https://cloud.tencent.com/document/product/1323/79686
//
// 创建出证报告，返回报告 ID。
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