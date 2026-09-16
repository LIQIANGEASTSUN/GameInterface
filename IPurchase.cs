namespace GameInterface
{
    /// <summary>
    /// 提供支付或应用内购买服务的初始化入口。
    /// </summary>
    public interface IPurchase
    {
        /// <summary>
        /// 启动购买服务的初始化；方法返回不表示异步初始化已经完成。
        /// </summary>
        void Init();
    }
}
