using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Storage
{
    public interface IStorage
    {
        public string Key { get; }
        public IStorage Parent { get; set; }
        public IEnumerable<IStorage> Children { get; }
        public void AddChild(IStorage child);
        public void RemoveChild(IStorage child);

        public Task<string> GetStringAsync(string key);
        public Task<int> GetIntAsync(string key);
        public Task<float> GetFloatAsync(string key);

        public Task SetStringAsync(string key, string value);
        public Task SetIntAsync(string key, int value);
        public Task SetFloatAsync(string key, float value);

        public Task<bool> ExistsAsync(string key);
        public Task DeleteAsync(string key);

        public string GetString(string key);
        public int GetInt(string key);
        public float GetFloat(string key);

        public void SetString(string key, string value);
        public void SetFloat(string key, float value);
        public void SetInt(string key, int value);

        public bool Exists(string key);
        public void Delete(string key);
    }
}