using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class VerifyPdfTest
    {
        public static void Main1(string[] args)
        {
            string flowId = "********************************";

            VerifyPdfService service = new VerifyPdfService();
            VerifyPdfResponse resp = service.VerifyPdf(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}