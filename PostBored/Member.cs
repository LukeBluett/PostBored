using System;
using System.Drawing;
namespace PostBored
{
    public class Member
    {

        private String username, email;
        private bool msgPrivate;
        private DateTime lastSeen, joinDate;
        private long phone;
        private System.Drawing.Image image;
        private int postsMade;
        private int likesReceived;


        public Member(String username, String email, long phone,Image image, DateTime joinDate, bool msgPrivate, DateTime lastSeen, int postsMade, int likesReceived)
        {
            Username = username;
            Email = email;
            this.phone = phone;
            this.joinDate = joinDate;
            this.lastSeen = lastSeen;
            this.msgPrivate = msgPrivate;
            this.image = image;
            this.postsMade = postsMade;
            this.likesReceived = likesReceived;
        }

        public Member()
        {
            
        }


        public string Username
        {
            get { return username; }
            set { username = value; }

        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public long Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        public DateTime JoinDate
        {
            get { return joinDate; }
            set { joinDate = value; }
        }
        public bool MsgPrivate
        {
            get { return msgPrivate; }
            set { msgPrivate = value; }
        }
        public DateTime LastSeen
        {
            get { return lastSeen; }
            set { lastSeen = value; }
        }
        public int PostsMade
        {
            get { return postsMade; }
            set { postsMade = value; }
        }
        public int LikesReceived
        {
            get { return likesReceived; }
            set { likesReceived = value; }
        }

    }
}
