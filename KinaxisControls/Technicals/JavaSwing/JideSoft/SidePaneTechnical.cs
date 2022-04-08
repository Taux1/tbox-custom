using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;

[SupportedTechnicalTypeName("com.jidesoft.swing.SidePane")]
public class SidePaneTechnical : SwingJPanelTechnical
{
    #region Constructors and Destructors

    public SidePaneTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
        : base(remoteObjectManager, validator) { }

    #endregion

    public IObjectListReference GetGroups()
    {
        return RemoteObjectManager.InvokeMethodAsReferenceList(this, "getGroups");
    }

    public IObjectReference getUI()
    {
        return RemoteObjectManager.InvokeMethodAsReference(this, "getUI");
    }


    public void updateUI()
    {
        RemoteObjectManager.InvokeVoidMethod(this, "updateUI");
    }
}

