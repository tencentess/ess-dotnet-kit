using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// DeleteIntegrationEmployees 移除员工
//
// 官网文档：https://cloud.tencent.com/document/product/1323/81116
//
// 移除员工
namespace api
{
    public class DeleteIntegrationEmployeesService
    {
        public DeleteIntegrationEmployeesResponse DeleteIntegrationEmployees(string operatorUserId,  Staff[] employees)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DeleteIntegrationEmployeesRequest req = new DeleteIntegrationEmployeesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 待移除员工的信息，userId和openId二选一，必填一个
            req.Employees = employees;

            DeleteIntegrationEmployeesResponse resp = client.DeleteIntegrationEmployeesSync(req);

            return resp;
        }
    }
}