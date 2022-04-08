using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft;
using Tricentis.Automation.Engines.Technicals.References;

[SupportedTechnicalTypeName("com.jidesoft.docking.AutoHideMouseListenerTechnical")]
public class AutoHideMouseListenerTechnical : JavaObjectTechnical
{
    #region Constructors and Destructors

    public AutoHideMouseListenerTechnical(ISwingObjectManager remoteObjectManager, Validator validator)
        : base(remoteObjectManager, validator) { }

    #endregion

    public void mouseClicked(MouseEventTechnical title)
    {
        RemoteObjectManager.InvokeVoidMethod(this, "mouseClicked", title);
    }
}

