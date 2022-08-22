using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFlowTemplatesService
    {
        // 查询模板
        // 适用场景：当模板较多或模板中的控件较多时，可以通过查询模板接口更方便的获取自己主体下的模板列表，以及每个模板内的控件信息。
        // 该接口常用来配合“创建电子文档”接口作为前置的接口使用。
        public DescribeFlowTemplatesResponse DescribeFlowTemplates(string operatorUserId, string templateId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFlowTemplatesRequest req = new DescribeFlowTemplatesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 需要查询的模板ID列表
            Filter filter = new Filter();
            filter.Key = "template-id";  // 查询过滤条件的Key
            filter.Values = new string[] { templateId }; // 查询过滤条件的Value列表

            // 搜索条件，具体参考Filter结构体。本接口取值：template-id：按照【 模板唯一标识 】进行过滤
            req.Filters = new Filter[] { filter };

            DescribeFlowTemplatesResponse resp = client.DescribeFlowTemplatesSync(req);
            return resp;
        }

    }
}