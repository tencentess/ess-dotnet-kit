using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

// 查询转换任务状态调用样例
namespace api
{
    public class GetTaskResultApiTest
    {
        public static void Main1(string[] args)
        {
            string taskId = "********************************";

            GetTaskResultApiService service = new GetTaskResultApiService();
            GetTaskResultApiResponse resp = service.GetTaskResultApi(Configs.operatorUserId, taskId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}