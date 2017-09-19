using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace StatGet_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<PeriodGoal> periodGoals;
        string HTMLdata;


        public class PeriodGoal
        {
            public string _time;
            public string _res;
            public string _Stat;
            public string _team;
            public string _scorer;
            public string _ass1;
            public string _ass2;

            public PeriodGoal(string time, string res, string stat, string team, string scorer, string ass1, string ass2)
            {
                _time = time;
                _res = res;
                _Stat = stat;
                _team = team;
                _scorer = scorer;
                _ass1 = ass1;
                _ass2 = ass2;
            }

            public PeriodGoal(string time, string res, string stat, string team, string scorer, string ass1)
            {
                _time = time;
                _res = res;
                _Stat = stat;
                _team = team;
                _scorer = scorer;
                _ass1 = ass1;
                _ass2 = "N/A";
            }

            public PeriodGoal(string time, string res, string stat, string team, string scorer)
            {
                _time = time;
                _res = res;
                _Stat = stat;
                _team = team;
                _scorer = scorer;
                _ass1 = "N/A";
                _ass2 = "N/A";
            }
        }

        public void updateGoalsList()
        {
            listView1.Columns.Add("Time", 70);
            listView1.Columns.Add("Res", 70);
            listView1.Columns.Add("Stat", 70);
            listView1.Columns.Add("Team", 70);
            listView1.Columns.Add("Scorere", 200);
            listView1.Columns.Add("Assist 1", 200);
            listView1.Columns.Add("Assist 2", 200);

            ListViewItem row;
            foreach (var goal in periodGoals) {
                row = new ListViewItem(goal._time);
                row.SubItems.Add(goal._res);
                row.SubItems.Add(goal._Stat);
                row.SubItems.Add(goal._team);
                row.SubItems.Add(goal._scorer);
                row.SubItems.Add(goal._ass1);
                row.SubItems.Add(goal._ass2);

                listView1.Items.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            periodGoals = new List<PeriodGoal>();

            periodGoals.Add(new PeriodGoal("1:00", "1-0", "EQ", "H", "jensa", "mupp1", "mupp2"));
            periodGoals.Add(new PeriodGoal("2:00", "2-0", "EQ", "H", "jensa", "mupp1"));
            periodGoals.Add(new PeriodGoal("2:00", "2-0", "EQ", "H", "jensa"));

           listView1.Clear();
           updateGoalsList();


            readHTML();
            generateTree();

        }

        public void readHTML()
        {
            string pageAddr = "http://stats.swehockey.se/Game/Events/206736";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageAddr);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                HTMLdata = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
        }

        public void generateTree() {
            int nodeCnt = 0;
            int treeDepthParents[50] = { 0 };
            int currentParent = 0;
            treeForm->TreeView1->Items->Clear();

            // find next tag
            int pos;
            int start = 0;
            bool endSign;
            int startPos;
            int endPos;
            AnsiString tag = "";
            AnsiString buff;
            bool tagNameEnded;
            TTreeNode* currentNode;

            // First child and its children
            treeForm->TreeView1->Items->Add(NULL, "HTML Base");
            buff = rawHTML;

            currentParent = 0;
            treeDepthParents[currentParent] = 0;
            bool modified;
            bool dataErased;
            bool endRowFound = true;

            // find next tag
            while (0 != (startPos = buff.Pos("<")))
            {
                endPos = startPos;
                startPos++;
                tag = "";
                tagNameEnded = false;


                // if data exists on tag
                AnsiString data = "";
                if (startPos > 2 && nodeCnt > 0)
                {
                    AnsiString data = buff.SubString(1, startPos - 2);
                    dataErased = false;

                    do
                    {
                        modified = false;
                        if (isWhiteSpace(data[1]) || isBadChar(data[1]))
                        {
                            if (data.Length() == 1)
                            {
                                dataErased = true;
                            }
                            data.Delete(1, 1);
                            modified = true;
                        }
                    } while (!dataErased && modified);

                    if (!dataErased)
                    {
                        do
                        {
                            modified = false;
                            int b = data.Length();
                            if (isWhiteSpace(data[data.Length()]) || isBadChar(data[data.Length()]))
                            {
                                if (data.Length() == 1)
                                {
                                    dataErased = true;
                                }
                                data.Delete(data.Length(), 1);
                                modified = true;
                            }
                        } while (!dataErased && modified);
                    }

                    if (!dataErased)
                    {
                        do
                        {
                            modified = false;
                            for (int i = 1; i <= data.Length(); i++)
                            {
                                if (isBadChar(data[i]))
                                {
                                    if (data.Length() == 1)
                                    {
                                        dataErased = true;
                                    }
                                    data.Delete(i, 1);
                                    i--;
                                    modified = true;
                                }
                                else if (isWhiteSpace(data[i]) && i > 1)
                                {
                                    if (isWhiteSpace(data[i - 1]))
                                    {
                                        if (data.Length() == 1)
                                        {
                                            dataErased = true;
                                        }

                                        data.Delete(i, 1);
                                        i--;
                                        modified = true;
                                    }
                                }
                            }
                        } while (modified && !dataErased);

                        if (!dataErased)
                        {
                            currentNode->Text = currentNode->Text + ": " + data;
                        }
                    }
                }

                while (buff[++endPos] != '>')
                {
                    if (buff[endPos] != '/')
                    {
                        if (buff[endPos] == ' ')
                        {
                            tagNameEnded = true;
                        }

                        if (!tagNameEnded)
                        {
                            tag += buff[endPos];
                        }

                    }
                }
                endSign = buff[startPos] == '/';

                if (!endSign)
                {
                    if (tag.AnsiCompare("tr") == 0)
                    {
                        if (!endRowFound)
                        {
                            // make end row, code missed that apparently
                            currentParent--;
                        }
                        endRowFound = false;
                    }

                    currentNode = treeForm->TreeView1->Items->AddChild(treeForm->TreeView1->Items->Item[treeDepthParents[currentParent]], tag.c_str());
                    nodeCnt++;
                    if (tagIsNewParent(tag))
                    {
                        currentParent++;
                        treeDepthParents[currentParent] = nodeCnt;
                    }

                }
                else {
                    if (tag.AnsiCompare("tr") == 0)
                    {
                        endRowFound = true;
                    }

                    if (tagIsNewParent(tag))
                    {
                        currentParent--;
                    }
                }

                buff.Delete(1, endPos);
            }


        }
        
    }
}