using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ValidationComponents;
using ABBfa_Model;

namespace ABBFa
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        
        void GetDateIndgv()
        {
            using (var db = new AbbfaContext())
            {
                var result = db.Agents.ToList();
           
                DgvAgent.DataSource = result;
                DgvAgent.Columns[0].Visible = false;
                DgvAgent.Columns[1].HeaderText = "نام";
                DgvAgent.Columns[2].HeaderText = "نام خانوادگی ";
                DgvAgent.Columns[3].Visible = false;
                DgvAgent.Columns[4].HeaderText = "موبایل";
                DgvAgent.Columns[5].HeaderText = "کد ملی ";
                DgvAgent.Columns[6].HeaderText = "تاریخ تولد";
                DgvAgent.Columns[7].HeaderText = "تاریخ استخدام";
                DgvAgent.Columns[8].HeaderText = "آدرس";
                DgvAgent.Columns[9].HeaderText = "تصویر";
               


            }
        }
        
        private void FrmUser_Load(object sender, EventArgs e)
        {
            picturePictureBox.Image = Image.FromFile(Application.StartupPath + " \\Blank-profile.png",true);
            GetDateIndgv(); 
        }

        private byte[] GetPicbyte(PictureBox pictureBox)
        {
            byte[] Arrypic = null;
            using (MemoryStream Ms = new MemoryStream())
            {
                if (pictureBox!=null)
                {
                    pictureBox.Image.Save(Ms, pictureBox.Image.RawFormat);
                    Arrypic = Ms.GetBuffer();
                }
            }
            return Arrypic;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //DateTime BrithDay = Convert.ToDateTime();
            //DateTime Yearofemployment = Convert.ToDateTime(TxtEmplateDate.Text); 
            if (BaseValidator.IsFormValid(this.components))
            {
                using (var db = new AbbfaContext())
                {
                    Agent agent = new Agent()
                    {
                        //FirstName = TxtFirstName.Text,
                        //LastName = TxtLastName.Text,
                        //Mobile = TxtMobile.Text,
                        //Address = TxtAddress.Text,
                        //CodeMeli = 
                        ////BrithDay = BrithDay,
                        //Yearofemployment = BrithDay,
                        //Picture = GetPicbyte(picturePictureBox),

                    };
                    db.Agents.Add(agent);
                    db.SaveChanges();
                    RtlMessageBox.Show("عملیات ثبت با موفقیت انجام شد ", " عملیات درج ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetDateIndgv();

                }
               
                
                
            }
        }

        private void BtnLoading_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); 
            openFile.Filter= "Image Files|*.jpg; *.jpeg; *.png";
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                picturePictureBox.Image = new Bitmap (openFile.FileName);
            }
        }

        private void FrmUser_Load_1(object sender, EventArgs e)
        {

        }
    }
}
