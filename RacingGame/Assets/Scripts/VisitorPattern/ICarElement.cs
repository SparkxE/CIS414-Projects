using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

public interface ICarElement
{
    void Accept(IVisitor visitor);
}
