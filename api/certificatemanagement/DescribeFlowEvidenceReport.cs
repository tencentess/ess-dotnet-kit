using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// DescribeFlowEvidenceReport 查询出证报告
//
// 官网文档：https://cloud.tencent.com/document/product/1323/83441
//
// 查询出证报告，返回报告 URL。
namespace api
{
    public class DescribeFlowEvidenceReportService
    {
        public DescribeFlowEvidenceReportResponse DescribeFlowEvidenceReport(string operatorUserId, string reportId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFlowEvidenceReportRequest req = new DescribeFlowEvidenceReportRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 出证报告编号
            req.ReportId = reportId;

            DescribeFlowEvidenceReportResponse resp = client.DescribeFlowEvidenceReportSync(req);

            return resp;
        }
    }
}