using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeIntegrationEmployeesService
    {
        // 查询员工信息
        public DescribeIntegrationEmployeesResponse DescribeIntegrationEmployees(string operatorUserId, long limit, long offset, Filter[] filters )
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeIntegrationEmployeesRequest req = new DescribeIntegrationEmployeesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            //	查询过滤实名用户，key为Status，Values为["IsVerified"]
            req.Filters = filters;

            // 返回最大数量，最大为20
            req.Limit = limit;

            // 偏移量，默认为0，最大为20000
            req.Offset = offset;

            DescribeIntegrationEmployeesResponse resp = client.DescribeIntegrationEmployeesSync(req);

            return resp;
        }
    }
}