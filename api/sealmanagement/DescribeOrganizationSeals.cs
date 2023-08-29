using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeOrganizationSealsService
    {
        public DescribeOrganizationSealsResponse DescribeOrganizationSeals(string operatorUserId, long limit)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeOrganizationSealsRequest req = new DescribeOrganizationSealsRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;
            
            req.Limit = limit;

            DescribeOrganizationSealsResponse resp = client.DescribeOrganizationSealsSync(req);
            return resp;
        }

    }
}