using System;
using System.Collections.Generic;
using System.Linq;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.JavaSwing;
using Tricentis.Automation.Engines.Representations.Attributes;

namespace Tricentis.Automation.Engines.Adapters.Controllers.Java {
    [SupportedAdapter(typeof(KinaxisGridAdapter))]
    public class KinaxisGridAdapterController : TableContextAdapterController<KinaxisGridAdapter> {

        #region Fields 

        private readonly string RowsAssociation = "Rows";

        #endregion

        #region Constructors and Destructors

        public KinaxisGridAdapterController(KinaxisGridAdapter contextAdapter, 
                                      ISearchQuery query, 
                                      Validator validator)
            : base(contextAdapter, query, validator) { }

        #endregion

        #region Private Methods

        protected override IEnumerable<IAssociation> ResolveAssociation(RowsBusinessAssociation businessAssociation) {
            yield return new AlgorithmicAssociation(RowsAssociation);
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ColumnsBusinessAssociation businessAssociation) {
            throw new NotSupportedException();
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation) {
            yield return new TechnicalAssociation("Children");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation) {
            yield return new TechnicalAssociation("Parent");
        }

        protected override IEnumerable<IAdapter> SearchAdapters(IAlgorithmicAssociation algorithmicAssociation) {
            if(algorithmicAssociation.AlgorithmName == RowsAssociation) {
                return GetRows();
            }
            return base.SearchAdapters(algorithmicAssociation);
        }

        private IEnumerable<IAdapter> GetRows() {
            int headerRowCount = ContextAdapter.Technical.HeaderRowCount;

            List<IAdapter> rows = new List<IAdapter>();
            for (int rowIdx = 0; rowIdx < headerRowCount; rowIdx++) {
                var rowAdapter = AdapterFactory
                    .CreateAdapters<KinaxisGridRowAdapter>(ContextAdapter.Technical, "Java", rowIdx, true)
                    .SingleOrDefault();
                rows.Add(rowAdapter);
            }

            int contentRowCount = ContextAdapter.Technical.RowCount;
            for (int rowIdx = 0; rowIdx < contentRowCount; rowIdx++) {
                var rowAdapter = AdapterFactory
                    .CreateAdapters<KinaxisGridRowAdapter>(ContextAdapter.Technical, "Java", rowIdx, false)
                    .SingleOrDefault();
                rows.Add(rowAdapter);
            }
            return rows;
        }

        //TODO: Is this of interest to us? [frawo]
        // check for QBERow
        //var workSheetModel = ContextAdapter.Technical.GetWorkSheetModel()?.Get<IWorksheetModelTechnical>();

        //if (workSheetModel != null)
        //{
        //    if (workSheetModel.IsQbeVisible())
        //    {
        //        var qbeRowIndex = workSheetModel.GetQbeRow();
        //        // Add additional row adapter for QBERow
        //        rowAdapters.Add(AdapterFactory.CreateAdapters<JGridRowAdapter>(technical, "Java", qbeRowIndex, false).SingleOrDefault());
        //    }
        //}

        #endregion
    }
}
