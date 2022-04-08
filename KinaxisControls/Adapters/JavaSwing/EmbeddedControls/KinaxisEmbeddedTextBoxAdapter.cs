using Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls.Generic;
using Tricentis.Automation.Engines.Technicals.Java.Kinaxis.Grid;
using Tricentis.Automation.Engines.Technicals.JavaSwing;
using Tricentis.Automation.Simulation;

namespace Tricentis.Automation.Engines.Adapters.JavaSwing.EmbeddedControls {
    public class KinaxisEmbeddedTextBoxAdapter : KinaxisEmbeddedControlAdapter, ITextBoxAdapter {
        #region Fields

        private SwingJTextFieldTechnical textField;

        #endregion

        #region Constructors and Destructors

        public KinaxisEmbeddedTextBoxAdapter(KinaxisGridCellAdapter cellAdapter)
            : base(cellAdapter) { }

        #endregion

        #region Public Properties

        public bool IsPasswordField => false;

        public bool IsMultilineField => false;

        public string Text
        {
            get
            {
               // Technical.ClickCell(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
               //string text = TextField.Text;
               //string text1 = CellAdapter.Text;
               //int queryColumn = CellAdapter.WorkSheetModel.GetQueryColumn(CellAdapter.ColumnIndex);
               //string editValue = CellAdapter.WorkSheetModel.GetEditValue(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
               //string rawVal = CellAdapter.WorkSheetModel.GetRawStringValue(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
               //string dataValue = CellAdapter.WorkSheetModel.GetDataValueByQueryColumn(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
                string cellData = Technical.GetCellData(CellAdapter.RowIndex, CellAdapter.ColumnIndex);
                return cellData;
            }
            set
            {
                ScrollToVisible();
                // var editor = Technical.Editor.Get<JEditorTechnical>();
                //editor.RequestFocusInWindow();
                //Technical.Refresh();

                if (!Technical.IsCellEditable(CellAdapter.RowIndex, CellAdapter.ColumnIndex))
                {
                    return;
                }

                // Technical.ClickCell(CellAdapter.RowIndex, CellAdapter.ColumnIndex);

                CellAdapter.WorkSheetModel.BeginEditGrid(CellAdapter.RowIndex);
                CellAdapter.WorkSheetModel.SetCellValue(CellAdapter.ColumnIndex, CellAdapter.RowIndex, value);
                //Technical.StopEdit(valueToUse);
                // Technical.ValidateDataRows();

                //CellAdapter.JSheetApplet.BeginEdit();
                //CellAdapter.JSheetApplet.DoEditRange();
                //editor.Text = value;
                //editor.TextField.Get<SwingJTextFieldTechnical>()
                //Keyboard keyboard = new Keyboard();
                // keyboard.KeyPress("TAB");
                //Technical.Refresh();
                //TextField.SetText(value);
                //Technical.StopEdit();
                //CellAdapter.JSheetApplet.Save();      // while Save() works it triggers the entire document
                //CellAdapter.WorkSheetModel.EditManager.Get<EditManagerTechnical>().PerformDataRefresh();
                //var dataManager = CellAdapter.WorkSheetModel.DataManager.Get<DataManagerTechnical>();
                //CellAdapter.WorkSheetModel.EditManager.Get<EditManagerTechnical>().ApplyDataChanges(CellAdapter.WorkSheetModel, dataManager);
                //Technical.Refresh();
            }
        }

        public SwingJTextFieldTechnical TextField {
            get {
                if(textField == null) {
                    CellAdapter.ScrollToVisible();
                    JEditorTechnical editor = Technical.Editor.Get<JEditorTechnical>();
                    editor.RequestFocus();
                    textField = editor.TextField.Get<SwingJTextFieldTechnical>();
                }
                return textField;
            }
        }

        /*
         *          * Code from PoC implementation from GridCellAdapter:
         * 
         *                     case "text":
                        if (Technical.IsCellEditable(RowIndex, ColumnIndex))
                        {
                            Technical.ClickCell(RowIndex, ColumnIndex);
                            Thread.Sleep(1000);
                            Technical.Refresh();
                            Keyboard k = new Keyboard();
                            foreach (char c in value.ToCharArray())
                            {
                                k.Type(EscapeCharForSendkeys(c));
                                Thread.Sleep(70);
                            }
                            Thread.Sleep(1000);
                        }
                        break;
         * */

        #endregion
    }
}
