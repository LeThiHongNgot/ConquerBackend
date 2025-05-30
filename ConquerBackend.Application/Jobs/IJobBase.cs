namespace ConquerBackend.Domain.Jobs
{
    public interface IJobBase
    {
        ///<summary>
        ///Hàm thực thi chính của Job
        ///</summary>
        ///<param name="cancellationToken">Hỗ trợ hủy job</param>
        Task ExecuteAsync(CancellationToken cancellationToken);

    }
}
