using System;
using System.Collections.Generic;
using System.Linq;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.JavaSwing;
using Tricentis.Automation.Engines.Representations.Attributes;

namespace Tricentis.Automation.Engines.Adapters.Controllers.JavaSwing
{
    [SupportedAdapter(typeof(KinaxisWorkbookPieChartAdapter))]
    public class KinaxisWorkbookPieChartAdapterController : ListAdapterController<KinaxisWorkbookPieChartAdapter>
    {
        private const string PieListItems = "PieListItems";

        public KinaxisWorkbookPieChartAdapterController(KinaxisWorkbookPieChartAdapter adapter, ISearchQuery query, Validator validator): base(adapter, query, validator) 
        { 
        }

        protected override IEnumerable<IControllerSearchResult<IAdapter>> SearchInternal()
        {
            return null;
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation)
        {
            yield return new AlgorithmicAssociation(PieListItems);
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("Parent");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ListItemsBusinessAssociation businessAssociation) 
        { 
            yield return new AlgorithmicAssociation(PieListItems);
        }

        protected override IEnumerable<IAdapter> SearchAdapters(IAlgorithmicAssociation algorithmicAssociation)
        {
            if(algorithmicAssociation.AlgorithmName == "PieListItems") { 
                foreach (var (item, index) in ContextAdapter.namesList.Select((value, i) => (value, i)))
                {
                     List<PieChartItemAdapter> adapters = AdapterFactory.CreateAdapters<PieChartItemAdapter>(ContextAdapter.Technical, "Java", item, index).ToList();
	            }
            }
            return base.SearchAdapters(algorithmicAssociation);
        }

        public bool Validate(string query)
        {
            return true;
        }
    }
}
