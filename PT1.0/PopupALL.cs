using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PT1._0
{
    public partial class PopupALL : Form
    {
        bool V_U = true, wrong = false;
        public int CONTINUE = 0;
        int G = 0;
        int a = 0;
        int k = 0;
        int ii = 0;
        public PopupALL(int GEAR, bool V_U)
        {
            InitializeComponent();
            this.V_U = V_U;
            G = GEAR;
            
            Populate();
        }

        public void Populate()
        {
            DB.Columns.Add("gear", "Данные: /Ступень:");
            DB.Columns.Add("izm", "");
            DB.Columns[0].Width = 250;
            DB.Columns[0].ReadOnly = true;
            DB.Columns[1].ReadOnly = true;
            DB.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < G; i++)
            {
                DB.Columns.Add("" + i, "№" + (i + 1));
                DB.Columns[i + 2].Width = 50;
                DB.Columns[i + 2].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            DB.Rows.Add("диаметр диафрагменного уплотнения","м");
            DB.Rows.Add("зазор диафрагменного уплотнения", "мм");
            DB.Rows.Add("число гребней диафрагменного уплотнения ", "шт.");
            DB.Rows.Add("осевой зазор периферийного уплотнения", "мм");
            DB.Rows.Add("радиальный зазор периферийного уплотнения", "мм");
            DB.Rows.Add("число гребней периферийного уплотнения", "шт.");
            DB.Rows.Add("передний осевой зазор в камере диска", "мм");
            DB.Rows.Add("задний осевой зазор в камере диска", "мм");
            DB.Rows.Add("коэффициент сепарации*", "-");
            DB.Rows.Add("Распологаемый теплоперепад ступени H0", "кДж/кг");
            DB.Rows.Add("Средний диаметр ступени dср", "м");
            DB.Rows.Add("Реакция ступени на среднем диаметре", "-");
            DB.Rows.Add("Отношение скоростей x ф", "-");
            DB.Rows.Add("Парциальность ступени e", "-");
            DB.Rows.Add("Число сопловых сегментов m", "шт.");
            DB.Rows.Add("Ширина сопловой решетки B1 (предварительно)", "мм");
            DB.Rows.Add("Ширина рабочей решетки B2 (предварительно)", "мм");
            if (V_U)
            {
                DB.Rows.Add("Выходная высота сопловой решетки l1", "мм");
                DB.Rows.Add("Выходная высота рабочей решетки l2", "мм");
            }
            else
            {
                DB.Rows.Add("Эффективный угол выхода \nпотока из решетки \u03b1 1э", "град");
                DB.Rows.Add("Разность углов \u0394\u03B2", "град");
            }
            DB.Rows.Add("Тип лабиринтного уплотнения**", "-");
            DB.Rows.Add("Толщина гребня", "мм");
            DB.Rows.Add("Бандаж***", "-");
           
            


        }


        private void button2_Click(object sender, EventArgs e)
        {
            labirint lb = new labirint();
            lb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CONTINUE = 0;
            Close();
        }

        private void DB_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                for (int i = 0; i < P.Z; i++)
                {
                    if (Convert.ToDouble(DB.Rows[13].Cells[i+2].Value) == 1)
                    {
                        DB.Rows[14].Cells[i + 2].ReadOnly = true;
                        DB.Rows[14].Cells[i + 2].Style.BackColor = Color.Gray;
                        DB.Rows[14].Cells[i + 2].Value = "";
                    }
                    else
                    {
                        DB.Rows[14].Cells[i + 2].ReadOnly = false;
                        DB.Rows[14].Cells[i + 2].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void DB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < P.Z; i++)
                {
                    if (Convert.ToDouble(DB.Rows[13].Cells[i+2].Value) == 1)
                    {
                        DB.Rows[14].Cells[i+2].ReadOnly = true;
                        DB.Rows[14].Cells[i+2].Style.BackColor = Color.Gray;
                        DB.Rows[14].Cells[i+2].Value = "";
                    }
                    else
                    {
                        DB.Rows[14].Cells[i+2].ReadOnly = false;
                        DB.Rows[14].Cells[i+2].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void DB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wrong = false;
            try
            {
                for(int i = 0; i <P.Z; i++)
                {
                    ii = i;
                    k = 0;
                    if (DB.Rows[k].Cells[i+2].Value != null)
                    {
                        P.d1y[i] = Convert.ToDouble(DB.Rows[k].Cells[i+2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                        a = k;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.sigma1y[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value)/1000;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.z1y[i] = Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.sigmaa[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.sigmar[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.z2y[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.sd[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.S2[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.SEP[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.h0[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;

                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.dcr[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.Rocr[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.xf[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null && Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value) != 0)
                    {
                        P.Parc[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (Convert.ToDouble(DB.Rows[k-1].Cells[i + 2].Value) != 1)
                    {
                        if (DB.Rows[k].Cells[i + 2].Value != null )
                        {
                            P.m[i] = Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value);
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            wrong = true; a = k;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                            MessageBox.Show("Парциальность < 1 но число сопловых сегментов не задано");
                        }
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.B1[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.B2[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (V_U)
                    {
                        if (DB.Rows[k].Cells[i + 2].Value != null)
                        {
                            P.l1[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            wrong = true; a = k;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                        }
                        k++;
                        if (DB.Rows[k].Cells[i + 2].Value != null)
                        {
                            P.l2[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            wrong = true; a = k;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                        }
                        k++;
                    }
                    else
                    {
                        if (DB.Rows[k].Cells[i + 2].Value != null)
                        {
                            P.alfa1e[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value) * Math.PI / 180; ;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            wrong = true; a = k;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                        }
                        k++;
                        if (DB.Rows[k].Cells[i + 2].Value != null)
                        {
                            P.deltabetta[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value) * Math.PI / 180; ;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            wrong = true; a = k;
                            DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                        }
                        k++;
                    }
                    if (DB.Rows[k].Cells[i + 2].Value != null && Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value)>=1 && Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value)<=7)
                    {
                        P.TYPE_LABIRINT[i] = Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null)
                    {
                        P.delta_greben[i] = Convert.ToDouble(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;
                    if (DB.Rows[k].Cells[i + 2].Value != null && (Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value)==0 || Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value)==1))
                    {
                        P.bandazh[i] = Convert.ToInt32(DB.Rows[k].Cells[i + 2].Value);
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        wrong = true; a = k;
                        DB.Rows[k].Cells[i + 2].Style.BackColor = Color.Red;
                    }
                    k++;

                }
                
            }
            catch (Exception)
            {
                CONTINUE = 0;
                MessageBox.Show("Неправильно введены начальные данные : "+((String)DB.Rows[k].Cells[0].Value) + " для ступени №"+(ii+1));
                DB.Rows[k].Cells[ii + 2].Style.BackColor = Color.Red;
            }
            if (!wrong)
            {
                CONTINUE = 2;
                Close();
            }
            else
            {
                CONTINUE = 0;
                MessageBox.Show("Неправильно введены начальные данные");
            }

        }
    }
}
