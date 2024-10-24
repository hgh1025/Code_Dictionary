using System;
using System.Collections.Generic;
using System.Data;

namespace Code_Dictionary.Model.Utils
{
    public static class DataConvertExtensions
    {
        //public static DataTable ToDataTable(this object excelDataSource)
        //{
        //    IList list = ((IListSource)excelDataSource).GetList();

        //    DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;

        //    List<PropertyDescriptionriptor> props = dataView.Columns.ToList<PropertyDescriptionriptor>();

        //    DataTable table = new DataTable();

        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptionriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }

        //    object[] values = new object[props.Count];

        //    foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }

        //        table.Rows.Add(values);
        //    }

        //    return table;
        //}

        public static DataSet DtoToDataSet<T>(this List<T> excelDataSource)
        {
            // DataSet 생성
            DataSet dataSet = new DataSet();

            // DataTable 생성
            DataTable table = new DataTable(typeof(T).Name); // class model name

            var properties = typeof(T).GetProperties();

            // MemberDto의 각 속성에 대해 DataTable의 컬럼 추가
            foreach (var prop in properties)
            {
                // 속성 이름과 속성 타입을 기반으로 컬럼 추가
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // 각 MemberDto 항목을 DataTable에 추가
            foreach (var item in excelDataSource)
            {
                var row = table.NewRow();
                foreach (var prop in properties)
                {
                    // Reflection을 사용하여 속성 값을 가져와 DataRow에 설정
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            // DataTable을 DataSet에 추가
            dataSet.Tables.Add(table);

            // DataSet 반환
            return dataSet;
        }


    }
}
