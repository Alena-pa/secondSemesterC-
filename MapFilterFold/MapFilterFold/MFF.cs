using System;
using System.Collections.Generic;

namespace Functional;
public class Functions
{
    public static List<TResult> Map<TElement, TResult>(List<TElement> inputList, Func<TElement, TResult> transformFunction)
    {
        var resultList = new List<TResult>();
        foreach (var element in inputList)
        {
            var transformedElement = transformFunction(element);
            resultList.Add(transformedElement);
        }
        return resultList;
    }
    public static List<TElement> Filter<TElement>(List<TElement> inputList, Func<TElement, bool> conditionFunction)
    {
        var filteredList = new List<TElement>();
        foreach (var element in inputList)
        {
            if (conditionFunction(element))
            {
                filteredList.Add(element);
            }
        }
        return filteredList;
    }
    public static TAccumulator Fold<TElement, TAccumulator>(List<TElement> inputList, TAccumulator initialValue, Func<TAccumulator, TElement, TAccumulator> accumulationFunction)
    {
        var currentValue = initialValue;
        foreach (var element in inputList)
        {
            currentValue = accumulationFunction(currentValue, element);
        }
        return currentValue;
    }
}
