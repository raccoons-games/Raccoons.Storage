using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Raccoons.Storage
{
    public abstract class BaseStorage : IStorage
    {
        private readonly string _key;
        private IStorage _parent;
        protected List<IStorage> _children;

        public BaseStorage(string key, IStorage parent = null)
        {
            _key = key;
            Parent = parent;
        }

        public string CombinePath(params string []parts)
        {
            return string.Join('/', parts);
        }
        public string Key => Parent == null ? _key : CombinePath(Parent.Key, _key);
        public IEnumerable<IStorage> Children => _children;

        public IStorage Parent 
        {
            get => _parent;
            set
            {
                if (Parent != null)
                {
                    Parent.RemoveChild(this);
                }
                Parent = value;
                if (Parent != null)
                {
                    Parent.AddChild(this);
                }
            }
        }

        void IStorage.AddChild(IStorage child)
        {
            _children.Add(child);
        }

        void IStorage.RemoveChild(IStorage child)
        {
            _children.Remove(child);
        }

        public string PathOf(string key)
        {
            return CombinePath(Key, key);
        }

        public Task<string> GetStringAsync(string key)
        {
            string fullPath = PathOf(key);
            return GetStringAsyncInternal(fullPath);
        }

        protected abstract Task<string> GetStringAsyncInternal(string fullPath);

        public Task<int> GetIntAsync(string key)
        {
            string fullPath = PathOf(key);
            return GetIntAsyncInternal(fullPath);
        }

        protected abstract Task<int> GetIntAsyncInternal(string fullPath);

        public Task<float> GetFloatAsync(string key)
        {
            string fullPath = PathOf(key);
            return GetFloatAsyncInternal(fullPath);
        }

        protected abstract Task<float> GetFloatAsyncInternal(string fullPath);

        public Task SetStringAsync(string key, string value)
        {
            string fullPath = PathOf(key);
            return SetStringAsyncInternal(fullPath, value);
        }

        protected abstract Task SetStringAsyncInternal(string fullPath, string value);

        public Task SetIntAsync(string key, int value)
        {
            string fullPath = PathOf(key);
            return SetIntAsyncInternal(fullPath, value);
        }

        protected abstract Task SetIntAsyncInternal(string fullPath, int value);

        public Task SetFloatAsync(string key, float value)
        {
            string fullPath = PathOf(key);
            return SetFloatAsyncInternal(fullPath, value);
        }

        protected abstract Task SetFloatAsyncInternal(string fullPath, float value);

        public Task<bool> ExistsAsync(string key)
        {
            string fullPath = PathOf(key);
            return ExistsAsyncInternal(fullPath);
        }

        protected abstract Task<bool> ExistsAsyncInternal(string fullPath);

        public Task DeleteAsync(string key)
        {
            string fullPath = PathOf(key);
            return DeleteAsyncInternal(fullPath);
        }

        protected abstract Task DeleteAsyncInternal(string fullPath);

        public string GetString(string key)
        {
            string fullPath = PathOf(key);
            return GetStringInternal(fullPath);
        }

        protected abstract string GetStringInternal(string fullPath);

        public int GetInt(string key)
        {
            string fullPath = PathOf(key);
            return GetIntInternal(fullPath);
        }

        protected abstract int GetIntInternal(string fullPath);

        public float GetFloat(string key)
        {
            string fullPath = PathOf(key);
            return GetFloatInternal(fullPath);
        }

        protected abstract float GetFloatInternal(string fullPath);

        public void SetString(string key, string value)
        {
            string fullPath = PathOf(key);
            SetStringInternal(fullPath, value);
        }

        protected abstract void SetStringInternal(string fullPath, string value);

        public void SetFloat(string key, float value)
        {
            string fullPath = PathOf(key);
            SetFloatInternal(fullPath, value);
        }

        protected abstract void SetFloatInternal(string fullPath, float value);

        public void SetInt(string key, int value)
        {
            string fullPath = PathOf(key);
            SetIntInternal(fullPath, value);
        }

        protected abstract void SetIntInternal(string fullPath, int value);

        public bool Exists(string key)
        {
            string fullPath = PathOf(key);
            return ExistsInternal(fullPath);
        }

        protected abstract bool ExistsInternal(string fullPath);

        public void Delete(string key)
        {
            string fullPath = PathOf(key);
            DeleteInternal(fullPath);
        }

        protected abstract void DeleteInternal(string fullPath);
    }
}