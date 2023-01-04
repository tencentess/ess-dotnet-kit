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
            // 从UploadFiles接口获取到的fileId
            string fileId = "********************************";

            // 签署流程名称,最大长度200个字符
            string flowName = "我的第一份文件合同";

            // 签署参与者信息
            // 个人签署方
            ApproverInfo approver = new ApproverInfo();
            // 参与者类型：
            // 0：企业
            // 1：个人
            // 3：企业静默签署
            // 注：类型为3（企业静默签署）时，此接口会默认完成该签署方的签署。
            approver.ApproverType = 1;
            // 本环节需要操作人的名字
            approver.ApproverName = "********************************";
            // 本环节需要操作人的手机号
            approver.ApproverMobile = "********************************";

            // 签署人对应的签署控件
            Component component = new Component();
            // 参数控件Y位置，单位pt
            component.ComponentPosY = 472.78125F;
            // 参数控件X位置，单位pt
            component.ComponentPosX = 146.15625F;
            // 参数控件宽度，单位pt
            component.ComponentWidth = 112;
            // 参数控件高度，单位pt
            component.ComponentHeight = 40;
            // 控件所属文件的序号（取值为：0-N）
            component.FileIndex = 0;
            // 可选类型为：
            // SIGN_SEAL - 签署印章控件
            // SIGN_DATE - 签署日期控件
            // SIGN_SIGNATURE - 手写签名控件
            component.ComponentType = "SIGN_SIGNATURE";
            // 参数控件所在页码，取值为：1-N
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