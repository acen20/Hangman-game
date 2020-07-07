using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace HangmanTrial
{
    public partial class Form1 : MetroForm
    {
        //all urdu characters
        char[] all = { 'ا', 'ب', 'پ', 'ت', 'ٹ', 'ث', 'ج', 'چ', 'ح', 'خ', 'د', 'ذ', 'ر', 'ڑ', 'ڈ', 'ز', 'ژ', 'ل', 'م', 'ن', 'ں', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'و', 'ہ', 'ک', 'گ', 'ی', 'ے', 'س', 'ش', 'ف', 'ق'};

        //array3 contains 3 letter urdu words i.e Easy Level
        string[] array3 = { "بلی", "کتا", "کان", "باپ"};
        //array4 contains 4 letter urdu words i.e Medium Level
        string[] array4 = { "گاڑی", "انار" };
        //array5 contains 5 letter urdu words i.e Advance Level
        string[] array5 = { "جماعت" };

        List<char> saveletters = new List<char>(); //the characters of selected word
        int currentstate = 0;//HangMan states

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alphaGB.Visible = false;
            dashGB.Visible = false;
            dashGB.Controls[0].Visible = true;

        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            DialogResult r=MetroMessageBox.Show(this, "ہار مان گۓ؟", "بند کر دیں؟", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void playBTN_Click(object sender, EventArgs e)
        {
            hidepictures();
            showhidedifficulty(1);
        }

        private void easyBTN_Click(object sender, EventArgs e)
        {
            showhidedifficulty(0);
            if (playBTN.Text == "کھیل شروع کیا جاۓ")
            {
                layButtons();
                setButtonText();
                string word = getword(1);
                for (int i = 0; i < word.Length; i++)
                    saveletters.Add(word[i]);
                for (int i = 0; i < saveletters.Count; i++)
                    dashGB.Controls[i].Visible = true;
                playBTN.Text = "دوبارہ شروع کریں";
                alphaGB.Visible = true;
                dashGB.Visible = true;
            }
            else if (playBTN.Text == "دوبارہ شروع کریں")
            {
                DialogResult r = MetroMessageBox.Show(this, "دوبارہ شروع کریں؟", "پکی بات ہے؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    ResetAll();
                    string word = getword(1);
                    for (int i = 0; i < word.Length; i++)
                        saveletters.Add(word[i]);
                    for (int i = 0; i < saveletters.Count; i++)
                        dashGB.Controls[i].Visible = true;
                }
            }
        }

        private void medBTN_Click(object sender, EventArgs e)
        {
            showhidedifficulty(0);
            if (playBTN.Text == "کھیل شروع کیا جاۓ")
            {
                layButtons();
                setButtonText();
                string word = getword(2);
                for (int i = 0; i < word.Length; i++)
                    saveletters.Add(word[i]);
                for (int i = 0; i < saveletters.Count; i++)
                    dashGB.Controls[i].Visible = true;
                playBTN.Text = "دوبارہ شروع کریں";
                alphaGB.Visible = true;
                dashGB.Visible = true;
            }
            else if (playBTN.Text == "دوبارہ شروع کریں")
            {
                DialogResult r = MetroMessageBox.Show(this, "دوبارہ شروع کریں؟", "پکی بات ہے؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    ResetAll();
                    string word = getword(2);
                    for (int i = 0; i < word.Length; i++)
                        saveletters.Add(word[i]);
                    for (int i = 0; i < saveletters.Count; i++)
                        dashGB.Controls[i].Visible = true;
                }
            }
        }

        private void advanceBTN_Click(object sender, EventArgs e)
        {
            showhidedifficulty(0);
            if (playBTN.Text == "کھیل شروع کیا جاۓ")
            {
                layButtons();
                setButtonText();
                string word = getword(3);
                for (int i = 0; i < word.Length; i++)
                    saveletters.Add(word[i]);
                for (int i = 0; i < saveletters.Count; i++)
                    dashGB.Controls[i].Visible = true;
                playBTN.Text = "دوبارہ شروع کریں";
                alphaGB.Visible = true;
                dashGB.Visible = true;
            }
            else if (playBTN.Text == "دوبارہ شروع کریں")
            {
                DialogResult r = MetroMessageBox.Show(this, "دوبارہ شروع کریں؟", "پکی بات ہے؟", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    ResetAll();
                    string word = getword(3);
                    for (int i = 0; i < word.Length; i++)
                        saveletters.Add(word[i]);
                    for (int i = 0; i < saveletters.Count; i++)
                        dashGB.Controls[i].Visible = true;
                }
            }
        }

        private void alephBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(alephBTN.Text));
            if (result)
                alephBTN.BackColor = Color.Green;
            else
                alephBTN.BackColor = Color.Red;
            alephBTN.Enabled = false;
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile9.Text));
            if (result)
                metroTile9.BackColor = Color.Green;
            else
                metroTile9.BackColor = Color.Red;
            metroTile9.Enabled = false;
        }

        private void metroTile24_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile24.Text));
            if (result)
                metroTile24.BackColor = Color.Green;
            else
                metroTile24.BackColor = Color.Red;
            metroTile24.Enabled = false;
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile16.Text));
            if (result)
                metroTile16.BackColor = Color.Green;
            else
                metroTile16.BackColor = Color.Red;
            metroTile16.Enabled = false;
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile8.Text));
            if (result)
                metroTile8.BackColor = Color.Green;
            else
                metroTile8.BackColor = Color.Red;
            metroTile8.Enabled = false;
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile7.Text));
            if (result)
                metroTile7.BackColor = Color.Green;
            else
                metroTile7.BackColor = Color.Red;
            metroTile7.Enabled = false;
        }

        private void metroTile23_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile23.Text));
            if (result)
                metroTile23.BackColor = Color.Green;
            else
                metroTile23.BackColor = Color.Red;
            metroTile23.Enabled = false;
        }

        private void metroTile30_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile30.Text));
            if (result)
                metroTile30.BackColor = Color.Green;
            else
                metroTile30.BackColor = Color.Red;
            metroTile30.Enabled = false;
        }

        private void metroTile15_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile15.Text));
            if (result)
                metroTile15.BackColor = Color.Green;
            else
                metroTile15.BackColor = Color.Red;
            metroTile15.Enabled = false;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile6.Text));
            if (result)
                metroTile6.BackColor = Color.Green;
            else
                metroTile6.BackColor = Color.Red;
            metroTile6.Enabled = false;
        }

        private void jeemBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(jeemBTN.Text)); if (result)
                jeemBTN.BackColor = Color.Green;
            else
                jeemBTN.BackColor = Color.Red;
            jeemBTN.Enabled = false;
        }

        private void metroTile22_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile22.Text));
            if (result)
                metroTile22.BackColor = Color.Green;
            else
                metroTile22.BackColor = Color.Red;
            metroTile22.Enabled = false;
        }

        private void metroTile29_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile29.Text));
            if (result)
                metroTile29.BackColor = Color.Green;
            else
                metroTile29.BackColor = Color.Red;
            metroTile29.Enabled = false;
        }

        private void metroTile14_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile14.Text));
            if (result)
                metroTile14.BackColor = Color.Green;
            else
                metroTile14.BackColor = Color.Red;
            metroTile14.Enabled = false;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile5.Text));
            if (result)
                metroTile5.BackColor = Color.Green;
            else
                metroTile5.BackColor = Color.Red;
            metroTile5.Enabled = false;
        }

        private void metroTile28_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile28.Text));
            if (result)
                metroTile28.BackColor = Color.Green;
            else
                metroTile28.BackColor = Color.Red;
            metroTile28.Enabled = false;
        }

        private void sayBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(sayBTN.Text));
            if (result)
                sayBTN.BackColor = Color.Green;
            else
                sayBTN.BackColor = Color.Red;
            sayBTN.Enabled = false;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile4.Text));
            if (result)
                metroTile4.BackColor = Color.Green;
            else
                metroTile4.BackColor = Color.Red;
            metroTile4.Enabled = false;
        }

        private void metroTile21_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile21.Text));
            if (result)
                metroTile21.BackColor = Color.Green;
            else
                metroTile21.BackColor = Color.Red;
            metroTile21.Enabled = false;
        }

        private void metroTile20_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile20.Text));
            if (result)
                metroTile20.BackColor = Color.Green;
            else
                metroTile20.BackColor = Color.Red;
            metroTile20.Enabled = false;
        }

        private void metroTile27_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile27.Text));
            if (result)
                metroTile27.BackColor = Color.Green;
            else
                metroTile27.BackColor = Color.Red;
            metroTile27.Enabled = false;
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile13.Text));
            if (result)
                metroTile13.BackColor = Color.Green;
            else
                metroTile13.BackColor = Color.Red;
            metroTile13.Enabled = false;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile3.Text));
            if (result)
                metroTile3.BackColor = Color.Green;
            else
                metroTile3.BackColor = Color.Red;
            metroTile3.Enabled = false;
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile12.Text));
            if (result)
                metroTile12.BackColor = Color.Green;
            else
                metroTile12.BackColor = Color.Red;
            metroTile12.Enabled = false;
        }

        private void metroTile19_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile19.Text));
            if (result)
                metroTile19.BackColor = Color.Green;
            else
                metroTile19.BackColor = Color.Red;
            metroTile19.Enabled = false;
        }

        private void metroTile26_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile26.Text));
            if (result)
                metroTile26.BackColor = Color.Green;
            else
                metroTile26.BackColor = Color.Red;
            metroTile26.Enabled = false;
        }

        private void ttayBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(ttayBTN.Text));
            if (result)
                ttayBTN.BackColor = Color.Green;
            else
                ttayBTN.BackColor = Color.Red;
            ttayBTN.Enabled = false;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile2.Text));
            if (result)
                metroTile2.BackColor = Color.Green;
            else
                metroTile2.BackColor = Color.Red;
            metroTile2.Enabled = false;
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile11.Text));
            if (result)
                metroTile11.BackColor = Color.Green;
            else
                metroTile11.BackColor = Color.Red;
            metroTile11.Enabled = false;
        }

        private void metroTile18_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile18.Text));
            if (result)
                metroTile18.BackColor = Color.Green;
            else
                metroTile18.BackColor = Color.Red;
            metroTile18.Enabled = false;
        }

        private void tayBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(tayBTN.Text));
            if (result)
                tayBTN.BackColor = Color.Green;
            else
                tayBTN.BackColor = Color.Red;
            tayBTN.Enabled = false;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
           bool result= checkletter(char.Parse(metroTile1.Text));
            if (result)
                metroTile1.BackColor = Color.Green;
            else
                metroTile1.BackColor = Color.Red;
            metroTile1.Enabled = false;
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile10.Text));
            if (result)
                metroTile10.BackColor = Color.Green;
            else
                metroTile10.BackColor = Color.Red;
            metroTile10.Enabled = false;
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(metroTile17.Text));
            if (result)
                metroTile17.BackColor = Color.Green;
            else
                metroTile17.BackColor = Color.Red;
            metroTile17.Enabled = false;
        }

        private void payBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(payBTN.Text));
            if (result)
                payBTN.BackColor = Color.Green;
            else
                payBTN.BackColor = Color.Red;
            payBTN.Enabled = false;
        }

        private void haybtn_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(haybtn.Text));
            if (result)
                haybtn.BackColor = Color.Green;
            else
                haybtn.BackColor = Color.Red;
            haybtn.Enabled = false;
        }

        private void bayBTN_Click(object sender, EventArgs e)
        {
            bool result=checkletter(char.Parse(bayBTN.Text));
            if (result)
                bayBTN.BackColor = Color.Green;
            else
                bayBTN.BackColor = Color.Red;
            bayBTN.Enabled = false;
        }

        bool checkletter(char a)
        {
            int count = 0;
            List<int> indexes = new List<int>();
            for(int i=0; i<saveletters.Count;i++)
            {
                if (a == saveletters[i])
                {
                    indexes.Add(i);
                    count++;
                }
            }
            if (count > 0)
            {
                foreach (int i in indexes)
                {
                    dashGB.Controls[i].BackColor = Color.Transparent;
                    dashGB.Controls[i].AutoSize = true;
                    dashGB.Controls[i].ForeColor = Color.White;
                    dashGB.Controls[i].Text = saveletters[i].ToString();
                }
                int lettercount = 0;
                for(int i=0; i < saveletters.Count; i++)
                {
                    if(dashGB.Controls[i].Visible==true)
                    {
                        if (dashGB.Controls[i].BackColor == Color.Transparent)
                        {
                            lettercount++;
                        }
                    }
                }
                if (lettercount == saveletters.Count)
                {
                    AllGreen();
                }
            }

            if (count == 0)
            {
                drawhangman();
                return false;
            }
            else
                return true;
        }

        void drawhangman()
        {
            currentstate++;
            if (currentstate == 1)
                pichead.Visible = true;
            if (currentstate == 2)
                picbody.Visible = true;
            if (currentstate == 3)
                picrighthand.Visible = true;
            if (currentstate == 4)
                piclefthand.Visible = true;
            if (currentstate == 5)
                picrightleg.Visible = true;
            if (currentstate == 6)
                picleftleg.Visible = true;
            if (currentstate == 7)
                picpillarbottom.Visible = true;
            if (currentstate == 8)
                picpillarside.Visible = true;
            if (currentstate == 9)
                picpillartop.Visible = true;
            if (currentstate == 10)
            {
                picrope.Visible = true;
                AllRed();
            }
        }

        void AllRed()
        {
            foreach (Control c in alphaGB.Controls)
            {
                c.BackColor = Color.Red;
                c.Enabled = false;
            }
            wordLB.Text = "درست جواب:" + " ";
            foreach (char a in saveletters)
            {
                wordLB.Text += a.ToString();
            }
        }

        void AllGreen()
        {
            foreach(Control c in alphaGB.Controls)
            {
                c.BackColor = Color.Green;
                c.Enabled = false;
            }
            wordLB.Text = "درست جواب:"+" ";
            foreach (char a in saveletters)
            {
                wordLB.Text += a.ToString();
            }
        }
        void hidepictures()
        {
            picbody.Visible = false;
            pichead.Visible = false;
            picleftleg.Visible = false;
            picrightleg.Visible = false;
            piclefthand.Visible = false;
            picrighthand.Visible = false;
            picpillartop.Visible = false;
            picpillarbottom.Visible = false;
            picpillarside.Visible = false;
            picrope.Visible = false;
        }

        string getword(int difficulty)
        {
            string selected = "";
            Random word = new Random();
            if(difficulty==1)
                selected = array3[word.Next(0, array3.Length)];
            if(difficulty==2)
                selected= array4[word.Next(0, array4.Length)];
            if(difficulty==3)
                selected=array5[word.Next(0, array5.Length)];
            return selected;
        }

        void layButtons()
        {
            for (int i = 0; i < alphaGB.Controls.Count; i++)
            {
                alphaGB.Controls[i].Visible = true;
                alphaGB.Controls[i].BackColor = Color.DarkSlateGray;
                alphaGB.Controls[i].Enabled = true;
            }
        }

        void setButtonText()
        {
            for (int i = 0; i < alphaGB.Controls.Count; i++)
            {
                alphaGB.Controls[i].Text = all[i].ToString();
            }
        }

        void ResetAll()
        {
            wordLB.Text = "";
            currentstate = 0;
            hidepictures();
            layButtons();
            saveletters.Clear();
            for (int i = 0; i < dashGB.Controls.Count; i++)
            {
                dashGB.Controls[i].BackColor = Color.Crimson;
                dashGB.Controls[i].AutoSize = false;
                dashGB.Controls[i].ForeColor = Color.White;
                dashGB.Controls[i].Text = "";
                dashGB.Controls[i].Visible = false;
            }
        }

        void showhidedifficulty(int choice)
        {
            if(choice==0)
            {
                easyBTN.Visible = false;
                medBTN.Visible = false;
                advanceBTN.Visible = false;
            }
            if(choice==1)
            {
                easyBTN.Visible = true;
                medBTN.Visible = true;
                advanceBTN.Visible = true;
            }
        }
    }
}
