using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BuildBuilder
{
    protected Build Build{get; private set;}
    public void CreateNewBuild()
    {
        Build = new Build();
    }
    public Build GetMyBuild()
    {
        return Build;
    }
    public abstract void SetOptionsBuild();

}
