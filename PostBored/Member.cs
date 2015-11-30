using System;
namespace PostBored
{
    public class Member
    {

        private String username, email;
        private bool msgPrivate;
        private DateTime lastSeen, joinDate;
        private long phone;
        private System.Drawing.Image image;


        public Member(String username, String email, long phone, Drawing.Image image, DateTime joinDate, bool msgPrivate, DateTime lastSeen)
        {
            this.username = username;
            this.email = email;
            this.phone = phone;
            this.joinDate = joinDate;
            this.lastSeen = lastSeen;
            this.msgPrivate = msgPrivate;
            this.image = image;
        }


        public string username
        {
            get { return username; }
            set { username = value; }

        }
        public string email
        {
            get { return email; }
            set { email = value; }
        }
        public long phone
        {
            get { return phone; }
            set { phoone = value; }
        }
        public Drawing.Image image
        {
            get { return image; }
            set { image = value; }
        }
        public DateTime joinDate
        {
            get { return joinDate; }
            set { image = value; }
        }
        public bool msgPrivate
        {
            get { return msgPrivate; }
            set { msgPrivate = value; }
        }
        public DateTime lastSeen
        {
            get { return lastSeen; }
            set { lastSeen = value; }
        }

    }
}
