using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFlowBriefsTest
    {
        // 查询流程摘要调用样例
        public static void Main1(string[] args)
        {
            string flowId = "********************************";

            DescribeFlowBriefsService service = new DescribeFlowBriefsService();
            DescribeFlowBriefsResponse resp = service.DescribeFlowBriefs(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}