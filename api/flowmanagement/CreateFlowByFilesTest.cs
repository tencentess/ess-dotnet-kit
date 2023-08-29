using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowByFilesTest
    {
        // 通过上传后的pdf资源编号来创建待签署的合同流程调用样例
        public static void Main1(string[] args)
        {
            string fileId = "********************************";

            string flowName = "我的第一份文件合同";

            // 签署参与者信息
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

            // 本环节操作人签署控件配置，为企业静默签署时，只允许类型为SIGN_SEAL（印章）和SIGN_DATE（日期）控件，并且传入印章编号
            approver.SignComponents = new Component[] { component };

            ApproverInfo[] approvers = new ApproverInfo[] { approver };

            CreateFlowByFilesService service = new CreateFlowByFilesService();
            CreateFlowByFilesResponse resp = service.CreateFlowByFiles(Configs.operatorUserId, flowName, approvers, fileId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}