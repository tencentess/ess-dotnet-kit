using api;
using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

/**
 * 查询集团企业列表
 * <p>
 * 官网文档：https://cloud.tencent.com/document/product/1323/86114
 * <p>
 * 此API接口用户查询加入集团的成员企业
 */
namespace group
{
    public class GroupDescribeOrganizationGroupOrganizationsService
    {
        public DescribeOrganizationGroupOrganizationsResponse DescribeOrganizationGroupOrganizations(string operatorUserId, ulong limit, ulong offset)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeOrganizationGroupOrganizationsRequest req = new DescribeOrganizationGroupOrganizationsRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.Limit = limit;
            req.Offset = offset;

            DescribeOrganizationGroupOrganizationsResponse resp = client.DescribeOrganizationGroupOrganizationsSync(req);
            return resp;
        }

    }
}