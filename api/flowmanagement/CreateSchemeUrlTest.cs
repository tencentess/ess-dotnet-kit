using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateSchemeUrlTest
    {
        // 获取小程序跳转链接调用样例
        public static void Main1(string[] args)
        {
            string flowId = "********************************";

            CreateSchemeUrlService service = new CreateSchemeUrlService();
            CreateSchemeUrlResponse resp = service.CreateSchemeUrl(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}