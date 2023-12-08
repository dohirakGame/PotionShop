using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit{}
}
namespace Game_Logic.Combinations
{
    public class CardCombinations
    {
        public int red { get; init; } = 0;
        public int yellow { get; init; } = 0;
        public int blue { get; init; } = 0;
        public int green { get; init; } = 0;
        public int black { get; init; } = 0;
        public int points { get; init; } = 0;
    }

}