using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateBatchCancelFlowUrlTest
    {
        public static void Main1(string[] args)
        {
            // 需要执行撤回的签署流程id数组，最多100个
            string[] flowIds = {"****************", "****************"};
            
            CreateBatchCancelFlowUrlService service = new CreateBatchCancelFlowUrlService();
            CreateBatchCancelFlowUrlResponse resp = service.CreateBatchCancelFlowUrl(Configs.operatorUserId, flowIds);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}