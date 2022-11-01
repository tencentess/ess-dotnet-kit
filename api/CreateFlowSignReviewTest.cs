using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowSignReviewTest
    {
        public static void Main1(string[] args)
        {
            // 签署流程编号，由CreateFlow/CreateFlowByFiles接口返回
            string flowId = "****************";

            // 企业内部审核结果
            // PASS: 通过
            // REJECT: 拒绝
            string reviewType = "****************";

            // 审核原因
            // 当ReviewType 是REJECT 时此字段必填,字符串长度不超过200
            string reviewMessage = "****************";

            CreateFlowSignReviewService service = new CreateFlowSignReviewService();
            CreateFlowSignReviewResponse resp = service.CreateFlowSignReview(Configs.operatorUserId, flowId, reviewType, reviewMessage);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}