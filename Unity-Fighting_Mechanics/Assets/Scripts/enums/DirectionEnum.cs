using System;

// Using flags so I can handle diagonal combos 
[Flags]
public enum DirectionEnum
{
    UP = 1,
    DOWN = 2,
    LEFT = 4,
    RIGHT = 8
}
