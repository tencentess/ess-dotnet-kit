using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CancelFlowTest
    {
        public static void Main1(string[] args)
        {
            string flowId = ""********************************";
            string cancelMessage = "撤销原因";

            CancelFlowService service = new CancelFlowService();
            CancelFlowResponse resp = service.CancelFlow(Configs.operatorUserId, flowId, cancelMessage);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}