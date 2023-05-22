using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupDescribeFlowInfoTest
    {
        // 查询流程摘要调用样例
        public static void Main1(string[] args)
        {
            // 需要查询的流程ID列表
            string flowId = "********************************";
            
            // 需要代发起的子企业的企业id
            string proxyOrganizationId = "*****************";

            GroupDescribeFlowInfoService service = new GroupDescribeFlowInfoService();
            DescribeFlowInfoResponse resp = service.DescribeFlowInfo(Configs.operatorUserId, flowId, proxyOrganizationId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}