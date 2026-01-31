using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A1_Calculator
{
    public partial class Calc : Form
    {
        double ev1, ev2;
        string op;
        double mem = 0;

        public Calc()
        {
            InitializeComponent();
        }

        private void Delete(object sender, EventArgs e)
        {
            if(TxtRes.Text.Length > 0)
            {
                TxtRes.Text = TxtRes.Text.Remove(TxtRes.Text.Length - 1, 1);
            }

            if (TxtRes.Text == "")
            {
                TxtRes.Text = "0";
            }
        }

        private void EntNo(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            if(Txtmem.Text.Contains("=") || TxtRes.Text == "Math Error")
            {
                Txtmem.Text = "";
                TxtRes.Text = "";
            }

            if (TxtRes.Text == "0")
                TxtRes.Text = "";
            { 
                if (num.Text == ".")
                    {
                        if (!TxtRes.Text.Contains("."))
                        {
                            TxtRes.Text = TxtRes.Text + num.Text;
                        }
                    }
                else
                {
                    TxtRes.Text += num.Text;
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 426;
            TxtRes.Width = 390;
            Txtmem.Width = 390;

            this.BackColor = Color.White;
            TxtRes.BackColor = Color.White;
            TxtRes.ForeColor = Color.Black;
            Txtmem.BackColor = Color.White;
            Txtmem.BackColor = Color.White;
            Txtmem.ForeColor = Color.DimGray;

            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
            menuStrip1.RenderMode = ToolStripRenderMode.System;

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.Black;
                    btn.BackColor = Color.Transparent;

                    btn.FlatAppearance.MouseOverBackColor = Color.Moccasin;
                }
            }
        }

        private void EnOp(object sender, EventArgs e)
        {
            try
            {
                Button oper = (Button)sender;
                ev1 = double.Parse(TxtRes.Text);
                if (Txtmem.Text.Contains("="))
                {
                    Txtmem.Text = TxtRes.Text + " " + oper.Text + " ";
                }
                else
                {
                    Txtmem.Text += TxtRes.Text + " " + oper.Text + " ";
                }

                op = oper.Text;
                TxtRes.Text = "";
            }
            catch (Exception)
            {
                TxtRes.Text = "Math Error";
                return;
            }
        }

        private void plmin(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TxtRes.Text) || TxtRes.Text != "0")
                {
                    double q = double.Parse(TxtRes.Text);
                    q = -q;

                    TxtRes.Text = q.ToString();

                    if (Txtmem.Text.Contains("="))
                    {
                        Txtmem.Text = TxtRes.Text;
                    }
                }

            }
            catch (Exception)
            {
                TxtRes.Text = "Math Error";
                return;
            }
        }

        private void ButC(object sender, EventArgs e)
        {
            TxtRes.Text = "0";
            Txtmem.Text = "";
        }

        private void ButCE(object sender, EventArgs e)
        {
            TxtRes.Text = "0";
            string f, s;
            f = ev1.ToString();
            s = ev2.ToString();

            f = "";
            s = "";
        }

        private void ButPI(object sender, EventArgs e)
        {
            double pi = Math.PI;
            Txtmem.Text = "π";
            TxtRes.Text = pi.ToString();
        }

        private void ButLog(object sender, EventArgs e)
        {
            try
            {
                if (Txtmem.Text == "0" || TxtRes.Text == "0" || TxtRes.Text.Contains("-") || Txtmem.Text.Contains("-"))
                {
                    TxtRes.Text = "Math Error";
                    return;
                }

                double n = double.Parse(TxtRes.Text);
                double log = Math.Log10(n);
                Txtmem.Text = $"log({n})";
                TxtRes.Text = log.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }
        private void ButSq(object sender, EventArgs e)
        {
            try
            {
                if (Txtmem.Text.Contains("-") || TxtRes.Text.Contains("-"))
                {
                    TxtRes.Text = "Math Error";
                    return;
                }

                double n = double.Parse(TxtRes.Text);
                double sq = Math.Sqrt(n);
                Txtmem.Text = $"√({n})";
                TxtRes.Text = sq.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButE(object sender, EventArgs e)
        {
            double n = Math.E;
            Txtmem.Text = "e";
            TxtRes.Text = n.ToString();
        }

        private void ButSn(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text) * (Math.PI / 180);
                double sn = Math.Sin(n);
                Txtmem.Text = $"sin({double.Parse(TxtRes.Text)})";
                TxtRes.Text = sn.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }
        private void ButCo(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text) * (Math.PI / 180);
                double c = Math.Cos(n);
                Txtmem.Text = $"cos({double.Parse(TxtRes.Text)})";
                TxtRes.Text = c.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButTa(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text) * (Math.PI / 180);
                double t = Math.Tan(n);
                Txtmem.Text = $"tan({double.Parse(TxtRes.Text)})";
                TxtRes.Text = t.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButLn(object sender, EventArgs e)
        {
            try
            {
                if (Txtmem.Text == "0" || TxtRes.Text == "0" || TxtRes.Text.Contains("-") || Txtmem.Text.Contains("-"))
                {
                    TxtRes.Text = "Math Error";
                    return;
                }

                double n = double.Parse(TxtRes.Text);
                double ln = Math.Log(n);
                Txtmem.Text = $"ln({n})";
                TxtRes.Text = ln.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButSh(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text);
                double sh = Math.Sinh(n);
                Txtmem.Text = $"sinh({n})";
                TxtRes.Text = sh.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";

            }
        }

        private void ButCh(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text);
                double sh = Math.Cosh(n);
                Txtmem.Text = $"cosh({n})";
                TxtRes.Text = sh.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButTh(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text);
                double th = Math.Tanh(n);
                Txtmem.Text = $"tanh({n})";
                TxtRes.Text = th.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void Butfrac(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text);

                if(n == 0)
                {
                    TxtRes.Text = "Math Error";
                    return;
                }
                else
                {
                    double frac = 1 / n;
                    Txtmem.Text = $"1 / {n}";
                    TxtRes.Text = frac.ToString();
                }
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButDec(object sender, EventArgs e)
        {
            try
            {
                double n = double.Parse(TxtRes.Text);
                double dec = (int)n;
                Txtmem.Text = n.ToString();
                TxtRes.Text = dec.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButBin(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(TxtRes.Text);
                Txtmem.Text = a.ToString();
                TxtRes.Text = Convert.ToString(a, 2);
            }
            catch(Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButHex(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(TxtRes.Text);
                Txtmem.Text = a.ToString();
                TxtRes.Text = Convert.ToString(a, 16).ToUpper();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";
            }
        }

        private void ButSci(object sender, EventArgs e)
        {
            this.Width = 832;
            TxtRes.Width = 760;
            Txtmem.Width = 760;
        }

        private void ButStan(object sender, EventArgs e)
        {
            this.Width = 426;
            TxtRes.Width = 390;
            Txtmem.Width = 390;
        }

        private void standardToolStripMenuItem2_Click(object sender, EventArgs e)
        {}

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(32, 32, 32);
            TxtRes.BackColor = Color.FromArgb(32, 32, 32);
            TxtRes.ForeColor = Color.White;
            Txtmem.BackColor = Color.FromArgb(32, 32, 32);
            Txtmem.ForeColor = Color.Gray;

            menuStrip1.BackColor = Color.FromArgb(32, 32, 32);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.RenderMode = ToolStripRenderMode.System;

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.FloralWhite;
                   
                    
                    btn.BackColor = Color.FromArgb(32, 32, 32);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(59,59,59);
                }
            }
        }

        private void lightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            TxtRes.BackColor = Color.White;
            TxtRes.ForeColor = Color.Black;
            Txtmem.BackColor = Color.White;
            Txtmem.ForeColor = Color.DimGray;

            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
            menuStrip1.RenderMode = ToolStripRenderMode.System;

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.Black;
                    btn.BackColor = Color.Transparent;

                    btn.FlatAppearance.MouseOverBackColor = Color.Moccasin;
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {}

        private void ButPer(object sender, EventArgs e)
        {
            double n = double.Parse(TxtRes.Text);
            double m = n / 100;
            Txtmem.Text = $"{n}%";
            TxtRes.Text = m.ToString();
        }

        private void Exit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Txtmem_TextChanged(object sender, EventArgs e)
        {}

        private void TxtRes_TextChanged(object sender, EventArgs e)
        {}

        private void Butmr(object sender, EventArgs e)
        {
            TxtRes.Text = mem.ToString();
        }

        private void Butmc(object sender, EventArgs e)
        {
            mem = 0;
        }

        private void Butmp(object sender, EventArgs e)
        {
            mem += double.Parse(TxtRes.Text);
            TxtRes.Text = mem.ToString();
        }

        private void Butmm(object sender, EventArgs e)
        {
            mem -= double.Parse(TxtRes.Text);
            TxtRes.Text = mem.ToString();
        }

        private void Butms(object sender, EventArgs e)
        {
            mem = double.Parse(TxtRes.Text);
            TxtRes.Text = mem.ToString();
        }

        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1220;
            TxtRes.Width = 760;
            Txtmem.Width = 760;

            temp.Visible = true;
            unitconv.Visible = false;
        }


        string con = "";

        private void celtofa(object sender, EventArgs e)
        {
            con = "a";
        }
        private void fahtocel(object sender, EventArgs e)
        {
            con = "b";
        }

        private void celtokel(object sender, EventArgs e)
        {
            con = "c";
        }

        private void keltocel(object sender, EventArgs e)
        {
            con = "d";
        }

        private void fahtokel(object sender, EventArgs e)
        {
            con = "e";
        }

        private void keltofah(object sender, EventArgs e)
        {
            con = "f";

        }

        private void convBut(object sender, EventArgs e)
        {
            try
            {
                user_ent.Focus();

                if (string.IsNullOrEmpty(user_ent.Text))
                {
                    res_show.Text = "Enter Value";
                    return;
                }
                else
                {
                    double a = double.Parse(user_ent.Text);
                    double res = 0;

                    switch (con)
                    {
                        case "a":
                            res = (a * 9 / 5) + 32;
                            break;
                        case "b":
                            res = (a - 32) * 5 / 9;
                            break;
                        case "c":
                            res = a + 273.15;
                            break;
                        case "d":
                            if (a < 0)
                            {
                                res_show.Text = "Invalid Input";
                                user_ent.Text = "";
                                return;
                            }
                            else
                            {
                                res = a - 273.15;
                            }
                            break;
                        case "e":
                            res = (a - 32) * 5 / 9 + 273.15;
                            break;
                        case "f":
                            if (a < 0)
                            {
                                res_show.Text = "Invalid Input";
                                user_ent.Text = "";
                                return;
                            }
                            else
                            {
                                res = (a - 273.15) * 9 / 5 + 32;
                            }
                            break;
                        default:
                            res_show.Text = "Select Conversion Type";
                            return;
                    }
                    res_show.Text = $"{res:F2}";
                }
            }
            catch (Exception ex)
            {
                res_show.Text = "Conversion Error";
            }
        }

        private void UnConv(object sender, EventArgs e)
        {
            this.Width = 1220;
            TxtRes.Width = 760;
            Txtmem.Width = 760;

            temp.Visible = false;
            unitconv.Visible = true;

            unitconv.Location = new Point(828, 40);

            len.Visible = true;
            wgt.Visible = false;
            area.Visible = false;

        }

        string clen = "";
        private void mmtom(object sender, EventArgs e)
        {
            clen = "mm";
        }
        private void cmtoin(object sender, EventArgs e)
        {
            clen = "cm";
        }
        private void mtoft(object sender, EventArgs e)
        {
            clen = "mt";
        }
        private void kmtomi(object sender, EventArgs e)
        {
            clen = "km";
        }
        private void lengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            len.Visible = true;
            wgt.Visible = false;
            area.Visible = false;
            res_show2.Text = " ";

            foreach (Control c in len.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
        }

        string cweight = "";
        private void weimass(object sender, EventArgs e)
        {
            len.Visible = false;
            wgt.Visible = true;
            area.Visible = false;
            res_show2.Text = " ";

            foreach (Control c in wgt.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
        }

        private void gtoz(object sender, EventArgs e)
        {
            cweight = "g";
        }

        private void kgpo(object sender, EventArgs e)
        {
            cweight = "kg";
        }

        private void metpo(object sender, EventArgs e)
        {
            cweight = "m";
        }

        private void mgtog(object sender, EventArgs e)
        {
            cweight = "mg";
        }

        string carea = "";
        private void Unare(object sender, EventArgs e)
        {
            area.Visible = true;
            len.Visible = false;
            wgt.Visible = false;
            res_show2.Text = " ";

            foreach(Control c in area.Controls)
            {
                if(c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
        }

        private void hecare(object sender, EventArgs e)
        {
            carea = "hec";
        }

        private void macre(object sender, EventArgs e)
        {
           carea = "mac";
        }

        private void kmi(object sender, EventArgs e)
        {
            carea = "kmi";
        }

        private void mft(object sender, EventArgs e)
        {
            carea = "mft";
        }
        private void resBut(object sender, EventArgs e)
        {
            user_ent.Text = "";
            res_show.Text = "";
            res_show2.Text = "";
            user_in2.Text = "";
            con = "";
            clen = "";
            cweight = "";

            foreach(Control c in temp.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
            foreach (Control c in len.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
            foreach (Control c in wgt.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
            foreach (Control c in area.Controls)
            {
                if(c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }

            user_ent.Focus();
        }

        private void lenconv(object sender, EventArgs e)
        {
            try
            {
                user_in2.Focus();
                if (string.IsNullOrEmpty(user_in2.Text))
                {
                    res_show2.Text = "Enter Value";
                    return;
                }
                else
                {
                    double a = double.Parse(user_in2.Text);
                    double res = 0;


                    if (wgt.Visible)
                    {
                        switch (cweight)
                        {
                            case "g":
                                res = a / 28.3495;
                                break;
                            case "kg":
                                res = a * 2.20462;
                                break;
                            case "m":
                                res = a * 2204.62; ;
                                break;
                            case "mg":
                                res = a / 1000;
                                break;
                            default:
                                res_show2.Text = "Select Conversion Type";
                                return;
                        }
                    }
                    else if (len.Visible)
                    {
                        switch (clen)
                        {
                            case "mm":
                                res = a / 1000;
                                break;
                            case "cm":
                                res = a / 2.54;
                                break;
                            case "mt":
                                res = a * 3.28084;
                                break;
                            case "km":
                                res = a * 0.621371;
                                break;
                            default:
                                res_show2.Text = "Select Conversion Type";
                                return;
                        }
                    }
                    else
                    {
                        switch (carea)
                        {
                            case "hec":
                                res = a * 2.47105;
                                break;
                            case "mac":
                                res = a * 4046.86;
                                break;
                            case "kmi":
                                res = a * 0.386102;
                                break;
                            case "mft":
                                res = a * 10.7639;
                                break;
                            default:
                                res_show2.Text = "Select Conversion Type";
                                return;
                        }
                    }
                    res_show2.Text = $"{res:F4}";
                }
            }
            catch (Exception ex)
            {
                res_show2.Text = "Conversion Error";
            }
        }

        private void factBut(object sender, EventArgs e)
        {
            try
            {


                double n = double.Parse(TxtRes.Text);

                if (n < 0 || n % 1 != 0)
                {
                    TxtRes.Text = "Math Error";
                    return;
                }

                double fact = 1;
                for (int i = 1; i <= n; i++)
                {
                    fact *= i;
                }

                Txtmem.Text = $"fact({n})";
                TxtRes.Text = fact.ToString();
            }
            catch (Exception xe)
            {
                TxtRes.Text = "Math Error";

            }
        }

        private void ButEq(object sender, EventArgs e)
        {
            try
            {
                if(Txtmem.Text.Contains("="))
                {
                    return;
                }

               
                ev2 = double.Parse(TxtRes.Text);
                if (op == "exp" || op == "xⁿ" || op == "mod")
                {
                    switch (op)
                    { 
                        case "exp":
                            Txtmem.Text = $"{ev1}e + {ev2} =";
                            double m = ev1 * Math.Pow(10, ev2);
                            TxtRes.Text = m.ToString();
                            break;
                        case "xⁿ":
                            Txtmem.Text = $"{ev1}^ ({ev2}) =";
                            double p = Math.Pow(ev1, ev2);
                            TxtRes.Text = p.ToString();
                            break;
                        case "mod":
                            Txtmem.Text = $"{ev1} mod {ev2}=";
                            double a = ev1 % ev2;
                            TxtRes.Text = a.ToString();
                            break;
                    }
                }
                else
                {
                    string ex = Txtmem.Text + TxtRes.Text;
                    string comp = ex.Replace("×", "*").Replace("÷", "/");

                    var res = new DataTable().Compute(comp, null);
                    string fn = res.ToString();

                    if(fn == "∞" || fn == "Nan" || fn == "Infinity")
                    {
                        TxtRes.Text = "Math Error";
                        Txtmem.Text = "";
                    }
                    else
                    {
                        Txtmem.Text = ex + " = ";
                        TxtRes.Text = fn;
                    }


                }
                op = "";
            }
            catch(Exception ex)
            {
                TxtRes.Text = "Math Error";
                return;
            }
        }
    }
}
