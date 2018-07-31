# AsyncAddressable
AddressablesをUniTaskのLazyPromiseでよしなに

# LazyUniTask

```
// この段階では読み込み処理は走らない
var unitychan = LazyUniTask.LoadAddressables<GameObject>("Assets/UnityChan/Prefabs/unitychan.prefab");

// awaitした段階で読み込み
var prefab = await unitychan;

// 2回目以降は同じAwaiterを使いまわすので、完了していれば即結果がもらえる
var prefab2 = await unitychan;
```
