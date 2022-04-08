using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.Lists;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Interfaces;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing.Jide
{
    [SupportedTechnical(typeof(AutoHideContainerTechnical))]
    public class JideTabControlAdapter : SwingJPanelAdapterBase<AutoHideContainerTechnical>, ITabControlAdapter
    {
        protected JideTabControlAdapter(AutoHideContainerTechnical technical, Validator validator) : base(technical, validator)
        {
        }

        public override string DefaultName => "TabControl:" + base.DefaultName;
    }
}
