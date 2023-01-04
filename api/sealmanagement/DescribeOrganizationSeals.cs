using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// DescribeOrganizationSeals 查询企业印章的列表
//
// 官网文档：https://cloud.tencent.com/document/product/1323/82453
//
// 查询企业印章的列表，需要操作者具有查询印章权限
// 客户指定需要获取的印章数量和偏移量，数量最多100，超过100按100处理；入参InfoType控制印章是否携带授权人信息，为1则携带，为0则返回的授权人信息为空数组。接口调用成功返回印章的信息列表还有企业印章的总数。
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