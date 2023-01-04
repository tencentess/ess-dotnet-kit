using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询员工信息调用样例
namespace api
{
    public class DescribeIntegrationEmployeesTest
    {
        public static void Main1(string[] args)
        {
            long limit = 20;
            long offset = 0;
            Filter filter = new Filter();
            filter.Key = "Status";
            filter.Values = new []{"IsVerified"};

            DescribeIntegrationEmployeesService service = new DescribeIntegrationEmployeesService();
            DescribeIntegrationEmployeesResponse resp = service.DescribeIntegrationEmployees(Configs.operatorUserId, limit, offset, new []{filter});

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}