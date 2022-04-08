#region Assembly Tricentis.Automation.Interaction, Version=20.13.1010.0, Culture=neutral, PublicKeyToken=null
// C:\Program Files (x86)\TRICENTIS\Tosca Testsuite\TBox\Tricentis.Automation.Interaction.dll
// Decompiled with ICSharpCode.Decompiler 6.1.0.5902
#endregion

using System;
using System.Reflection;
using Tricentis.Automation.Engines.Technicals;
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
    public interface KinaxisPieIAdapter : IAdapter
    {
        /// <summary>
        /// Default Name of the control<br />
        /// Returns null if the Name can not be decided
        /// </summary>
        string DefaultName
        {
            get;
        }

        /// <summary>
        /// Public Technical representation of this Adapter.<br />
        /// This Technical has been used to create this Adapter.
        /// </summary>
        ITechnical Technical
        {
            get;
        }

        event EventHandler Disposing;

        /// <summary>
        /// Retrieves the value of the property <paramref name="name" /> from the <see cref="P:Tricentis.Automation.Engines.Adapters.IAdapter.Technical" /><br />
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        object GetProperty(string name, bool fallback);

        /// <summary>
        /// Retrieves the value, and the PropertyInfo of the property <paramref name="name" /> from the <see cref="P:Tricentis.Automation.Engines.Adapters.IAdapter.Technical" /><br />
        /// </summary>
        /// <param name="name"></param>
        /// <param name="propertyInfo"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        object GetProperty(string name, out PropertyInfo propertyInfo, bool fallback);

        /// <summary>
        /// Retrieves the value, and the PropertyInfo of the property <paramref name="name" /> from the <see cref="P:Tricentis.Automation.Engines.Adapters.IAdapter.Technical" /><br />
        /// </summary>
        /// <param name="name"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        object GetTechnicalProperty(string name, out PropertyInfo propertyInfo);

        /// <summary>
        /// Refresh all Properties on the Adapter and its Technicals
        /// </summary>
        void Refresh();

        /// <summary>
        /// Sets the value of the property <paramref name="name" /> on the <see cref="P:Tricentis.Automation.Engines.Adapters.IAdapter.Technical" /> to the <paramref name="value" /><br />
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void SetProperty(string name, object value);
    }
}
#if false // Decompilation log
