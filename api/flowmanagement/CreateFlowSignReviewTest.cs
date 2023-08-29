using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 提交企业签署流程审批结果样例
namespace api
{
    public class CreateFlowSignReviewTest
    {
        public static void Main1(string[] args)
        {
            // 签署流程编号，由CreateFlow/CreateFlowByFiles接口返回
            string flowId = "****************";

            string reviewType = "****************";

            string reviewMessage = "****************";

            CreateFlowSignReviewService service = new CreateFlowSignReviewService();
            CreateFlowSignReviewResponse resp = service.CreateFlowSignReview(Configs.operatorUserId, flowId, reviewType, reviewMessage);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}