using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLibrary;
using Xceed.Document.NET;
using Xceed.Words.NET;



namespace PT1._0
{
    public partial class GearParam : Form
    {
        int j;
        int gear;
        
        public GearParam(int G)
        {
            gear = G;
            InitializeComponent();
            DB.Columns.Add("descriprion", "Величина");
            DB.Columns.Add("e", "Единица измерения");
            DB.Columns.Add("total", "Значение");
            DB.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            DB.ReadOnly = true;
            DB.Dock = DockStyle.Fill;
            DB.Columns[0].MinimumWidth = DB.Width / 2;
            Populate(G);


        }

        public void Populate(int G)
        {
            j = 0;   
            if (G > 0)
            {
                for (int i = 0; i < G; i++)
                {
                    DB.Rows.Add(new String[] { "ДАННЫЕ ДЛЯ " + (i + 1) + " СТУПЕНИ" });
                    DB.Rows[j].DefaultCellStyle.BackColor = Color.Green;
                    DB.Rows.Add(new String[] { "давление р0", "бар", "" + Math.Round(P.p0[i], 3) });
                    DB.Rows.Add(new String[] { "температура t0", "\u00B0C", "" + Math.Round(P.t0[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание i0", "кДж/кг", "" + Math.Round(P.i0[i] * 0.001, 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара v0", "м³/кг", "" + Math.Round(P.v0[i], 3) });
                    DB.Rows.Add(new String[] { "влажность y0", "м³/кг", "" + Math.Round(P.y0[i], 3) });
                    DB.Rows.Add(new String[] { "расход пара через ступень G", "кг/с", "" + Math.Round(P.G[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент использования энергии выходной скорости \u03C7", "-", "" + Math.Round(P.Xi0[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание заторможенного потока перед ступенью i0_", "кДж/кг", "" + Math.Round(P.i0[i] * 0.001, 3) });
                    DB.Rows.Add(new String[] { "температура заторможенного потока перед ступенью t0_", "\u00B0C", "" + Math.Round(P.t0_[i], 3) });
                    DB.Rows.Add(new String[] { "удельный объём заторможенного потока перед ступенью v0_", "м³/кг", "" + Math.Round(P.v0_[i], 3) });
                    DB.Rows.Add(new String[] { "влажность заторможенного потока перед ступенью y0_", "-", "" + Math.Round(P.y0_[i], 3) });
                    DB.Rows.Add(new String[] { "изоэнтропийный теплоперепад ступени H0", "кДж/кг", "" + Math.Round(P.H0[i], 3) });
                    DB.Rows.Add(new String[] { "средний диаметр ступени dср", "м", "" + Math.Round(P.dcr[i], 3) });
                    DB.Rows.Add(new String[] { "окружная скорость ступени U", "м/c", "" + Math.Round(P.U[i], 3) });
                    DB.Rows.Add(new String[] { "отношение скоростей xф", "-", "" + Math.Round(P.xf[i], 3) });
                    DB.Rows.Add(new String[] { "условная (фиктивная) скорость ступени Сф", "м/с", "" + Math.Round(P.Cf[i], 3) });
                    DB.Rows.Add(new String[] { "распологаемый теплоперепад ступени H0_", "кДж/кг", "" + Math.Round(P.H0_[i], 3) });
                    DB.Rows.Add(new String[] { "реакция ступени на среднем диаметре \u03C1ср", "-", "" + Math.Round(P.Rocr[i], 3) });

                    DB.Rows.Add(new String[] { "ТЕПЛОВОЙ РАСЧЁТ СОПЛОВОЙ РЕШЕТКИ" });
                    DB.Rows.Add(new String[] { "изоэнтропийный тепловой перепад сопловой решетки H01_", "кДж/кг", "" + Math.Round(P.H01_[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание в конце изоэнтропийного процесса i1t", "кДж/кг", "" + Math.Round(P.i1t[i] * 0.001, 3) });
                    DB.Rows.Add(new String[] { "давление пара в изоэнтропийном процессе p1t", "бар", "" + Math.Round(P.p1t[i] * 0.00001, 3) });
                    DB.Rows.Add(new String[] { "температура пара в изоэнтропийном процессе t1t", "\u00B0C", "" + Math.Round(P.t1t[i], 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара в изоэнтропийном процессе v1t", "м³/кг", "" + Math.Round(P.v1t[i], 3) });
                    DB.Rows.Add(new String[] { "влажность пара в изоэнтропийном процессе y1t", "-", "" + Math.Round(P.y1t[i], 3) });
                    DB.Rows.Add(new String[] { "абсолютная теоретическая скорость пара на выходе С1t", "м/с", "" + Math.Round(P.C1t[i], 3) });
                    DB.Rows.Add(new String[] { "скорость звука а1t", "м/c", "" + Math.Round(P.a1t[i], 3) });
                    DB.Rows.Add(new String[] { "число Маха M1t", "-", "" + Math.Round(P.M1t[i], 3) });
                    DB.Rows.Add(new String[] { "отношение давлений \u03B51", "-", "" + Math.Round(P.eps1[i], 3) });
                    DB.Rows.Add(new String[] { "критическое давление p*1", "бар", "" + Math.Round(P.p1zv[i], 3) });
                    DB.Rows.Add(new String[] { "критическая температура t*1", "\u00B0C", "" + Math.Round(P.t1zv[i], 3) });
                    DB.Rows.Add(new String[] { "критическое теплосодержание i*1", "кДж/кг", "" + Math.Round(P.i1zv[i], 3) });
                    DB.Rows.Add(new String[] { "критический удельный объём v*1", "м³/кг", "" + Math.Round(P.v1zv[i], 3) });
                    DB.Rows.Add(new String[] { "хорда профиля по среднему диаметру b1", "мм", "" + Math.Round(P.b1[i], 3) });
                    DB.Rows.Add(new String[] { "корневой диаметр dк", "м", "" + Math.Round(P.dk[i], 3) });
                    DB.Rows.Add(new String[] { "парциальность ступени е", "-", "" + Math.Round(P.Parc[i], 3) });
                    DB.Rows.Add(new String[] { "выходная высота сопловой решетки l1", "мм", "" + Math.Round(P.l1[i], 3) });
                    j += 37;
                    if (P.M1t[i] < 1)
                    {
                        DB.Rows.Add(new String[] { "площадь выходного сечения сопловой решетки F1", "м²", "" + Math.Round(P.F1[i], 3) });
                        DB.Rows.Add(new String[] { "эффективный угол выхода потока из решетки \u03b11э", "град", "" + Math.Round(P.alfa1e[i], 3) });
                        DB.Rows.Add(new String[] { "угол выхода потока из решетки \u03b11", "град", "" + Math.Round(P.alfa1[i], 3) });
                        DB.Rows.Add(new String[] { "угол отклонения потока в косом срезе решетки \u03b41", "град", "" + Math.Round(P.delta1[i], 3) });
                        j += 4;
                    }
                    if (P.M1t[i] >= 1 && P.M1t[i] <= 1.35)
                    {
                        DB.Rows.Add(new String[] { "площадь критического сечения сопловой решетки F*1", "м²", "" + Math.Round(P.Fzv1[i], 3) });
                        DB.Rows.Add(new String[] { "площадь выходного сечения сопловой решетки F1", "м²", "" + Math.Round(P.F1[i], 3) });
                        DB.Rows.Add(new String[] { "критическая скорость истечения С*", "м/с", "" + Math.Round(P.Czv[i], 3) });
                        DB.Rows.Add(new String[] { "эффективный угол выхода потока из решетки \u03b11э", "град", "" + Math.Round(P.alfa1e[i], 3) });
                        DB.Rows.Add(new String[] { "угол выхода потока из решетки \u03b11", "град", "" + Math.Round(P.alfa1[i], 3) });
                        j += 6;
                    }
                    if (P.M1t[i] > 1.35)
                    {
                        DB.Rows.Add(new String[] { "площадь критического сечения сопловой решетки F*1", "м²", "" + Math.Round(P.Fzv1[i], 3) });
                        DB.Rows.Add(new String[] { "площадь выходного сечения сопловой решетки F1", "м²", "" + Math.Round(P.F1[i], 3) });
                        DB.Rows.Add(new String[] { "степень расширения канала сопла f1", "-", "" + Math.Round(P.f1[i], 3) });
                        DB.Rows.Add(new String[] { "эффективный угол выхода потока из решетки \u03b11э", "град", "" + Math.Round(P.alfa1e[i], 3) });
                        DB.Rows.Add(new String[] { "угол выхода потока из решетки \u03b11", "град", "" + Math.Round(P.alfa1[i], 3) });
                        DB.Rows.Add(new String[] { "угол отклонения потока в косом срезе решетки \u03b41", "град", "" + Math.Round(P.delta1[i], 3) });
                        DB.Rows.Add(new String[] { "угол в критическом сечении решетки \u03b1*1", "град", "" + Math.Round(P.alfazv1[i], 3) });
                        j += 7;
                    }

                    DB.Rows.Add(new String[] { "РАСЧЕТ ГЕОМЕТРИИ СОПЛОВОЙ РЕШЕКТИ" });
                    DB.Rows.Add(new String[] { "тип профиля", "", "" + P.P_S[i] });
                    DB.Rows.Add(new String[] { "угол установки (\u03B1y)T", "град", "" + Math.Round(P.alfay[i], 3) });
                    DB.Rows.Add(new String[] { "относительный шаг t1T", "-", "" + Math.Round(P.topt[i], 3) });
                    DB.Rows.Add(new String[] { "угол входа потока в сопловую решетку \u03B10", "град", "" + Math.Round(P.alfa0[i], 3) });
                    DB.Rows.Add(new String[] { "ширина решетки B1", "мм", "" + Math.Round(P.B1[i], 3) });
                    DB.Rows.Add(new String[] { "хорда профиля b1", "мм", "" + Math.Round(P.b1[i], 3) });
                    DB.Rows.Add(new String[] { "число каналов в решетке z1", "шт.", "" + Math.Round(P.z1[i], 3) });
                    DB.Rows.Add(new String[] { "шаг решетки t1", "мм", "" + Math.Round(P.t1_geom[i], 3) });
                    DB.Rows.Add(new String[] { "ширина канала в узком сечении О1", "мм", "" + Math.Round(P.O1[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент кинематической вязкости v1", "м²/c", "" + Math.Round(P.v1kin[i], 6) });
                    DB.Rows.Add(new String[] { "коэффициент расхода сопловой решетки \u03BC1", "-", "" + Math.Round(P.nu1[i], 3) });

                    DB.Rows.Add(new String[] { "РАСЧЕТ КОЭФФИЦИЕНТА ПОТЕРЬ ЭНЕРГИИ РЕШЕКТИ" });
                    DB.Rows.Add(new String[] { "угол поворота в сопловой решетке \u0394\u03B1", "град", "" + Math.Round(P.delta_alfa[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент потерь энергии без учета поправок \u03B60", "-", "" + Math.Round(P.zetta0[i], 3) });
                    DB.Rows.Add(new String[] { "поправка km", "-", "" + Math.Round(P.km[i], 3) });
                    DB.Rows.Add(new String[] { "поправка ka", "-", "" + Math.Round(P.ka[i], 3) });
                    DB.Rows.Add(new String[] { "поправка kRe", "-", "" + Math.Round(P.kre[i], 3) });
                    DB.Rows.Add(new String[] { "суммарный коэффициент потерь энергии", "-", "" + Math.Round(P.zetta1[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент скорости сопловой решетки \u03C6", "-", "" + Math.Round(P.phi[i], 3) });
                    DB.Rows.Add(new String[] { "действительная скорость выхода потока С1", "м/с", "" + Math.Round(P.C1[i], 3) });
                    DB.Rows.Add(new String[] { "угол направления относительной скорости входа потока \u03B21", "град", "" + Math.Round(P.betta1[i] * 180 / Math.PI, 3) });
                    DB.Rows.Add(new String[] { "относительная скорость выхода пара на рабочие лопатки W1", "м/с", "" + Math.Round(P.W1[i], 3) });
                    DB.Rows.Add(new String[] { "кинетическая энергия пара на входе в рабочую решетку \u0394Hвх", "кДж/кг", "" + Math.Round(P.delta_Hvx[i], 3) });
                    DB.Rows.Add(new String[] { "потеря энергии в сопловой решетке \u0394H1 ", "кДж/кг", "" + Math.Round(P.delta_H1[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание пара в действительном процессе за сопловой решеткой i1", "кДж/кг", "" + Math.Round(P.i1[i], 3) });
                    DB.Rows.Add(new String[] { "температура пара в действительном процессе за сопловой решеткой t1", "\u00B0C", "" + Math.Round(P.t1[i], 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара в действительном процессе за сопловой решеткой v1", "м³/кг", "" + Math.Round(P.v1[i], 3) });
                    DB.Rows.Add(new String[] { "влажность пара в действительном процессе за сопловой решеткой y1", "-", "" + Math.Round(P.y1[i], 3) });

                    DB.Rows.Add(new String[] { "ТЕПЛОВОЙ РАСЧЕТ РАБОЧЕЙ РЕШЕТКИ" });
                    DB.Rows.Add(new String[] { "теплосодержание заторможенного потока перед рабочей решеткой i1_", "кДж/кг", "" + Math.Round(P.i1_[i], 3) });
                    DB.Rows.Add(new String[] { "давление заторможенного потока перед рабочей решеткой p1_", "бар", "" + Math.Round(P.p1_[i] * 0.00001, 3) });
                    DB.Rows.Add(new String[] { "температура заторможенного потока перед рабочей решеткой t1_", "\u00B0С", "" + Math.Round(P.t1_[i] - 273.15, 3) });
                    DB.Rows.Add(new String[] { "удельный объём заторможенного потока перед рабочей решеткой v1_", "м³/кг", "" + Math.Round(P.v1_[i], 3) });
                    DB.Rows.Add(new String[] { "влажность заторможенного потока перед рабочей решеткой y1_", "-", "" + Math.Round(P.y1_[i], 3) });
                    DB.Rows.Add(new String[] { "изоэнтропийный тепловой перепад рабочей решетки по статическим параметрам H02", "кДж/кг", "" + Math.Round(P.H02[i], 3) });
                    DB.Rows.Add(new String[] { "изоэнтропийный тепловой перепад рабочей решетки по параметрам торможения H02_", "кДж/кг", "" + Math.Round(P.H02_[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание в конце изоэнтропийного расширения в рабочей решетке i2t", "кДж/кг", "" + Math.Round(P.i2t[i], 3) });
                    DB.Rows.Add(new String[] { "давление пара в изоэнтропийном процессе за рабочей решеткой p2t", "бар", "" + Math.Round(P.p2t[i] * 0.00001, 3) });
                    DB.Rows.Add(new String[] { "температура пара в изоэнтропийном процессе за рабочей решеткой t2t", "\u00B0C", "" + Math.Round(P.t2t[i] - 273.15, 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара в изоэнтропийном процессе за рабочей решеткой v2t", "м³/кг", "" + Math.Round(P.v2t[i], 3) });
                    DB.Rows.Add(new String[] { "влажность пара в изоэнтропийном процессе за рабочей решеткой y2t", "-", "" + Math.Round(P.y2t[i], 3) });
                    DB.Rows.Add(new String[] { "относительная теоретическая скорость на выходе из решетки W2t", "м/с", "" + Math.Round(P.W2t[i], 3) });
                    DB.Rows.Add(new String[] { "скорость звука a2t", "м/с", "" + Math.Round(P.a2t[i], 3) });
                    DB.Rows.Add(new String[] { "число Маха M2t", "-", "" + Math.Round(P.M2t[i], 3) });
                    DB.Rows.Add(new String[] { "отношение давлений \u03B52", "-", "" + Math.Round(P.eps2[i], 3) });
                    DB.Rows.Add(new String[] { "критическое давление p*2", "бар", "" + Math.Round(P.p2zv[i] * 0.00001, 3) });
                    DB.Rows.Add(new String[] { "критическая температура t*2", "\u00B0C", "" + Math.Round(P.t2zv[i] - 273.15, 3) });
                    DB.Rows.Add(new String[] { "критическое теплосодержание i*2", "кДж/кг", "" + Math.Round(P.i2zv[i] * 0.001, 3) });
                    DB.Rows.Add(new String[] { "критический удельный объём v*2", "м³/кг", "" + Math.Round(P.v2zv[i], 3) });
                    DB.Rows.Add(new String[] { "хорда профиля по среднему диаметру b2", "мм", "" + Math.Round(P.b2[i], 3) });
                    DB.Rows.Add(new String[] { "выходная высота рабочей решетки l2", "мм", "" + Math.Round(P.l2[i], 3) });
                    j += 52;
                    if (P.M2t[i] < 1)
                    {
                        DB.Rows.Add(new String[] { "площадь выходного сечения рабочей решетки F2", "м²", "" + Math.Round(P.F2[i], 3) });
                        DB.Rows.Add(new String[] { "эффективный угол выхода потока из решетки \u03b22э", "град", "" + Math.Round(P.betta2e[i], 3) });
                        DB.Rows.Add(new String[] { "угол выхода потока из решетки \u03b22", "град", "" + Math.Round(P.betta2[i], 3) });
                        DB.Rows.Add(new String[] { "угол отклонения потока в косом срезе решетки \u03b42", "град", "" + Math.Round(P.delta2[i], 3) });
                        j += 4;
                    }
                    if (P.M2t[i] >= 1 && P.M2t[i] <= 1.35)
                    {
                        DB.Rows.Add(new String[] { "площадь критического сечения сопловой решетки F*2", "м²", "" + Math.Round(P.F2zv[i], 3) });
                        DB.Rows.Add(new String[] { "площадь выходного сечения сопловой решетки F2", "м²", "" + Math.Round(P.F2[i], 3) });
                        DB.Rows.Add(new String[] { "критическая скорость истечения W*", "м/с", "" + Math.Round(P.Wzv[i], 3) });
                        DB.Rows.Add(new String[] { "эффективный угол выхода потока из решетки \u03b22э", "град", "" + Math.Round(P.betta2e[i], 3) });
                        DB.Rows.Add(new String[] { "угол выхода потока из решетки \u03b22", "град", "" + Math.Round(P.betta2[i], 3) });
                        DB.Rows.Add(new String[] { "угол отклонения потока в косом срезе решетки \u03b42", "град", "" + Math.Round(P.delta2[i], 3) });
                        j += 6;
                    }
                    if (P.M2t[i] > 1.35)
                    {
                        DB.Rows.Add(new String[] { "площадь критического сечения сопловой решетки F*2", "м²", "" + Math.Round(P.F2zv[i], 3) });
                        DB.Rows.Add(new String[] { "площадь выходного сечения сопловой решетки F2", "м²", "" + Math.Round(P.F2[i], 3) });
                        DB.Rows.Add(new String[] { "степень расширения канала сопла f2", "-", "" + Math.Round(P.f2[i], 3) });
                        DB.Rows.Add(new String[] { "эффективный угол выхода потока из решетки \u03b22э", "град", "" + Math.Round(P.betta2e[i], 3) });
                        DB.Rows.Add(new String[] { "угол выхода потока из решетки \u03b22", "град", "" + Math.Round(P.betta2[i], 3) });
                        DB.Rows.Add(new String[] { "угол отклонения потока в косом срезе решетки \u03b42", "град", "" + Math.Round(P.delta2[i], 3) });
                        DB.Rows.Add(new String[] { "угол в критическом сечении решетки \u03b2*", "град", "" + Math.Round(P.bettazv[i], 3) });
                        j += 7;
                    }

                    DB.Rows.Add(new String[] { "РАСЧЕТ ГЕОМЕТРИИ РАБОЧЕЙ РЕШЕТКИ" });
                    DB.Rows.Add(new String[] { "тип профиля", "", "" + P.P_R[i] });
                    DB.Rows.Add(new String[] { "угол установки (\u03B2y)T", "град", "" + Math.Round(P.bettay[i], 3) });
                    DB.Rows.Add(new String[] { "относительный шаг t2T", "-", "" + Math.Round(P.topt2[i], 3) });
                    DB.Rows.Add(new String[] { "ширина решетки B2", "мм", "" + Math.Round(P.B2[i], 3) });
                    DB.Rows.Add(new String[] { "хорда профиля b2", "мм", "" + Math.Round(P.b2[i], 3) });
                    DB.Rows.Add(new String[] { "число каналов в решетке z2", "шт.", "" + Math.Round(P.z2[i], 3) });
                    DB.Rows.Add(new String[] { "шаг решетки t2", "мм", "" + Math.Round(P.t2_geom[i], 3) });
                    DB.Rows.Add(new String[] { "ширина канала в узком сечении О2", "мм", "" + Math.Round(P.O2[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент кинематической вязкости v2", "м²/c", "" + Math.Round(P.v2kin[i], 6) });
                    DB.Rows.Add(new String[] { "коэффициент расхода рабочей решетки \u03BC2", "-", "" + Math.Round(P.nu2[i], 3) });

                    DB.Rows.Add(new String[] { "РАСЧЕТ КОЭФФИЦИЕНТА ПОТЕРЬ ЭНЕРГИИ РЕШЕКТИ" });
                    DB.Rows.Add(new String[] { "угол поворота в рабочей решетке \u0394\u03B2", "град", "" + Math.Round(P.delta_BETTA[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент потерь энергии без учета поправок \u03B60", "-", "" + Math.Round(P.zetta0r[i], 3) });
                    DB.Rows.Add(new String[] { "поправка km", "-", "" + Math.Round(P.kmR[i], 3) });
                    DB.Rows.Add(new String[] { "поправка ka", "-", "" + Math.Round(P.kb[i], 3) });
                    DB.Rows.Add(new String[] { "поправка kRe", "-", "" + Math.Round(P.kreR[i], 3) });
                    DB.Rows.Add(new String[] { "суммарный коэффициент потерь энергии", "-", "" + Math.Round(P.zetta2[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент скорости рабочей решетки \u03C8", "-", "" + Math.Round(P.psi[i], 3) });
                    DB.Rows.Add(new String[] { "действительная относительная скорость выхода потока W2", "м/с", "" + Math.Round(P.W2[i], 3) });
                    j += 20;
                    if (P.alfa2[i] < 0)
                    {
                        DB.Rows.Add(new String[] { "угол направления абсолютной скорости выхода потока \u03B12", "град", "" + Math.Round(180 - Math.Abs(P.alfa2[G] * 180 / Math.PI), 3) });
                    }
                    else
                    {
                        DB.Rows.Add(new String[] { "угол направления абсолютной скорости выхода потока \u03B12", "град", "" + Math.Round(P.alfa2[G] * 180 / Math.PI, 3) });
                    }
                    j++;
                    DB.Rows.Add(new String[] { "абсолютная скорость выхода пара из рабочей решетки C2", "м/с", "" + Math.Abs(Math.Round(P.C2[i], 3)) });
                    DB.Rows.Add(new String[] { "кинетическая энергия пара на выходе из рабочей решетки \u0394Hвс", "кДж/кг", "" + Math.Round(P.delta_Hvc[i], 3) });
                    DB.Rows.Add(new String[] { "потеря энергии в рабочей решетке \u0394H2 ", "кДж/кг", "" + Math.Round(P.delta_H2[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание пара в действительном процессе за рабочей решеткой i2", "кДж/кг", "" + Math.Round(P.i2[i], 3) });
                    DB.Rows.Add(new String[] { "температура пара в действительном процессе за рабочей решеткой t2", "\u00B0C", "" + Math.Round(P.t2[i], 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара в действительном процессе за рабочей решеткой v2", "м³/кг", "" + Math.Round(P.v2[i], 3) });
                    DB.Rows.Add(new String[] { "влажность пара в действительном процессе за рабочей решеткой y2", "-", "" + Math.Round(P.y2[i], 3) });

                    DB.Rows.Add(new String[] { "РАСЧЕТ ДОП. ПОТЕРЬ, КПД И МОЩНОСТИ СТУПЕНИ" });
                    DB.Rows.Add(new String[] { "располагаемая энергия ступени остека E0", "кДж/кг", "" + Math.Round(P.E0[i], 3) });
                    DB.Rows.Add(new String[] { "относительный лопаточный КПД сутпени \u03B7о.л.", "-", "" + Math.Round(P.eta_ol[i], 3) });
                    DB.Rows.Add(new String[] { "средний коэффициент кинематической вязкости v", "м²/c", "" + Math.Round(P.vkin[i], 6) });
                    DB.Rows.Add(new String[] { "число Рейнольдса Re", "-", "" + Math.Round(P.Reu[i]) });
                    DB.Rows.Add(new String[] { "коэффициент трения kтр", "-", "" + Math.Round(P.ktr[i], 3) });
                    DB.Rows.Add(new String[] { "относительные потери энергии на трение \u03BEтр", "-", "" + Math.Round(P.xi_tr[i], 4) });
                    DB.Rows.Add(new String[] { "потери энергии на вентиляцию \u03BEв", "-", "" + Math.Round(P.xi_v[i], 3) });
                    DB.Rows.Add(new String[] { "потери энергии на концах дуг сопловых сегментов \u03BEс", "-", "" + Math.Round(P.xi_c[i], 3) });
                    DB.Rows.Add(new String[] { "диаметр диафрагменного уплотнения d1y", "м", "" + Math.Round(P.d1y[i], 3) });
                    DB.Rows.Add(new String[] { "величина зазора диафрагменного уплотнения s1y", "м", "" + Math.Round(P.sigma1y[i], 3) });
                    DB.Rows.Add(new String[] { "площадь зазора диафрагменного уплотнения F1y", "м²", "" + Math.Round(P.F1y[i], 3) });
                    DB.Rows.Add(new String[] { "число гребешков диафрагменного уплотнения z1y", "шт.", "" + Math.Round(P.z1y[i], 3) });
                    DB.Rows.Add(new String[] { "поправочный коэффициент ky", "-", "" + Math.Round(P.ky[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент расхода диафрагменного уплотнения \u03BC1y", "-", "" + Math.Round(P.nu1y[i], 3) });
                    DB.Rows.Add(new String[] { "относительная потеря от утечек через диафрагменное уплотнение \u03BEд.у.", "-", "" + Math.Round(P.xi_du[i], 3) });
                    DB.Rows.Add(new String[] { "степень реакции на периферии \u03C1п", "-", "" + Math.Round(P.Rop[i], 3) });
                    DB.Rows.Add(new String[] { "открытый осевой зазор \u03B4a", "мм", "" + Math.Round(P.sigmaa[i], 3) });
                    DB.Rows.Add(new String[] { "открытый периферийный зазор \u03B4r", "мм", "" + Math.Round(P.sigmar[i], 3) });
                    DB.Rows.Add(new String[] { "число радиальных гребешков z2y", "шт.", "" + Math.Round(P.z2y[i], 3) });
                    if (P.bandazh[i] == 1)
                    {
                        DB.Rows.Add(new String[] { "эквивалентный зазор для ступени с обандаженными рабочими лопатками \u03B4экв", "мм", "" + Math.Round(P.sigmaekv[i], 3) });
                    }
                    if (P.bandazh[i] == 0)
                    {
                        DB.Rows.Add(new String[] { "эквивалентный зазор для ступени с рабочими лопатками без бондажа \u03B4экв", "мм", "" + Math.Round(P.sigmaekv_bez[i], 3) });
                    }
                    DB.Rows.Add(new String[] { "суммарный коэффициент потерь от утечки поверх рабочей решетки \u03BEп.у.", "-", "" + Math.Round(P.xi_pu[i], 3) });
                    DB.Rows.Add(new String[] { "площадь зазора периферийного уплотнения F2y", "м²", "" + Math.Round(P.F2y[i], 3) });
                    DB.Rows.Add(new String[] { "коэффициент потерь от влажности \u03BEвл", "-", "" + Math.Round(P.xi_vl[i], 3) });
                    DB.Rows.Add(new String[] { "внутренний относительный КПД ступени \u03B7oi.", "-", "" + Math.Round(P.eta_oi[i], 3) });
                    DB.Rows.Add(new String[] { "абсолютная величина потери энергии на трение \u0394Hтр", "кДж/кг", "" + Math.Round(P.delta_Htr[i], 3) });
                    DB.Rows.Add(new String[] { "абсолютная величина потери энергии от парциальности \u0394Hп", "кДж/кг", "" + Math.Round(P.delta_Hp[i], 3) });
                    DB.Rows.Add(new String[] { "абсолютная величина потери энергии от утечек \u0394Hут", "кДж/кг", "" + Math.Round(P.delta_Hut[i], 3) });
                    DB.Rows.Add(new String[] { "абсолютная величина потери энергии от влажности \u0394Hвл", "кДж/кг", "" + Math.Round(P.delta_Hvl[i], 3) });
                    DB.Rows.Add(new String[] { "потери мощности на трение Nтр", "кВт", "" + Math.Round(P.Ntr[i], 3) });
                    DB.Rows.Add(new String[] { "потери мощности на вентиляцию Nв", "кВт", "" + Math.Round(P.Nv[i], 3) });
                    DB.Rows.Add(new String[] { "полезно использованный теплоперепад ступени Hi", "кДж/кг", "" + Math.Round(P.Hi[i], 3) });
                    j += 39;
                    if (P.SEP[i] > 0 && P.y0[i] >= 0.03)
                    {
                        DB.Rows.Add(new String[] { "коэффициент сепарации влаги в ступени \u03C8сеп", "-", "" + Math.Round(P.SEP[i], 3) });
                        DB.Rows.Add(new String[] { "доля отведенной влаги в сепарационном устройстве ступени \u0394y", "%", "" + Math.Round(P.delta_y[i], 3) });
                        DB.Rows.Add(new String[] { "массовое количество влаги, отведенной в сепарационном устройстве \u0394G`", "кг/с", "" + Math.Round(P.delta_Gshtrix[i], 3) });
                        DB.Rows.Add(new String[] { "относительная величина отсасываемого пара во влагозаборную камеру \u0394G``_", "-", "0.005" });
                        DB.Rows.Add(new String[] { "абсолютная величина отсасываемого пара во влагозаборную камеру \u0394G``", "кг/с", "" + Math.Round(P.delta_Gshtrix2[i], 3) });
                        DB.Rows.Add(new String[] { "уменьшение расхода пара через следующую ступень \u0394G", "кг/с", "" + Math.Round(((P.delta_Gshtrix[G] + P.delta_Gshtrix2[G])), 3) });
                        DB.Rows.Add(new String[] { "влажность пара за ступенью по статическим параметрам пара y`2k", "-", "" + Math.Round(P.y2kshtrix[i], 3) });
                        DB.Rows.Add(new String[] { "теплосодержание пара за ступенью по статическим параметрам пара i`2k", "кДж/кг", "" + Math.Round(P.h2kshtrix[i], 3) });
                        j += 8;
                    }

                    DB.Rows.Add(new String[] { "ПАРАМЕТРЫ ПАРА ЗА СТУПЕНЬЮ" });
                    DB.Rows.Add(new String[] { "коэффициент использования энергии выходной скорости ступени \u03C7", "-", "" + Math.Round(P.X[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание пара по статическим параметрам i2k", "кДж/кг", "" + Math.Round(P.i2k[i], 3) });
                    DB.Rows.Add(new String[] { "величина подсушки пара при наличии сепарационного утсройства в ступени \u0394Hсеп", "кДж/кг", "" + Math.Round(P.delta_Hsep[i], 3) });
                    DB.Rows.Add(new String[] { "давление пара перед следующей ступенью отсека p0 по статическим параметрам", "бар", "" + Math.Round(P.p2k[i] * 0.00001, 3) });
                    DB.Rows.Add(new String[] { "теплосодержание пара перед следующей ступенью отсека i0 по статическим параметрам", "кДж/кг", "" + Math.Round(P.i2k[i], 3) });
                    DB.Rows.Add(new String[] { "температура пара перед следующей ступенью отсека t0 по статическим параметрам", "\u00B0C", "" + Math.Round(P.t2k[i], 3) });
                    DB.Rows.Add(new String[] { "энтропия пара перед следующей ступенью отсека s0 по статическим параметрам", "кДж/кг*К", "" + Math.Round(P.s2k[i], 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара перед следующей ступенью отсека v0 по статическим параметрам", "м³/кг", "" + Math.Round(P.v2k[i], 3) });
                    DB.Rows.Add(new String[] { "влажность пара перед следующей ступенью отсека y0 по статическим параметрам", "-", "" + Math.Round(P.y2k[i], 3) });
                    DB.Rows.Add(new String[] { "теплосодержание пара по параметрам торможения i2k_", "кДж/кг", "" + Math.Round(P.i2k_[i], 3) });
                    DB.Rows.Add(new String[] { "давление пара перед следующей ступенью отсека по параметрам торможения p0_", "бар", "" + Math.Round(P.p2k_[i] * 0.00001, 3) });
                    DB.Rows.Add(new String[] { "теплосодержание пара перед следующей ступенью отсека i0_ по статическим параметрам", "кДж/кг", "" + Math.Round(P.i2k_[i], 3) });
                    DB.Rows.Add(new String[] { "температура пара перед следующей ступенью отсека t0_ по статическим параметрам", "\u00B0C", "" + Math.Round(P.t2k_[i], 3) });
                    DB.Rows.Add(new String[] { "энтропия пара перед следующей ступенью отсека s0_ по статическим параметрам", "кДж/к\u00B7*К", "" + Math.Round(P.s2k[i], 3) });
                    DB.Rows.Add(new String[] { "удельный объём пара перед следующей ступенью отсека v0_ по статическим параметрам", "м³/кг", "" + Math.Round(P.v2k_[i], 3) });
                    DB.Rows.Add(new String[] { "влажность пара перед следующей ступенью отсека y0_ по статическим параметрам", "-", "" + Math.Round(P.y2k_[i], 3) });
                    j += 18;
                }
            }
        }

        private void импортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Excel File 97-2003 Worksheet (*.xls)|*.xls";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK && sfd.FileName != "")
            {
                if (Path.GetExtension(sfd.FileName) == ".xls")
                {
                    ExcelLibrary.SpreadSheet.Worksheet worksheet = new ExcelLibrary.SpreadSheet.Worksheet("Параметры ступеней");
                    ExcelLibrary.SpreadSheet.Workbook workbook = new ExcelLibrary.SpreadSheet.Workbook();
                    string[] columnsName = new string[] { "Величина", "Единица измерения", "Значение" };
                    for (int i = 0; i < columnsName.Length; i++)
                    {
                         worksheet.Cells[1, i] = new ExcelLibrary.SpreadSheet.Cell(columnsName[i]);
                    }
                    for (int i = 0; i < j; i++)
                    {
                         worksheet.Cells[i + 2, 0] = new ExcelLibrary.SpreadSheet.Cell((String)DB.Rows[i].Cells[0].Value);
                         worksheet.Cells[i + 2, 1] = new ExcelLibrary.SpreadSheet.Cell((String)DB.Rows[i].Cells[1].Value);
                         worksheet.Cells[i + 2, 2] = new ExcelLibrary.SpreadSheet.Cell((String)DB.Rows[i].Cells[2].Value);
                    }
                    worksheet.Cells.ColumnWidth[0] = 30000;

                    workbook.Worksheets.Add(worksheet);
                    workbook.Save(sfd.FileName);
                }
            }
        }

        private void экспортВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Word file (*.docx)|*.docx";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK && sfd.FileName != "")
            {
                if (Path.GetExtension(sfd.FileName) == ".docx")
                {
                    DocX doc = DocX.Create(sfd.FileName);
                    Paragraph p1 = doc.InsertParagraph();
                    p1.AppendLine("Подробный тепловой расчет ступеней паровой турбины").FontSize(14);
                    p1.AppendLine();
                    Table t = doc.AddTable(j, 3);
                    t.Alignment = Alignment.center;
                    t.SetColumnWidth(0, 200);
                    t.Rows[0].Cells[0].Paragraphs.First().Append("Величина").FontSize(12);
                    t.Rows[0].Cells[1].Paragraphs.First().Append("Единица измерения").FontSize(12);
                    t.Rows[0].Cells[2].Paragraphs.First().Append("Значение").FontSize(12);
                    for (int i = 1; i < j; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            t.Rows[i].Cells[k].Paragraphs.First().Append("" + (String)DB.Rows[i].Cells[k].Value);
                            
                        }
                    }
                    doc.InsertTable(t);
                    doc.Save();
                }
            }
        }
    }
}
