using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateIntegrationEmployeesService
    {
        // 创建员工
        public CreateIntegrationEmployeesResponse CreateIntegrationEmployees(string operatorUserId, Staff[] employees)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateIntegrationEmployeesRequest req = new CreateIntegrationEmployeesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 待创建员工的信息，Mobile和DisplayName必填
            req.Employees = employees;

            CreateIntegrationEmployeesResponse resp = client.CreateIntegrationEmployeesSync(req);

            return resp;
        }
    }
}