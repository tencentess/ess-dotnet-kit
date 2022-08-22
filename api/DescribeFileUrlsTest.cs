using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFileUrlsTest
    {
        // 查询文件下载URL调用样例
        public static void Main1(string[] args)
        {
            // 业务编号，如模板编号、文档编号、印章编号
            string flowId = "********************************";

            DescribeFileUrlsService service = new DescribeFileUrlsService();
            DescribeFileUrlsResponse resp = service.DescribeFileUrls(Configs.operatorUserId, flowId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}