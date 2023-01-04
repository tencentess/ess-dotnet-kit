using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询出证报告调用样例
namespace api
{
    public class DescribeFlowEvidenceReportTest
    {
        public static void Main1(string[] args)
        {
            string reportId = "********************************";

            DescribeFlowEvidenceReportService service = new DescribeFlowEvidenceReportService();
            DescribeFlowEvidenceReportResponse resp = service.DescribeFlowEvidenceReport(Configs.operatorUserId, reportId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}