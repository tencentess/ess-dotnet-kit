using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 获取批量撤销签署流程链接样例
namespace api
{
    public class CreateBatchCancelFlowUrlTest
    {
        public static void Main1(string[] args)
        {
            string[] flowIds = {"****************", "****************"};
            
            CreateBatchCancelFlowUrlService service = new CreateBatchCancelFlowUrlService();
            CreateBatchCancelFlowUrlResponse resp = service.CreateBatchCancelFlowUrl(Configs.operatorUserId, flowIds);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}