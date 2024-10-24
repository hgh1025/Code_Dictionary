using Code_Dictionary.Model.Repository;
using Code_Dictionary.Model.Utils;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace Code_Dictionary.Model.Data
{
    public class Module_PeoplecarClass
    {
        private object _body_load;
        public Module_PeoplecarClass()
        {

        }

        public Module_PeoplecarClass(object body_load)
        {
            _body_load = body_load;
        }

        public static void Hide_Column(MainForm payload_form)
        {

            if (payload_form.gridView_Peoplecar.Columns.ColumnByFieldName("TableId") != null)
                payload_form.gridView_Peoplecar.Columns["TableId"].Visible = false;

            if (payload_form.gridView_Peoplecar.Columns.ColumnByFieldName("ColumnId") != null)
                payload_form.gridView_Peoplecar.Columns["ColumnId"].Visible = false;

            if (payload_form.gridView_Peoplecar.Columns.ColumnByFieldName("SpId") != null)
                payload_form.gridView_Peoplecar.Columns["SpId"].Visible = false;

            payload_form.gridView_Peoplecar.Columns["name1"].Visible = false;
            payload_form.gridView_Peoplecar.Columns["name2"].Visible = false;
            payload_form.gridView_Peoplecar.Columns["name3"].Visible = false;
            payload_form.gridView_Peoplecar.Columns["name4"].Visible = false;
            payload_form.gridView_Peoplecar.Columns["name5"].Visible = false;
            payload_form.gridView_Peoplecar.Columns["name6"].Visible = false;
        }

        public static bool GetPeoplecar(MainForm payload_form, string selectedText)
        {
            if (selectedText == "Table")
            {
                GetPeoplecar_TB_Data(payload_form);
            }
            else if (selectedText == "Column")
            {
                GetPeoplecar_Column_Data(payload_form);
            }
            else if (selectedText == "Sp")
            {
                GetPeoplecar_SP_Data(payload_form);
            }
            else if (selectedText == "Word")
            {
                GetPeoplecar_Word_Data(payload_form);
            }
            return false;
        }

        public static bool GetPeoplecar_TB_Data(MainForm payload_form)
        {
            DataSet ds = null;
            TableService tableService = new TableService();
            try
            {
                payload_form.WaitForm_Operation(true);
                var tables = tableService.Get_P_Tables();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (tables != null)
                    {
                        payload_form.gridView_Peoplecar.Columns.Clear(); // combobox change시 컬럼을 초기화하기 위해서 
                        ds = DataConvertExtensions.DtoToDataSet(tables);

                        payload_form.gridControl_Peoplecar.DataSource = ds?.Tables[0];

                        Hide_Column(payload_form);

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

        public static bool GetPeoplecar_Column_Data(MainForm payload_form)
        {
            DataSet ds = null;
            ColumnService columnService = new ColumnService();

            try
            {
                payload_form.WaitForm_Operation(true);

                var columns = columnService.Get_P_Columns();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (columns != null)
                    {
                        payload_form.gridView_Peoplecar.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(columns);
                        payload_form.gridControl_Peoplecar.DataSource = ds?.Tables[0];

                        Hide_Column(payload_form);
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

        public static bool GetPeoplecar_SP_Data(MainForm payload_form)
        {
            DataSet ds = null;
            StoreProcedureService storeProcedureService = new StoreProcedureService();

            try
            {
                payload_form.WaitForm_Operation(true);

                var sps = storeProcedureService.Get_P_SPs();

                // 메인리스트
                payload_form.Invoke(new MethodInvoker(delegate
                {
                    if (sps != null)
                    {
                        payload_form.gridView_Peoplecar.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(sps);
                        payload_form.gridControl_Peoplecar.DataSource = ds?.Tables[0];

                        Hide_Column(payload_form);
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

        public static bool GetPeoplecar_Word_Data(MainForm payload_form)
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
                        payload_form.gridView_Peoplecar.Columns.Clear();
                        ds = DataConvertExtensions.DtoToDataSet(words);
                        payload_form.gridControl_Peoplecar.DataSource = ds?.Tables[0];

                        payload_form.gridView_Peoplecar.Columns["WordId"].Visible = false;
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