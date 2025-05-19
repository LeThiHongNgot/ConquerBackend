using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Infrastructure.Redis.Abtractions
{
    public interface IRedisService
    {
        /// <summary>
        /// Lưu một chuỗi JSON vào cache với thời gian hết hạn được chỉ định.
        /// </summary>
        /// <param name="prefix">Prefix quy định danh mục của cache.</param>
        /// <param name="key">Khóa của dữ liệu cần lưu vào cache.</param>
        /// <param name="jsonData">Chuỗi JSON chứa dữ liệu cần lưu trữ.</param>
        /// <param name="options">Cấu hình thời gian tồn tại của cache.</param>
        /// <param name="cancellationToken">Token để hủy tác vụ bất đồng bộ.</param>
        Task SetStringAsync(string prefix, string key, string jsonData, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lưu dữ liệu dạng byte vào cache với thời gian hết hạn được chỉ định.
        /// </summary>
        /// <param name="prefix">Prefix quy định danh mục của cache.</param>
        /// <param name="key">Khóa của dữ liệu cần lưu vào cache.</param>
        /// <param name="data">Dữ liệu dưới dạng mảng byte.</param>
        /// <param name="options">Cấu hình thời gian tồn tại của cache.</param>
        /// <param name="cancellationToken">Token để hủy tác vụ bất đồng bộ.</param>
        Task SetAsync(string prefix, string key, byte[] data, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default);
        /// <summary>
        /// Lấy dữ liệu từ cache và chuyển đổi thành đối tượng kiểu TResult.
        /// </summary>
        /// <typeparam name="TResult">Kiểu dữ liệu mong muốn khi deserialize.</typeparam>
        /// <param name="prefix">Prefix quy định danh mục của cache.</param>
        /// <param name="key">Khóa của dữ liệu cần lấy.</param>
        /// <param name="cancellationToken">Token để hủy tác vụ bất đồng bộ.</param>
        /// <returns>Đối tượng đã được deserialize từ JSON.</returns>
        //Task<TResult> GetAsync<TResult>(string prefix, string key, CancellationToken cancellationToken = default);
    }
}
