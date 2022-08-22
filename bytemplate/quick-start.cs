using System;
using System.IO;
using TencentCloud.Ess.V20201111.Models;
using api;

namespace bytemplate
{
    public class QuickStartService
    {
        public static void Main1(string[] args)
        {
            // Step 1
            // 定义合同名
            string flowName = "我的第一个合同";
            // 构造签署人
            // 此块代码中的string approvers仅用于快速发起一份合同样例，非正式对接用
            string personName = "**************"; // 个人签署方的姓名
            string personMobile = "***************"; // 个人签署方的手机号
            FlowCreateApprover[] approvers = new FlowCreateApprover[] { ByTemplateService.BuildPersonFlowCreateApprover(personName, personMobile) };

            // 如果是正式接入，需使用这里注释的$approvers。请进入BuildFlowCreateApprovers函数内查看说明，构造需要的场景参数
            // FlowCreateApprover[] approvers = ByTemplateService.BuildFlowCreateApprovers();

            // Step 2
            // 发起合同
            CreateFlowByTemplateDirectlyResponse resp = new CreateFlowByTemplateDirectlyService().CreateFlowByTemplateDirectly(Configs.operatorUserId, flowName, approvers);

            // 返回合同Id
            Console.WriteLine("您创建的合同id为：");
            Console.WriteLine(resp.FlowId);
            Console.WriteLine();
            // 返回签署的链接
            Console.WriteLine("签署链接（请在手机浏览器中打开）为：");
            Console.WriteLine(resp.SchemeUrl);
            Console.WriteLine();

            // Step 3
            // 下载合同
            DescribeFileUrlsResponse fileUrlResp = new DescribeFileUrlsService().DescribeFileUrls(Configs.operatorUserId, resp.FlowId);
            // 返回合同下载链接
            Console.WriteLine("请访问以下地址下载您的合同：");
            Console.WriteLine(fileUrlResp.FileUrls[0].Url);
            Console.WriteLine();
        }
    }
}