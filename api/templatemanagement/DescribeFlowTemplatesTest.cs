using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询模板调用样例
namespace api
{
    public class DescribeFlowTemplatesTest
    {
        // 查询模板调用样例
        public static void Main1(string[] args)
        {
            string templateId = "********************************";

            DescribeFlowTemplatesService service = new DescribeFlowTemplatesService();
            DescribeFlowTemplatesResponse resp = service.DescribeFlowTemplates(Configs.operatorUserId, templateId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}