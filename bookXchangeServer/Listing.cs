using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace bookXchangeServer
{
    [Serializable()]
    class Listing : IXmlSerializable
    {
        private string mListingID;
        private string mBookID;
        private string mUserID;
        private DateTime mListedDate = new DateTime();
        private string mListedDateString;
        private bool mIsRequest;
        private int mPrice;

        public Listing(string pUserID, string pBookID, bool pIsRequest, int pPrice)
        {
            mUserID = pUserID;
            mBookID = pBookID;
            mListedDate = DateTime.Now;
            mIsRequest = pIsRequest;
            mPrice = pPrice;
        }

        public string GetListingID() { return mListingID; }

        //serialization methods


        ////This serializes the object
        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    mListedDateString = mListedDate.ToString();
        //    info.AddValue("ID", mListingID, typeof(string));
        //    info.AddValue("bookID", mBookID, typeof(string));
        //    info.AddValue("userID", mUserID, typeof(string));
        //    info.AddValue("listedDate", mListedDateString, typeof(string));
        //    info.AddValue("isRequest", mIsRequest);
        //    info.AddValue("price", mPrice, typeof(int));
        //}

        ////deserializes the stream in to a new object
        //public Listing(SerializationInfo info, StreamingContext context)
        //{
        //    mListingID = (string)info.GetValue("ID", typeof(string));
        //    mBookID = (string)info.GetValue("bookID", typeof(string));
        //    mUserID = (string)info.GetValue("mUserID", typeof(string));
        //    mListedDateString = (string)info.GetValue("listedDate", typeof(string));
        //    mListedDate = Convert.ToDateTime(mListedDateString);
        //    mIsRequest = (bool)info.GetValue("isRequest", typeof(bool));
        //    mPrice = (int)info.GetValue("price", typeof(int));

        //}
        public Listing()
        {
            
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            ;
            bool isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmptyElement)
            {
                mListingID = reader.ReadElementContentAsString("ID", "");
                mBookID = reader.ReadElementContentAsString("BookID", "");
                mUserID = reader.ReadElementContentAsString("UserID", "");
                mListedDate = reader.ReadElementContentAsDateTime("ListingDate", "");
                mIsRequest = reader.ReadElementContentAsBoolean("isRequest", "");
                mPrice = reader.ReadElementContentAsInt("price", "");
                reader.ReadEndElement();
            }

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Listing");
            writer.WriteElementString("ID", mListingID);
            writer.WriteElementString("BookID", mBookID);
            writer.WriteElementString("UserID", mUserID);
            writer.WriteElementString("ListingDate", mListedDateString);
            writer.WriteElementString("isRequest", mIsRequest.ToString());
            writer.WriteElementString("price", mPrice.ToString());
            writer.WriteEndElement();

        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
    }
}
