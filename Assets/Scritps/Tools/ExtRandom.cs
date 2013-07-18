using UnityEngine;
using System.Collections.Generic;
 
/// <summary>
/// Ext random.
/// </summary>
public class ExtRandom<T>
{
	/// <summary>
	/// Randomizes the seed.
	/// </summary>
    public static void RandomizeSeed()
    {
        Random.seed = System.Math.Abs(((int)(System.DateTime.Now.Ticks % 2147483648) - (int)(Time.realtimeSinceStartup + 2000f)) / ((int)System.DateTime.Now.Day - (int)System.DateTime.Now.DayOfWeek * System.DateTime.Now.DayOfYear));
        Random.seed = System.Math.Abs((int)((Random.value * (float)System.DateTime.Now.Ticks * (float)Random.Range(0, 2)) + (Random.value * Time.realtimeSinceStartup * Random.Range(1f, 3f))) + 1);
    }
 
	/// <summary>
	/// Splits the chance.
	/// </summary>
	/// <returns>
	/// The chance.
	/// </returns>
    public static bool SplitChance()
    {
        return Random.Range(0, 2) == 0 ? true : false;
    }
 
	/// <summary>
	/// Chance the specified nProbabilityFactor and nProbabilitySpace.
	/// </summary>
	/// <param name='nProbabilityFactor'>
	/// If set to <c>true</c> n probability factor.
	/// </param>
	/// <param name='nProbabilitySpace'>
	/// If set to <c>true</c> n probability space.
	/// </param>
    public static bool Chance(int nProbabilityFactor, int nProbabilitySpace)
    {
        return Random.Range(0, nProbabilitySpace) < nProbabilityFactor ? true : false;
    }
 
	/// <summary>
	/// Choice the specified array.
	/// </summary>
	/// <param name='array'>
	/// Array.
	/// </param>
    public static T Choice(T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
 
	/// <summary>
	/// Choice the specified list.
	/// </summary>
	/// <param name='list'>
	/// List.
	/// </param>
    public static T Choice(List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
 
	/// <summary>
	/// Weighteds the choice.
	/// </summary>
	/// <returns>
	/// The choice.
	/// </returns>
	/// <param name='array'>
	/// Array.
	/// </param>
	/// <param name='nWeights'>
	/// N weights.
	/// </param>
    public static T WeightedChoice(T[] array, int[] nWeights)
    {
        int nTotalWeight = 0;
        for(int i = 0; i < array.Length; i++)
        {
            nTotalWeight += nWeights[i];
        }
        int nChoiceIndex = Random.Range(0, nTotalWeight);
        for(int i = 0; i < array.Length; i++)
        {
            if(nChoiceIndex < nWeights[i])
            {
                nChoiceIndex = i;
                break;
            }
            nChoiceIndex -= nWeights[i];
        }
 
        return array[nChoiceIndex];
    }
 
	/// <summary>
	/// Weighteds the choice.
	/// </summary>
	/// <returns>
	/// The choice.
	/// </returns>
	/// <param name='list'>
	/// List.
	/// </param>
	/// <param name='nWeights'>
	/// N weights.
	/// </param>
    public static T WeightedChoice(List<T> list, int[] nWeights)
    {
        int nTotalWeight = 0;
        for(int i = 0; i < list.Count; i++)
        {
            nTotalWeight += nWeights[i];
        }
        int nChoiceIndex = Random.Range(0, nTotalWeight);
        for(int i = 0; i < list.Count; i++)
        {
            if(nChoiceIndex < nWeights[i])
            {
                nChoiceIndex = i;
                break;
            }
            nChoiceIndex -= nWeights[i];
        }
 
        return list[nChoiceIndex];
    }
 
	/// <summary>
	/// Shuffle the specified array.
	/// </summary>
	/// <param name='array'>
	/// Array.
	/// </param>
    public static T[] Shuffle(T[] array)
    {
        T[] shuffledArray = new T[array.Length];
        List<int> elementIndices = new List<int>(0);
        for(int i = 0; i < array.Length; i++)
        {
            elementIndices.Add(i);
        }
        int nArrayIndex;
        for(int i = 0; i < array.Length; i++)
        {
            nArrayIndex = elementIndices[Random.Range(0, elementIndices.Count)];
            shuffledArray[i] = array[nArrayIndex];
            elementIndices.Remove(nArrayIndex);
        }
 
        return shuffledArray;
    }
 
	/// <summary>
	/// Shuffle the specified list.
	/// </summary>
	/// <param name='list'>
	/// List.
	/// </param>
    public static List<T> Shuffle(List<T> list)
    {
        List<T> shuffledList = new List<T>(0);
        int nListCount = list.Count;
        int nElementIndex;
        for(int i = 0; i < nListCount; i++)
        {
            nElementIndex = Random.Range(0, list.Count);
            shuffledList.Add(list[nElementIndex]);
            list.RemoveAt(nElementIndex);
        }
 
        return shuffledList;
    }
}