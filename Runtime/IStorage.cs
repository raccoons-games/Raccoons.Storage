using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Storage
{
    public interface IStorage
    {
        public string Key { get; }
        public string Path { get; }
        public IStorage Parent { get; set; }
        public IEnumerable<IStorage> Children { get; }
        public void AddChild(IStorage child);
        public void RemoveChild(IStorage child);

        public Task<string> GetStringAsync(string key, CancellationToken cancellationToken = default);
        public Task<int> GetIntAsync(string key, CancellationToken cancellationToken = default);
        public Task<float> GetFloatAsync(string key, CancellationToken cancellationToken = default);
        public Task<byte[]> GetBytesAsync(string key, CancellationToken cancellationToken = default);

        public Task SetStringAsync(string key, string value, CancellationToken cancellationToken = default);
        public Task SetIntAsync(string key, int value, CancellationToken cancellationToken = default);
        public Task SetFloatAsync(string key, float value, CancellationToken cancellationToken = default);
        public Task SetBytesAsync(string key, byte[] value, CancellationToken cancellationToken = default);

        public Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default);
        public Task DeleteAsync(string key, CancellationToken cancellationToken = default);

        public string GetString(string key);
        public int GetInt(string key);
        public float GetFloat(string key);
        public byte[] GetBytes(string key);

        public void SetString(string key, string value);
        public void SetFloat(string key, float value);
        public void SetInt(string key, int value);
        public void SetBytes(string key, byte[] value);

        public bool Exists(string key);
        public void Delete(string key);

    }
}