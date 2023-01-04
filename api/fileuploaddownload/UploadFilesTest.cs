using System;
using System.IO;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class UploadFilesTest
    {
        // 上传文件调用样例
        public static void Main1(string[] args)
        {
            // 上传文件在本地的地址
            String filePath = "../testdata/test.pdf";
            Byte[] bytes = File.ReadAllBytes(filePath);
            String base64Str = Convert.ToBase64String(bytes);

            string fileName = "test.pdf";

            UploadFilesService service = new UploadFilesService();
            UploadFilesResponse resp = service.UploadFiles(Configs.operatorUserId, base64Str, fileName);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}