using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class DescribeOrganizationGroupOrganizationsTest
    {
        // 查询集团企业列表调用样例
        public static void Main1(string[] args)
        {
            ulong limit = 10;
            ulong offset = 0;

            GroupDescribeOrganizationGroupOrganizationsService service = new GroupDescribeOrganizationGroupOrganizationsService();
            DescribeOrganizationGroupOrganizationsResponse resp = service.DescribeOrganizationGroupOrganizations(Configs.operatorUserId, limit, offset);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}