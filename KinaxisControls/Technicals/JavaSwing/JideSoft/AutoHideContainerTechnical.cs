using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaAwt;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;

[SupportedTechnicalTypeName("com.jidesoft.docking.AutoHideContainer")]
public class AutoHideContainerTechnical : SidePaneTechnical
{
    #region Constructors and Destructors

    public AutoHideContainerTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
        : base(remoteObjectManager, validator) { }

    #endregion

    public IObjectReference GetGroupForIndex(int index)
    {
        return RemoteObjectManager.InvokeMethodAsReference(this, "getGroupForIndex", index);
    }
    public IObjectReference GetItemForIndex(int index)
    {
        return RemoteObjectManager.InvokeMethodAsReference(this, "getItemForIndex", index);
    }

    public int getSelectedItemIndex(AwtPointTechnical point)
    {
        return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getSelectedItemIndex", point);
    }
}
