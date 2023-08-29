using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupCreateFlowByFilesTest
    {
        // 通过上传后的pdf资源编号来创建待签署的合同流程调用样例
        public static void Main1(string[] args)
        {
            // 需要代发起的子企业的企业id
            string proxyOrganizationId = "*****************";
            
            string fileId = "********************************";

            string flowName = "我的第一份文件合同";

            // 签署参与者信息
            // 个人签署方
            ApproverInfo approver = new ApproverInfo();

            approver.ApproverType = 1;

            approver.ApproverName = "********************************";

            approver.ApproverMobile = "********************************";

            // 签署人对应的签署控件
            Component component = new Component();

            component.ComponentPosY = 472.78125F;

            component.ComponentPosX = 146.15625F;

            component.ComponentWidth = 112;

            component.ComponentHeight = 40;

            component.FileIndex = 0;

            component.ComponentType = "SIGN_SIGNATURE";

            component.ComponentPage = 1;

            approver.SignComponents = new Component[] { component };

            ApproverInfo[] approvers = new ApproverInfo[] { approver };

            GroupCreateFlowByFilesService service = new GroupCreateFlowByFilesService();
            CreateFlowByFilesResponse resp = service.CreateFlowByFiles(Configs.operatorUserId, flowName, approvers, fileId, proxyOrganizationId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}