using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 移除员工调用样例
namespace api
{
    public class DeleteIntegrationEmployeesTest
    {
        public static void Main1(string[] args)
        {
            Staff employee = new Staff();
            employee.UserId = "***************";

            DeleteIntegrationEmployeesService service = new DeleteIntegrationEmployeesService();
            DeleteIntegrationEmployeesResponse resp = service.DeleteIntegrationEmployees(Configs.operatorUserId, new []{employee});

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}