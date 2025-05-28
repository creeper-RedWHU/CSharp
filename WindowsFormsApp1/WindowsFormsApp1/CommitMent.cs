using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public class CommitMent : IComparable<CommitMent>
    {
        public CommitMent() { }
        public int StudentID {  get; set; }
        public int HID {  get; set; }
        public int PID {  get; set; }
        public string Answer {  get; set; }
        public int Score {  get; set; }
        public string CommitTime {  get; set; }
        public string FeedBack {  get; set; }
        public int CompareTo(CommitMent other)
        {
            return PID.CompareTo(other.PID);
            
        }
    }
}
