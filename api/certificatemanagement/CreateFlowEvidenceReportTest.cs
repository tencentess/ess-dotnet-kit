using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 创建并返回出证报告调用样例
namespace api
{
    public class CreateFlowEvidenceReportTest
    {
        public static void Main1(string[] args)
        {
            string flowId = "********************************";

            CreateFlowEvidenceReportService service = new CreateFlowEvidenceReportService();
            CreateFlowEvidenceReportResponse resp = service.CreateFlowEvidenceReport(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}