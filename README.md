# AsyncAddressable
AddressablesをUniTaskのLazyPromiseでよしなに

# LazyUniTask

https://gist.github.com/yKimisaki/5f7d2846ba21fd9bfb5358de6e5f0ed8

```
// この段階では読み込み処理は走らない
var unitychan = LazyUniTask.LoadAddressables<GameObject>("Assets/UnityChan/Prefabs/unitychan.prefab");

// awaitした段階で読み込み
var prefab = await unitychan;

// 2回目以降は同じAwaiterを使いまわすので、完了していれば即結果がもらえる
var prefab2 = await unitychan;
```

![light_frame](https://user-images.githubusercontent.com/1702680/43435071-526b7486-94b9-11e8-8f7c-0138a0d8f8e7.png)
