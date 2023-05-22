using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询企业印章的列表
namespace group
{
    public class GroupDescribeOrganizationSealsTest
    {
        // 查询模板调用样例
        public static void Main1(string[] args)
        {
            // 需要代发起的子企业的企业id
            string proxyOrganizationId = "*****************";
            
            long limit = 10;

            GroupDescribeOrganizationSealsService service = new GroupDescribeOrganizationSealsService();
            DescribeOrganizationSealsResponse resp = service.DescribeOrganizationSeals(Configs.operatorUserId, limit, proxyOrganizationId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}