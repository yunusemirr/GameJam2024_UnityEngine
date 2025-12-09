using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput 
{

    float Horizontal { get;}
    float Vertical { get;}
    bool Jump { get;}
    bool Attack { get;}

}
