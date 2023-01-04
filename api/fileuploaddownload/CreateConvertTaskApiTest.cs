using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateConvertTaskApiTest
    {
        public static void Main1(string[] args)
        {
            // 资源Id，由UploadFiles接口返回
            string resourceId = "********************************";
            // 资源类型，2-doc 3-docx
            string resourceType = "********************************";
            // 资源名称
            string resourceName = "********************************";

            CreateConvertTaskApiService service = new CreateConvertTaskApiService();
            CreateConvertTaskApiResponse resp = service.CreateConvertTaskApi(Configs.operatorUserId, resourceId, resourceType, resourceName);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}