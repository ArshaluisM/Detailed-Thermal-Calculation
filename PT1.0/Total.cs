using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PT1._0
{
    class Total
    {
        DataGridView DB;
        Label Title;
        public Total(DataGridView DB, Label Title)
        {
            this.DB = DB;
            this.Title = Title;
            Populate();
        }

        public void Populate()
        {
            double DH = 0, deta = 0, DN = 0;
            DB.Rows.Clear();
            DB.Columns.Clear();
            Title.Text = "Итоговые результаты расчета (" + (P.GEAR+1) + " из " + P.Z + " ступеней)";
            DB.Columns.Add("gear", "№ ступени: ");
            DB.Columns.Add("H", "H0, кДж/кг");
            DB.Columns.Add("G", "G, кг/с");
            DB.Columns.Add("eta", "\u03b7oi");
            DB.Columns.Add("N", "N, МВт");
            DB.Columns[0].ReadOnly = true;
            DB.Columns[1].ReadOnly = true;
            DB.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[2].ReadOnly = true;
            DB.Columns[3].ReadOnly = true;
            DB.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[4].ReadOnly = true;
            DB.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            for(int i = 0; i < P.Z; i++)
            {
                DB.Rows.Add("" + (i + 1));
            }
            DB.Rows.Add("Итоговые/Cредние значения");
            for(int i = 0; i<=P.GEAR; i++)
            {
                DB.Rows[i].Cells[1].Value = "" + Math.Round(P.h0[i], 2);
                DB.Rows[i].Cells[2].Value = "" + Math.Round(P.G[i], 2);
                DB.Rows[i].Cells[3].Value = "" + Math.Round(P.eta_oi[i], 3);
                DB.Rows[i].Cells[4].Value = "" + Math.Round(P.G[i] * P.h0[i] * P.eta_oi[i]*0.001,2);
                DH += P.h0[i];
                deta += P.eta_oi[i];
                DN += P.G[i] * P.h0[i] * P.eta_oi[i]*0.001;
            }
            DB.Rows[P.Z].Cells[1].Value = "" + Math.Round(DH, 2);
            DB.Rows[P.Z].Cells[2].Value = "-";
            DB.Rows[P.Z].Cells[3].Value = "" + Math.Round(deta/P.Z, 3);
            DB.Rows[P.Z].Cells[4].Value = "" + Math.Round(DN, 2);
        }
        public void Clear()
        {
            DB.Rows.Clear();
            DB.Columns.Clear();
        }
    }
}
