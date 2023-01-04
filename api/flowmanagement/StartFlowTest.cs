using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 此接口用于发起流程调用样例
namespace api
{
    public class StartFlowTest
    {
        // 此接口用于发起流程调用样例
        public static void Main1(string[] args)
        {
            // 签署流程编号，由CreateFlow接口返回
            string flowId = "********************************";

            StartFlowService service = new StartFlowService();
            StartFlowResponse resp = service.StartFlow(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}