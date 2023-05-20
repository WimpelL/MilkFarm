using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirBuilder 
{
    private BuildBuilder _buildBuilder;
    public void SetBuildBuilder(BuildBuilder Bbuilder)
    {
        _buildBuilder = Bbuilder;
    }
    public Build GetBuild()
    {
        return _buildBuilder.GetMyBuild();
    }
    public void ConstructionBuild()
    {
        _buildBuilder.CreateNewBuild();
        _buildBuilder.SetOptionsBuild();
    }


}
