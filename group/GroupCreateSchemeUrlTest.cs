using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupCreateSchemeUrlTest
    {
        // 获取小程序跳转链接调用样例
        public static void Main1(string[] args)
        {
            string proxyOrganizationId = "*****************";
            
            string flowId = "********************************";

            GroupCreateSchemeUrlService service = new GroupCreateSchemeUrlService();
            CreateSchemeUrlResponse resp = service.CreateSchemeUrl(Configs.operatorUserId, flowId, proxyOrganizationId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}