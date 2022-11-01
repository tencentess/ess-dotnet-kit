using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateIntegrationEmployeesTest
    {
        public static void Main1(string[] args)
        {
            Staff employee = new Staff();
            employee.DisplayName = "***************";
            employee.Mobile = "**************";

            CreateIntegrationEmployeesService service = new CreateIntegrationEmployeesService();
            CreateIntegrationEmployeesResponse resp = service.CreateIntegrationEmployees(Configs.operatorUserId, new []{employee});

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}