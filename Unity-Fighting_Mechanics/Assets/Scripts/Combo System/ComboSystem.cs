using System.Collections.Generic;
using UnityEngine;

public class ComboSystem
{
    /*  Combo System could have a LinkedList<InputKey> which would hold a reference to the key pressed
     * 
     *          It should have a function to check if the current listing of InputKey registered form a valid input or not at runtime
     *          => which means having a search function for valid string
     *          
     *          It should have a Timer function that remove the first input from the list after the timespan from the last input is over
     *          
     *          It should also have a function to clear all previous key registered if the current InputKey registered doesnt find a combo match
     */

    public LinkedList<InputKey> ll_ikey { get; private set; }

    public ComboSystem() => ll_ikey = new LinkedList<InputKey>();

    public void Add(InputKey input) => ll_ikey.AddLast(input);

    public bool Search()
    {
        // use the current chain of values inside the linkedlist and search for a match inside the data structure that holds all combos
        return true;
    }
}

