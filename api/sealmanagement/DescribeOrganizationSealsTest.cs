using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询企业印章的列表
namespace api
{
    public class DescribeOrganizationSealsTest
    {
        // 查询模板调用样例
        public static void Main1(string[] args)
        {
            long limit = 10;

            DescribeOrganizationSealsService service = new DescribeOrganizationSealsService();
            DescribeOrganizationSealsResponse resp = service.DescribeOrganizationSeals(Configs.operatorUserId, limit);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}