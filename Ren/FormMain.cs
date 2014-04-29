using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ren.Properties;
using System.IO;
using System.Runtime.InteropServices;

namespace Ren
{
    public partial class FormMain : Form
    {
        #region Variables
        /********************************************** Variables ******************************************************************/

        private Settings m_Settings;

        private string m_LastDir = @"D:\Film\Series";
        private string m_FileDir = "";

        private string m_Extenstion = "";

        #endregion Variables

        #region Constructor, Load & Closing
        /********************************************** Constructor, Load & Closing ************************************************/

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();

            this.Top = 100;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 200;
            this.Left = 900;

            AddClipboardFormatListener(this.Handle);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveClipboardFormatListener(this.Handle);
        }

        #endregion Constructor, Load & Closing

        #region Button Events
        /********************************************** Button Events **************************************************************/

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbRename.Items.Clear();
        }

        #endregion Button Events

        #region Control Events
        /********************************************** Control Events *************************************************************/

        private void lbFiles_MouseDown(object sender, MouseEventArgs e)
        {
            int myIndex = lbFiles.IndexFromPoint(e.Location);

            if (myIndex > -1)
            {
                lbFiles.DoDragDrop(lbFiles.Items[myIndex], DragDropEffects.Move);
            }
        }

        private void lbFiles_DragDrop(object sender, DragEventArgs e)
        {
            Point myPoint = lbFiles.PointToClient(new Point(e.X, e.Y));

            int myIndex = lbFiles.IndexFromPoint(myPoint);
            if (myIndex < 0) myIndex = lbFiles.Items.Count - 1;

            object myData = e.Data.GetData(typeof(string));
            lbFiles.Items.Remove(myData);
            lbFiles.Items.Insert(myIndex, myData);            
        }

        private void lbFiles_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lbFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                lbFiles.Items.Remove(lbFiles.SelectedItem);
            }
        }

        private void lbRename_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbRename.SelectedItem != null)
            {
                lbRename.Items.Remove(lbRename.SelectedItem);
            }
        }

        #endregion Control Events

        #region Functions
        /********************************************** Functions ******************************************************************/

        private void Init()
        {
            m_Settings = new Settings();
            m_Settings.Reload();

            if (!string.IsNullOrEmpty(m_Settings.LastDir))
            {
                if (Directory.Exists(m_Settings.LastDir))
                {
                    m_LastDir = m_Settings.LastDir;
                }
                else
                {
                    string myDir = Path.GetDirectoryName(m_Settings.LastDir);

                    while (myDir != null && !Directory.Exists(myDir))
                    {
                        myDir = Path.GetDirectoryName(myDir);
                    }

                    if (Directory.Exists(myDir))
                    {
                        m_LastDir = m_Settings.LastDir = myDir;
                        m_Settings.Save();
                    }
                }
            }
        }

        private void OpenFiles()
        {
            lbFiles.Items.Clear();
            lbRename.Items.Clear();

            fbdDialog.SelectedPath = m_LastDir;
            fbdDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            using (new CenterWinDialog(this))
            {

                if (fbdDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_LastDir = m_Settings.LastDir = fbdDialog.SelectedPath;
                    m_Settings.Save();

                    DirectoryInfo myDirInfo = new DirectoryInfo(fbdDialog.SelectedPath);

                    if (myDirInfo.GetFiles("*", SearchOption.AllDirectories).Length > 0)
                    {
                        foreach (FileInfo myFileInfo in myDirInfo.GetFiles("*", SearchOption.AllDirectories))
                        {
                            m_Extenstion = myFileInfo.Extension;
                            m_FileDir = Path.GetDirectoryName(myFileInfo.FullName);

                            AddFile(myFileInfo.FullName);

                        }
                    }
                }
            }
        }

        private void AddFile(string FileName)
        {
            lbFiles.Items.Add(Path.GetFileNameWithoutExtension(FileName));
        }

        private void RenameFile(string OldName, string NewName)
        {
            try
            {
                OldName = string.Format("{0}{1}", Path.Combine(m_FileDir, OldName), m_Extenstion);
                NewName = string.Format("{0}{1}", Path.Combine(m_FileDir, NewName), m_Extenstion);

                File.Move(OldName, NewName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Rename()
        {
            if (lbFiles.Items.Count == lbRename.Items.Count)
            {
                for (int i = 0; i < lbFiles.Items.Count; i++)
                {
                    string myOld = lbFiles.Items[i].ToString();
                    string myNew = lbRename.Items[i].ToString();

                    RenameFile(myOld, myNew);
                }

                lbFiles.Items.Clear();
                lbRename.Items.Clear();
            }
            else
            {
                MessageBox.Show("Ongelijk aantal");
            }
        }

        private void AddRegel(string Tekst)
        {
            Tekst = Tekst.Replace(@"\", "").Replace(@"/", "").Replace(@"*", "").Replace(@"?", "").Replace("\"", "").Replace(@"<", "").Replace(@">", "").Replace(@"|", "").Replace(@":", "");

            lbRename.Items.Add(Tekst);
        }

        private void VerwerkRegel(string Tekst)
        {
            if (!string.IsNullOrEmpty(Tekst))
            {
                try
                {
                    string myNummer = Tekst.Substring(Tekst.IndexOf("-") + 1, 2);

                    string myTitel = Tekst.Substring(Tekst.IndexOf("-") + 3, Tekst.Length - (Tekst.IndexOf("-") + 3));

                    myTitel = Tekst.Substring(Tekst.IndexOf("/") + 8, Tekst.Length - (Tekst.IndexOf("/") + 8));

                    myTitel = myTitel.Replace("[Recap]", "").Replace("[Trailer]", "");


                    AddRegel(string.Format("{0} {1}", myNummer, myTitel.Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void VerwerkClipboard(string Tekst)
        {
            if (lbFiles.Items.Count > 0)
            {
                string[] myRegels = Tekst.Split(Environment.NewLine.ToCharArray());

                foreach (string myRegel in myRegels)
                {
                    VerwerkRegel(myRegel.Trim());
                }
            }
        }
	
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
 
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                IDataObject iData = Clipboard.GetDataObject();     

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);
                    VerwerkClipboard(text);
                }
            }
        }

        #endregion Functions

        #region Properties
        /********************************************** Properties *****************************************************************/

        #endregion Properties

        #region External
        /********************************************** External *****************************************************************/

        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        #endregion External





    }
}
