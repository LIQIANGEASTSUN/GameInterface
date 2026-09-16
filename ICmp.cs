namespace GameInterface
{
    /// <summary>
    /// 提供隐私同意管理平台（CMP）的初始化入口。
    /// </summary>
    public interface ICmp
    {
        /// <summary>
        /// 启动隐私同意管理服务的初始化；方法返回不表示用户已经完成同意流程。
        /// </summary>
        void Init();
    }
}
