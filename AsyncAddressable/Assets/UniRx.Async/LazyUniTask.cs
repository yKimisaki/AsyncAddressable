#if CSHARP_7_OR_LATER
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace UniRx.Async
{
    public static class LazyUniTask
    {
        public static UniTask<T> Create<T>(Func<UniTask<T>> taskFactory) where T : class
        {
            return new UniTask<T>(taskFactory);
        }

        // Resources.LoadAsync
        public static UniTask<T> LoadResources<T>(string path) where T : UnityEngine.Object
        {
            return new UniTask<T>(() =>
            {
                var completionSource = new UniTaskCompletionSource<T>();
                var loadTask = Resources.LoadAsync<T>(path);
                loadTask.completed += x => completionSource.TrySetResult(loadTask.asset as T);
                return completionSource.Task;
            });
        }

        // Addressable Assets System
        public static UniTask<T> LoadAddressables<T>(IResourceLocation location) where T : class
        {
            return new UniTask<T>(() =>
            {
                var completionSource = new UniTaskCompletionSource<T>();
                Addressables.LoadAsset<T>(location).Completed += x => completionSource.TrySetResult(x.Result);
                return completionSource.Task;
            });
        }

        // Addressable Assets System
        public static UniTask<T> LoadAddressables<T>(object key) where T : class
        {
            return new UniTask<T>(() =>
            {
                var completionSource = new UniTaskCompletionSource<T>();
                Addressables.LoadAsset<T>(key).Completed += x => completionSource.TrySetResult(x.Result);
                return completionSource.Task;
            });
        }
    }
}

#endif