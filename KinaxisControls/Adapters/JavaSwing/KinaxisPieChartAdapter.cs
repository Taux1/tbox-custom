using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.JavaAwt;
using Tricentis.Automation.Engines.Adapters.Lists;
using Tricentis.Automation.Engines.Technicals.JavaAwt;
using Tricentis.Automation.Engines.Technicals.JavaAwt.Interfaces;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Engines.Technicals.JavaSwing.JideSoft;
using Tricentis.Automation.Engines.Technicals.JavaSwing.Kinaxis;
using Tricentis.Automation.Simulation;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing
{
    
    [SupportedTechnical(typeof(PieChartTechnical))]
    public class KinaxisPieChartAdapter : AwtContainerAdapter, IAdapter
    {
        
        public KinaxisPieChartAdapter(PieChartTechnical technical, Validator validator) : base(technical, validator)
        {
        }
        
        public override bool Enabled => true;

        public override bool Focused => true;

        public override bool InteractiveElement => true;

        public override bool IsSteerable => true;

        public override bool Visible => true;

        public override string DefaultName
        {
            get
            {
                var result = "";
                try
                {
                    result += ((PieChartTechnical)Technical).Name;
                }
                catch (Exception e)
                {
                    result += $"Pie failed to get name, {e.Message}";
                }
                return result;
            }
        }

        public override bool IsInViewPort()
        {
            return true;
        }

        public override void ScrollToVisible()
        {
            return;
        }

        public override void SetFocus()
        {
            return;
        }

        protected override RectangleF GetRefreshedControlArea(bool refreshContext)
        {
            return new RectangleF(0, 0, 0, 0);
        }
    }
    
}
