using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateConvertTaskApiTest
    {
        public static void Main1(string[] args)
        {
            string resourceId = "********************************";

            string resourceType = "********************************";

            string resourceName = "********************************";

            CreateConvertTaskApiService service = new CreateConvertTaskApiService();
            CreateConvertTaskApiResponse resp = service.CreateConvertTaskApi(Configs.operatorUserId, resourceId, resourceType, resourceName);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}