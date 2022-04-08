using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Java;
using Tricentis.Automation.Engines.Technicals.JavaAwt;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;
using Tricentis.Automation.Engines.Technicals.References;

namespace Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft
{
    [SupportedTechnicalTypeName("com.jidesoft.plaf.basic.BasicSidePaneUI")]
    public class BasicSidePaneUITechnical : SwingComponentUITechnical
    {
        public BasicSidePaneUITechnical(ISwingObjectManager remoteObjectManager, Validator validator) : base(remoteObjectManager, validator)
        {
        }

        //Rectangle	getGroupRect(int index)
        //SidePaneItem	getItemForIndex(int index)
        //static ComponentUI	createUI(JComponent c)

        //protected  Rectangle[]	_rects
        //protected  int	_size

        public IObjectListReference Rects => RemoteObjectManager.GetFieldAsList(this, "_rects");

        //
        public int getSelectedItemIndex(AwtPointTechnical point)
        {
            return RemoteObjectManager.InvokeMethodAsValue<int>(this, "getSelectedItemIndex", point);
        }


    }
}