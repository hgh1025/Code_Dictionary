using Code_Dictionary.Model.Repository;
using Code_Dictionary.Model.Utils;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace Code_Dictionary.Model.Data
{
    public class Module_ReturnfreeClass
    {
        private object _body_load;
        public Module_ReturnfreeClass()
        {

        }

        public Module_ReturnfreeClass(string body_load)
        {
            _body_load = body_load;
        }

        public static bool GetReturnfree(MainForm payload_form, string selectedText)
        {
            if (selectedText == "Table")
            {
                GetReturnfree_TB_Data(payload_form);
            }
            else if (selectedText == "Column")
            {
                GetReturnfree_Column_Data(payload_form);
            }
            else if (selectedText == "Sp")
            {
                GetReturnfree_SP_Data(payload_form);
            }
            else if (selectedText == "Word")
            {
                GetReturnfree_Word_Data(payload_form);
            }
            return false;
        }

        public static bool GetReturnfree_TB_Data(MainForm payload_form)
        {
            DataSet ds = null;
            TableService tableService = new TableService();

            try
            {
                payload_form.WaitForm_Operation(true);

                var tables = tableService.Get_R_Tables();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (tables != null)
                    {
                        payload_form.gridView_Returnfree.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(tables);
                        payload_form.gridControl_Returnfree.DataSource = ds?.Tables[0];
                    }
                }));
                payload_form.WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                payload_form.WaitForm_Operation(false);
            }

            return true;
        }

        public static bool GetReturnfree_Column_Data(MainForm payload_form)
        {
            DataSet ds = null;
            ColumnService columnService = new ColumnService();

            try
            {
                payload_form.WaitForm_Operation(true);

                var columns = columnService.Get_C_Columns();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (columns != null)
                    {
                        payload_form.gridView_Returnfree.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(columns);
                        payload_form.gridControl_Returnfree.DataSource = ds?.Tables[0];
                    }

                }));
                payload_form.WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                payload_form.WaitForm_Operation(false);
            }

            return true;
        }

        public static bool GetReturnfree_SP_Data(MainForm payload_form)
        {
            DataSet ds = null;
            StoreProcedureService storeProcedureService = new StoreProcedureService();

            try
            {
                payload_form.WaitForm_Operation(true);

                var sps = storeProcedureService.Get_R_SPs();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (sps != null)
                    {
                        payload_form.gridView_Returnfree.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(sps);
                        payload_form.gridControl_Returnfree.DataSource = ds?.Tables[0];
                    }

                }));
                payload_form.WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                payload_form.WaitForm_Operation(false);
            }

            return true;
        }

        public static bool GetReturnfree_Word_Data(MainForm payload_form)
        {
            DataSet ds = null;
            WordService wordService = new WordService();

            try
            {
                payload_form.WaitForm_Operation(true);

                var words = wordService.Get_C_Words();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (words != null)
                    {
                        payload_form.gridView_Returnfree.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(words);
                        payload_form.gridControl_Returnfree.DataSource = ds?.Tables[0];
                    }

                }));
                payload_form.WaitForm_Operation(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                payload_form.WaitForm_Operation(false);
            }

            return true;
        }

    }
}