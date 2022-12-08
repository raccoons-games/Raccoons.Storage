﻿using System.Security.Cryptography;
using UnityEngine;

namespace Raccoons.Storage.Cryptography.Aes
{
    [CreateAssetMenu(fileName = "AesEncryptionAsset", menuName = "Raccoons/Storage/Encryption/AesEncryptionAsset")]
    public class AesEncryptionAsset : ScriptableObject, IEncryptor, IDecryptor
    {
        [SerializeField]
        private int keyLength = 32;

        [SerializeField]
        private string key;

        [SerializeField]
        private string iv;

        [SerializeField]
        private int blockSize = 16;

        [SerializeField]
        private CipherMode cipherMode = CipherMode.CBC;

        [SerializeField]
        private PaddingMode paddingMode = PaddingMode.PKCS7;

        public AesEncryption AesEncryption { get; private set; }

        public byte[] Decrypt(byte[] input)
        {
            return ((IDecryptor)AesEncryption).Decrypt(input);
        }

        public byte[] Encrypt(byte[] input)
        {
            return ((IEncryptor)AesEncryption).Encrypt(input);
        }

        private void OnEnable()
        {
            AesEncryption = new AesEncryption(key, iv, blockSize, cipherMode, paddingMode);
        }

        private void OnValidate()
        {
            blockSize = Mathf.ClosestPowerOfTwo(blockSize);
            keyLength = Mathf.ClosestPowerOfTwo(keyLength);
            int strLen = keyLength;
            key = EncryptionExtensions.SupportLength(key, strLen);
            iv = EncryptionExtensions.SupportLength(iv, 16);
        }
    }
}
