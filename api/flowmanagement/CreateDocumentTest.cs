using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateDocumentTest
    {
        // 创建电子文档调用样例
        public static void Main1(string[] args)
        {
            string flowId = "********************************";
            string templateId = "********************************";
            string fileName = "********************************";

            CreateDocumentService service = new CreateDocumentService();
            CreateDocumentResponse resp = service.CreateDocument(Configs.operatorUserId, flowId, templateId, fileName);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}