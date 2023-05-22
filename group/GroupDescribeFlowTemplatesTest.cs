using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询模板调用样例
namespace group
{
    public class GroupDescribeFlowTemplatesTest
    {
        // 查询模板调用样例
        public static void Main1(string[] args)
        {
            // 需要代发起的子企业的企业id
            string proxyOrganizationId = "*****************";
            
            string templateId = "********************************";

            GroupDescribeFlowTemplatesService service = new GroupDescribeFlowTemplatesService();
            DescribeFlowTemplatesResponse resp = service.DescribeFlowTemplates(Configs.operatorUserId, templateId, proxyOrganizationId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}