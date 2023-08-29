using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFlowInfoTest
    {
        // 查询流程摘要调用样例
        public static void Main1(string[] args)
        {
            string flowId = "********************************";

            DescribeFlowInfoService service = new DescribeFlowInfoService();
            DescribeFlowInfoResponse resp = service.DescribeFlowInfo(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}