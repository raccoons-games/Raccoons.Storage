using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Storage
{
    public class PlayerPrefsStorage : BaseStorage
    {
        public PlayerPrefsStorage(string key, IStorage parent = null) : base(key, parent)
        {
        }

        protected override Task DeleteAsyncInternal(string fullPath)
        {
            DeleteInternal(fullPath);
            return Task.CompletedTask;
        }

        protected override void DeleteInternal(string fullPath)
        {
            PlayerPrefs.DeleteKey(fullPath);
        }

        protected override Task<bool> ExistsAsyncInternal(string fullPath)
        {
            bool result = ExistsInternal(fullPath);
            return Task.FromResult(result);
        }

        protected override bool ExistsInternal(string fullPath)
        {
            return PlayerPrefs.HasKey(fullPath);
        }

        protected override Task<float> GetFloatAsyncInternal(string fullPath)
        {
            float result = GetFloatInternal(fullPath);
            return Task.FromResult(result);
        }

        protected override float GetFloatInternal(string fullPath)
        {
            return PlayerPrefs.GetFloat(fullPath);
        }

        protected override Task<int> GetIntAsyncInternal(string fullPath)
        {
            int result = GetIntInternal(fullPath);
            return Task.FromResult(result);
        }

        protected override int GetIntInternal(string fullPath)
        {
            return PlayerPrefs.GetInt(fullPath);
        }

        protected override Task<string> GetStringAsyncInternal(string fullPath)
        {
            string result = GetStringInternal(fullPath);
            return Task.FromResult(result);
        }

        protected override string GetStringInternal(string fullPath)
        {
            return PlayerPrefs.GetString(fullPath);
        }

        protected override Task SetFloatAsyncInternal(string fullPath, float value)
        {
            SetFloatInternal(fullPath, value);
            return Task.CompletedTask;
        }

        protected override void SetFloatInternal(string fullPath, float value)
        {
            PlayerPrefs.SetFloat(fullPath, value);
        }

        protected override Task SetIntAsyncInternal(string fullPath, int value)
        {
            SetIntInternal(fullPath, value);
            return Task.CompletedTask;
        }

        protected override void SetIntInternal(string fullPath, int value)
        {
            PlayerPrefs.SetInt(fullPath, value);
        }

        protected override Task SetStringAsyncInternal(string fullPath, string value)
        {
            SetStringInternal(fullPath, value);
            return Task.CompletedTask;
        }

        protected override void SetStringInternal(string fullPath, string value)
        {
            PlayerPrefs.SetString(fullPath, value);
        }
    }
}