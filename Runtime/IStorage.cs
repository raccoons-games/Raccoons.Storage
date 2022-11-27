using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Storage
{
    public interface IStorage : IStorageChannel
    {
        public string Path { get; }
        public IStorage Parent { get; set; }
        public IEnumerable<IStorage> Children { get; }
        public void AddChild(IStorage child);
        public void RemoveChild(IStorage child);
    }
}