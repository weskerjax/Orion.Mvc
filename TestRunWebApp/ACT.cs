using System.ComponentModel;

namespace TestRunWebApp
{
    /// <summary>
    /// Access Control Tag
    /// </summary>
    public enum ACT 
    {
        /// <summary>使用者檢視</summary>
        [Description("使用者檢視")]
        UserView,

        /// <summary>使用者編輯</summary>
        [Description("使用者編輯")]
        UserEdit,

        /// <summary>使用者權限編輯</summary>
        [Description("使用者權限編輯")]
        UserActEdit,

        /// <summary>角色檢視</summary>
        [Description("角色檢視")]
        RoleView,

        /// <summary>角色編輯</summary>
        [Description("角色編輯")]
        RoleEdit,
         

    }

}