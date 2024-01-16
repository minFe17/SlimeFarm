using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : MonoBehaviour
{
    // ╫л╠шео

    void OnLoadDone<T>(AsyncOperationHandle<T> handle, Action<T> callback)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
            callback.Invoke(handle.Result);
    }

    public void LoadAsset<T>(string address, Action<T> callback)
    {
        Addressables.LoadAssetAsync<T>(address).Completed += handle => OnLoadDone(handle, callback);
    }
}