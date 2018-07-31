using System;
using System.Threading.Tasks;
using UniRx.Async;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sample : MonoBehaviour
{
    async Task Start()
    {
        var logger = UnityEngine.Debug.unityLogger;
        try
        {
            logger.Log("Start: " + Time.realtimeSinceStartup.ToString());

            var unitychan = LazyUniTask.LoadAddressables<GameObject>("Assets/UnityChan/Prefabs/unitychan.prefab");
        
            logger.Log("Created task: " + Time.realtimeSinceStartup.ToString());

            var go = Instantiate(await unitychan);
            go.transform.position = new Vector3(Random.Range(-10f, 10f), 0f, 0f);

            logger.Log("First instantiate: " + Time.realtimeSinceStartup.ToString());

            var go2 = Instantiate(await unitychan);
            go2.transform.position = new Vector3(Random.Range(-10f, 10f), 0f, 0f);

            logger.Log("Second instantiate: " + Time.realtimeSinceStartup.ToString());
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.InnerExceptions)
                logger.LogException(e);
        }
        catch (Exception e)
        {
            logger.LogException(e);
        }
    }
}
