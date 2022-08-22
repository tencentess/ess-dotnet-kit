using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeThirdPartyAuthCodeTest
    {
        // 通过AuthCode查询用户是否实名调用样例
        public static void Main1(string[] args)
        {
            // 电子签小程序跳转客户小程序时携带的授权查看码
            string authCode = "********************************";

            DescribeThirdPartyAuthCodeService service = new DescribeThirdPartyAuthCodeService();
            DescribeThirdPartyAuthCodeResponse resp = service.DescribeThirdPartyAuthCode(Configs.operatorUserId, authCode);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}