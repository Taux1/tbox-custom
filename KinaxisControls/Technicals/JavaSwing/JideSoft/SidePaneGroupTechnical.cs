using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft;
using Tricentis.Automation.Engines.Technicals.References;

[SupportedTechnicalTypeName("com.jidesoft.swing.SidePaneGroup")]
public class SidePaneGroupTechnical : JavaObjectTechnical
{
    #region Constructors and Destructors

    public SidePaneGroupTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
        : base(remoteObjectManager, validator) { }

    #endregion

    public int getSelectedIndex()
    {
        return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getSelectedIndex");
    }

    public IObjectReference getItemAtIndex(int index)
    {
        return RemoteObjectManager.InvokeMethodAsReference(this, "get", index);
    }

    public string getLongestTitle()
    {
        return RemoteObjectManager.InvokeMethodAsValue<string>(this, "getLongestTitle");
    }

    public void SetSelectedIndex(int index)
    {
        RemoteObjectManager.InvokeVoidMethod(this, "setSelectedIndex", index);
    }

    public void fireSidePaneEvent(SidePaneItemTechnical item, int paramInt)
    {
        RemoteObjectManager.InvokeVoidMethod(this, "fireSidePaneEvent", item,  paramInt);
    }
}

