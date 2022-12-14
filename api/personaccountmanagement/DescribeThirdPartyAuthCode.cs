using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// DescribeThirdPartyAuthCode 通过AuthCode查询用户是否实名
//
// 官网文档：https://cloud.tencent.com/document/product/1323/70368
namespace api
{
    public class DescribeThirdPartyAuthCodeService
    {
        public DescribeThirdPartyAuthCodeResponse DescribeThirdPartyAuthCode(string operatorUserId, string templateId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeThirdPartyAuthCodeRequest req = new DescribeThirdPartyAuthCodeRequest();

            // 电子签小程序跳转客户小程序时携带的授权查看码
            req.AuthCode = "********************************";

            DescribeThirdPartyAuthCodeResponse resp = client.DescribeThirdPartyAuthCodeSync(req);
            return resp;
        }

    }
}